using System;
using System.Collections.Generic;
using Taichi.Generated;
using UnityEngine;
using UnityEngine.Rendering;

namespace Taichi {
    public class Runtime : IDisposable {
        public readonly TiRuntime Handle;
        private List<IDisposable> _BoundDisposables;

        public Runtime() {
            Handle = Ffi.TixImportNativeRuntimeUnity();
            _BoundDisposables = new List<IDisposable>();
        }



        private static Runtime _Singleton;
        public static Runtime Singleton {
            get {
                if (_Singleton == null || _Singleton.IsDisposed) {
                    _Singleton = new Runtime();
                }
                return _Singleton;
            }
        }

        // Ensures the object is disposed before Taichi Runtime.
        public static T CreateTaichiDependentObject<T>() where T: IDisposable, new() {
            var rv = new T();
            Singleton._BoundDisposables.Add(rv);
            return rv;
        }



        public static void Submit() {
            GL.IssuePluginEvent(Ffi.TixSubmitAsyncUnity(Singleton.Handle), 0);
        }
        public static void Submit(CommandBuffer commandBuffer) {
            commandBuffer.IssuePluginEvent(Ffi.TixSubmitAsyncUnity(Singleton.Handle), 0);
        }



        public bool IsDisposed => disposedValue;
        private bool disposedValue;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                }

                foreach (var boundDisposable in _BoundDisposables) {
                    boundDisposable.Dispose();
                }
                _BoundDisposables.Clear();

                Ffi.TiDestroyRuntime(Handle);
                disposedValue = true;
            }
        }
        ~Runtime() {
            Dispose(disposing: false);
        }
        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
