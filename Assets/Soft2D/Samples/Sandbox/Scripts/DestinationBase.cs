using System;
using System.Runtime.InteropServices;
using UnityEngine;
using Game;
using Taichi.Soft2D.Generated;
using Taichi.Soft2D.Plugin;

public class DestinationBase : MonoBehaviour
{
    private static uint particleNum;
    private static bool isLocked = true;
    private uint volume;

    public ETrigger trigger;

    public void Start()
    {
        trigger = GetComponent<ETrigger>();
    }

    public void Update()
    {
        if (trigger.isInitialized && !Soft2DManager.Instance.pause)
        {
            if (volume >= GameManager.Instance.lvlData.volumeGoal)
            {
                GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
                GameManager.Instance.IsPause = true;
            }
            else
            {
                trigger.InvokeCallbackAsync(ManipulateParticles);
                if (!isLocked)
                {
                    volume += particleNum;
                    //calculate waterline
                    int goal = GameManager.Instance.lvlData.volumeGoal;
                    Transform waterLine = transform.GetChild(0);

                    //calculate local scale
                    var scale = waterLine.localScale;
                    float originalYScale = scale.y;
                    float offset1 = 1.48f * particleNum / (float)goal;
                    var localScale = new Vector3(scale.x, originalYScale + offset1, scale.z);
                    waterLine.localScale = localScale;

                    //calculate local position
                    var pos = waterLine.localPosition;
                    float originalYPos = pos.y;
                    float offset2 = 0.75f * particleNum / (float)goal;
                    var localPos = new Vector3(pos.x, offset2 + originalYPos, pos.z);
                    waterLine.localPosition = localPos;
                    particleNum = 0;
                    isLocked = true;
                }
            }
        }
    }

    [AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
    public static void ManipulateParticles(IntPtr particles, uint size)
    {
        int particleSize = Marshal.SizeOf<S2Particle>();
        for (int i = 0; i < size; i++)
        {
            IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
            S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
            if (particle.tag >> 24 == 1)
            {
                particle.is_removed = 1;
                particleNum++;
            }
            Marshal.StructureToPtr(particle, particlePtr, false);
        }
        isLocked = false;
    }
}