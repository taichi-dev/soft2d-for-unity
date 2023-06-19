using System;
using Taichi.Soft2D.Generated;

namespace Taichi.Soft2D
{
    public class Body : IDisposable
    {
        public readonly S2Body Handle;

        public Body(S2Body handle)
        {
            Handle = handle;
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
                    //
                }

                disposedValue = true;
            }
        }

        ~Body()
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
