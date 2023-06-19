using System;
using System.Runtime.InteropServices;
using Taichi.Soft2D.Generated;
using Taichi.Soft2D.Plugin;
using UnityEngine;

public class CallbackController : MonoBehaviour
{
    public ETrigger trigger;

    [AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
    public static void ManipulateParticles(IntPtr particles, uint size)
    {
        int particleSize = Marshal.SizeOf<S2Particle>();
        for (int i = 0; i < size; i++)
        {
            IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
            S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
            // You can manipulate your particles here:
            // For example, we can delete them:
            particle.is_removed = 1;
            Marshal.StructureToPtr(particle,particlePtr,false);
        }
    }
    
    void Update()
    {
        trigger.InvokeCallbackAsync(ManipulateParticles);
    }
}
