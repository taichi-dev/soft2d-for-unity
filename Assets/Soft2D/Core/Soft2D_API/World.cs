using System;
using System.Runtime.InteropServices;
using Taichi.Soft2D.Generated;
using UnityEngine;
using UnityEngine.Rendering;

namespace Taichi.Soft2D
{

    public class WorldConfig {
        public static S2WorldConfig config = new S2WorldConfig(
                90000, // max_allowed_particle_num
                10000, // max_allowed_body_num
                10000, // max_allowed_element_num
                10000, // max_allowed_trigger_num
                128, // grid_resolution
                new S2Vec2(0.0f, 0.0f), // offset
                new S2Vec2(1.0f, 1.0f), // extent
                1e-4f, // substep_dt
                new S2Vec2(0.0f, -9.8f), // gravity
                S2OutWorldBoundaryPolicy.S2_OUT_WORLD_BOUNDARY_POLICY_DEACTIVATION, // out_of_world_boundary_policy
                1, // enable_debugging
                1, // enable_world_query
                1e-6f, // mesh_body_force_scale
                0.1f, // collision_penalty_force_scale_along_normal_dir
                0.1f, // collision_penalty_force_scale_along_velocity_dir
                4 // fine_grid_scale
            );
    }
    public class World : IDisposable
    {
        public readonly S2World Handle;

        public World()
        {
            var currentGraphicsAPI = SystemInfo.graphicsDeviceType;
            if (currentGraphicsAPI == GraphicsDeviceType.Vulkan ||
                currentGraphicsAPI == GraphicsDeviceType.Metal)
                Handle = Ffi.S2XCreateWorldAsyncUnity(currentGraphicsAPI == GraphicsDeviceType.Vulkan?Taichi.Generated.TiArch.TI_ARCH_VULKAN:Taichi.Generated.TiArch.TI_ARCH_METAL, Runtime.Singleton.Handle, WorldConfig.config);
            else
                Plugin.Utils.Assert("Soft2D only supports Vulkan and Metal for now.");
        }

        private static World _Singleton;

        public static World Singleton
        {
            get
            {
                if (_Singleton == null || _Singleton.IsDisposed)
                {
                    _Singleton = Runtime.CreateTaichiDependentObject<World>();
                }

                return _Singleton;
            }
        }

        public static void Reset()
        {
            if (_Singleton != null && !_Singleton.IsDisposed)
            {
                _Singleton.Dispose(true);
            }
        }

        public static Body CreateBody(S2Material material, S2Kinematics kinematics, S2Shape shape, uint tag = 0)
        {
            return new Body(Ffi.S2CreateBody(Singleton.Handle, material, kinematics, shape, tag));
        }

        public static Body CreateCustomBody(S2Material material, S2Kinematics kinematics, int particle_num, float[] particles_in_local_space, uint tag = 0)
        {
            return new Body(Ffi.S2CreateCustomBody(Singleton.Handle, material, kinematics, (uint)particle_num, particles_in_local_space, tag));
        }

        public static Body CreateMeshBody(S2Material material, S2Kinematics kinematics, int particle_num,
            float[] particle_data, int index_num, int[] index_data, uint tag = 0)
        {
            return new Body(Ffi.S2CreateMeshBody(Singleton.Handle, material, kinematics, (uint)particle_num,
                particle_data, (uint)index_num, index_data, tag));
        }

        public static void DestroyBody(Body body)
        {
            Ffi.S2DestroyBody(body.Handle);
        }

        public static void SetBodyMaterialType(Body body, S2Material material)
        {
            Ffi.S2SetBodyMaterial(body.Handle, material);
        }

        public static void SetBodyTag(Body body, uint tag)
        {
            Ffi.S2SetBodyTag(body.Handle, tag);
        }

        public static void ApplyBodyAngularImpulse(Body body, float an_v)
        {
            Ffi.S2ApplyAngularImpulse(body.Handle, an_v);
        }

        public static void ApplyBodyLinearImpulse(Body body, Vector2 li_v)
        {
            S2Vec2 vec2 = new S2Vec2(li_v.x, li_v.y);
            Ffi.S2ApplyLinearImpulse(body.Handle, vec2);
        }

        public static Collider CreateCollider(S2Kinematics kinematics, S2Shape shape, S2CollisionParameter parameter)
        {
            return new Collider(Ffi.S2CreateCollider(Singleton.Handle, kinematics, shape, parameter));
        }

        public static void DestroyCollider(Collider collider)
        {
            Ffi.S2DestroyCollider(collider.Handle);
        }

