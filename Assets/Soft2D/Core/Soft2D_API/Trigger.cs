using System;
using UnityEngine;
using Taichi.Soft2D.Generated;

namespace Taichi.Soft2D
{
    public class Trigger : IDisposable
    {
        public readonly S2Trigger Handle;

        public Trigger(S2Trigger handle)
        {
            Handle = handle;
        }

        public void ManipulateParticlesInTriggerAsync(S2ParticleManipulationCallback callback)
        {
            Ffi.S2XManipulateParticlesInTriggerAsyncUnity(Handle, callback);
        }

        public bool IsDisposed => disposedValue;
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (Handle.Inner != null)
                {
                    // remove ..
                }

                disposedValue = true;
            }
        }

        ~Trigger()
        {
            Dispose(disposing: false);
        }

        public void SetTriggerPosition(Vector2 pos)
        {
            S2Vec2 position = new S2Vec2(pos.x, pos.y);
            Ffi.S2SetTriggerPosition(Handle,position);
        }

        public Vector2 GetTriggerPosition()
        {
            S2Vec2 ans = Ffi.S2GetTriggerPosition(Handle);
            return new Vector2(ans.x, ans.y);
        }

        public void SetTriggerRotation(float rotation)
        {
            Ffi.S2SetTriggerRotation(Handle,rotation);
        }

        public float GetTriggerRotation()
        {
            return Ffi.S2GetTriggerRotation(Handle);
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
