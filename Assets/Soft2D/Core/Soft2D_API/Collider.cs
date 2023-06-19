using System;
using Taichi.Soft2D.Generated;
using UnityEngine;

namespace Taichi.Soft2D
{
    public class Collider : IDisposable
    {
        public readonly S2Collider Handle;

        public Collider(S2Collider handle)
        {
            Handle = handle;
        }

        public void SetColliderPosition(Vector2 pos)
        {
            S2Vec2 position = new S2Vec2(pos.x, pos.y);
            Ffi.S2SetColliderPosition(Handle, position);
        }

        public Vector2 GetColliderPosition()
        {
            S2Vec2 temp = Ffi.S2GetColliderPosition(Handle);
            return new Vector2(temp.x, temp.y);
        }

        public void SetColliderRotation(float rotation)
        {
            Ffi.S2SetColliderRotation(Handle, rotation);
        }

        public float GetColliderRotation()
        {
            return Ffi.S2GetColliderRotation(Handle);
        }

        public void SetColliderLinearVelocity(Vector2 l_velocity)
        {
            S2Vec2 linear_velocity = new S2Vec2(l_velocity.x, l_velocity.y);
            Ffi.S2SetColliderLinearVelocity(Handle, linear_velocity);
        }

        public Vector2 GetColliderLinearVelocity()
        {
            S2Vec2 temp = Ffi.S2GetColliderLinearVelocity(Handle);
            return new Vector2(temp.x, temp.y);
        }

        public void SetColliderAngularVelocity(float angular_velocity)
        {
            Ffi.S2SetColliderAngularVelocity(Handle, angular_velocity);
        }

        public float GetColliderAngularVelocity()
        {
            return Ffi.S2GetColliderAngularVelocity(Handle);
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

        ~Collider()
        {
            Dispose(disposing: false);
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
