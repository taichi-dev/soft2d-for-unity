using UnityEngine;
using Taichi.Soft2D.Plugin;

public class RotateObject : MonoBehaviour
{
    public float angularVelocity;

    void Update()
    {
        if (!Soft2DManager.Instance.pause)
        {
            transform.Rotate(new Vector3(0, 0, angularVelocity));
        }
    }
}