        public static Trigger CreateTrigger(S2Kinematics kinematics, S2Shape shape)
        {
            return new Trigger(Ffi.S2CreateTrigger(Singleton.Handle, kinematics, shape));
        }

        public static void DestroyTrigger(Trigger trigger)
        {
            Ffi.S2DestroyTrigger(trigger.Handle);
        }

        public static void Step(float delta_time = 1.6e-2f)
        {
            if (_Singleton.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(World));
            }

            Ffi.S2XStepAsyncUnity(Singleton.Handle,delta_time);
        }

        // FIXME: use generic methods to replace CreateNdArrayFloat() and CreateNdArrayInt()
        private static NdArray<float> CreateNdArrayFloat(Taichi.Generated.TiNdArray ndarray)
        {
            int size = Marshal.SizeOf<float>();

            int shapeDimCount = (int)ndarray.shape.dim_count;
            int[] shape = new int[shapeDimCount];
            for (int i = 0; i < shapeDimCount; i++)
            {
                shape[i] = (int)ndarray.shape.dims[i];
                size *= shape[i];
            }

            int elemShapeDimCount = (int)ndarray.elem_shape.dim_count;
            int[] elemShape = new int[elemShapeDimCount];
            for (int i = 0; i < elemShapeDimCount; i++)
            {
                elemShape[i] = (int)ndarray.elem_shape.dims[i];
                size *= elemShape[i];
            }

            Memory memory = new Memory(size, false, false,
                Taichi.Generated.TiMemoryUsageFlagBits.TI_MEMORY_USAGE_STORAGE_BIT, ndarray.memory);

            var rv = new NdArray<float>(shape, elemShape, memory);
            return rv;
        }

        private static NdArray<int> CreateNdArrayInt(Taichi.Generated.TiNdArray ndarray)
        {
            int size = Marshal.SizeOf<int>();

            int shapeDimCount = (int)ndarray.shape.dim_count;
            int[] shape = new int[shapeDimCount];
            for (int i = 0; i < shapeDimCount; i++)
            {
                shape[i] = (int)ndarray.shape.dims[i];
                size *= shape[i];
            }

            int elemShapeDimCount = (int)ndarray.elem_shape.dim_count;
            int[] elemShape = new int[elemShapeDimCount];
            for (int i = 0; i < elemShapeDimCount; i++)
            {
                elemShape[i] = (int)ndarray.elem_shape.dims[i];
                size *= elemShape[i];
            }

            Memory memory = new Memory(size, false, false,
                Taichi.Generated.TiMemoryUsageFlagBits.TI_MEMORY_USAGE_STORAGE_BIT, ndarray.memory);

            var rv = new NdArray<int>(shape, elemShape, memory);
            return rv;
        }

        public static NdArray<int> GetParticleNumBuffer()
        {
            var ndarray = new Taichi.Generated.TiNdArray();
            Ffi.S2GetBuffer(Singleton.Handle, S2BufferName.S2_BUFFER_NAME_PARTICLE_NUM, ref ndarray);
            return CreateNdArrayInt(ndarray);
        }

        public static NdArray<float> GetParticlePositionBuffer()
        {
            var ndarray = new Taichi.Generated.TiNdArray();
            Ffi.S2GetBuffer(Singleton.Handle, S2BufferName.S2_BUFFER_NAME_PARTICLE_POSITION, ref ndarray);
            return CreateNdArrayFloat(ndarray);
        }

        public static NdArray<float> GetParticleVelocityBuffer()
        {
            var ndarray = new Taichi.Generated.TiNdArray();
            Ffi.S2GetBuffer(Singleton.Handle, S2BufferName.S2_BUFFER_NAME_PARTICLE_VELOCITY, ref ndarray);
            return CreateNdArrayFloat(ndarray);
        }

        public static NdArray<int> GetParticleTagBuffer()
        {
            var ndarray = new Taichi.Generated.TiNdArray();
            Ffi.S2GetBuffer(Singleton.Handle, S2BufferName.S2_BUFFER_NAME_PARTICLE_TAG, ref ndarray);
            return CreateNdArrayInt(ndarray);
        }

        public static NdArray<int> GetParticleIdBuffer()
        {
            var ndarray = new Taichi.Generated.TiNdArray();
            Ffi.S2GetBuffer(Singleton.Handle, S2BufferName.S2_BUFFER_NAME_PARTICLE_ID, ref ndarray);
            return CreateNdArrayInt(ndarray);
        }

        public static void SetWorldExtent(Vector2 extent)
        {
            Ffi.S2SetWorldExtent(Singleton.Handle, new S2Vec2(extent.x, extent.y));
        }

        public static void SetWorldQueryEnabled(bool enable)
        {
            Ffi.S2SetWorldQueryEnabled(Singleton.Handle, Convert.ToUInt32(enable));
        }

        public static void SetSubstepTimeStep(float dt)
        {
            Ffi.S2SetSubstepTimestep(Singleton.Handle, dt);
        }

        public static void SetGravity(Vector2 gravity)
        {
            S2Vec2 v;
            v.x = gravity.x;
            v.y = gravity.y;
            Ffi.S2SetGravity(Singleton.Handle, v);
        }

        public static void SetWorldOffset(Vector2 offset)
        {
            S2Vec2 v;
            v.x = offset.x;
            v.y = offset.y;
            // FIXME: use async version to avoid colliders can not be properly removed bugs
            Ffi.S2SetWorldOffset(Singleton.Handle, v);
        }

        public static Vector2 GetWorldOffset()
        {
            S2WorldConfig config = Ffi.S2GetWorldConfig(Singleton.Handle);
            S2Vec2 offset = config.offset;
            Vector2 v = new Vector2();
            v.x = offset.x;
            v.y = offset.y;
            return v;
        }

        public static void AddForceFieldTransient(Vector2 force, Vector2 center, float radius)
        {
            S2Vec2 force_;
            force_.x = force.x;
            force_.y = force.y;
            S2Vec2 center_;
            center_.x = center.x;
            center_.y = center.y;
            Ffi.S2ApplyImpulseInCircularArea(Singleton.Handle, force_, center_, radius);
        }

        public static uint QueryParticleNumInTrigger(Trigger trigger)
        {
            return Ffi.S2QueryParticleNumInTrigger(trigger.Handle);
        }

        public static bool QueryTriggerOverlapped(Trigger trigger)
        {
            uint is_overlapped = Ffi.S2QueryTriggerOverlapped(trigger.Handle);
            return Convert.ToBoolean(is_overlapped);
        }

        public static bool QueryTriggerOverlappedByTag(Trigger trigger, uint tag, uint mask = 0xffffffff)
        {
            uint is_overlapped = Ffi.S2QueryTriggerOverlappedByTag(trigger.Handle, tag, mask);
            return Convert.ToBoolean(is_overlapped);
        }

        public static uint QueryParticleNumInTriggerByTag(Trigger trigger, uint tag, uint mask = 0xffffffff)
        {
            return Ffi.S2QueryParticleNumInTriggerByTag(trigger.Handle, tag, mask);
        }

        public static void RemoveParticlesInTrigger(Trigger trigger)
        {
            Ffi.S2RemoveParticlesInTriggerAsync(trigger.Handle);
        }

        public static void RemoveParticlesInTriggerByTag(Trigger trigger, uint tag, uint mask = 0xffffffff)
        {
            Ffi.S2RemoveParticlesInTriggerByTag(trigger.Handle, tag, mask);
        }

        public static NdArray<int> GetGridColliderNumFineBuffer()
        {
            var ndArray = new Taichi.Generated.TiNdArray();
            Ffi.S2GetBuffer(Singleton.Handle, S2BufferName.S2_BUFFER_NAME_FINE_GRID_COLLIDER_NUM, ref ndArray);
            return CreateNdArrayInt(ndArray);
        }

        public static NdArray<int> GetGridTriggerIdFineBuffer()
        {
            var ndArray = new Taichi.Generated.TiNdArray();
            Ffi.S2GetBuffer(Singleton.Handle, S2BufferName.S2_BUFFER_NAME_FINE_GRID_TRIGGER_ID, ref ndArray);
            return CreateNdArrayInt(ndArray);
        }

        public static Vector2Int GetWorldGridResolution()
        {
            var res = Ffi.S2GetWorldGridResolution(Singleton.Handle);
            Vector2Int vi = new Vector2Int(res.x, res.y);
            return vi;
        }

        public static Vector2Int GetWorldFineGridResolution()
        {
            var res = Ffi.S2GetWorldGridResolution(Singleton.Handle);
            uint fine_grid_scale = Ffi.S2GetWorldConfig(Singleton.Handle).fine_grid_scale;
            Vector2Int vi = new Vector2Int(res.x * (int)fine_grid_scale, res.y * (int)fine_grid_scale);
            return vi;
        }

        public static uint GetWorldMaxParticleNum()
        {
            var config = Ffi.S2GetWorldConfig(Singleton.Handle);
            return config.max_allowed_particle_num;
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

                Ffi.S2XDestoryWorldAsyncUnity(Singleton.Handle);
                disposedValue = true;
            }
        }

        ~World()
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
