using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Taichi.Generated;

namespace Taichi.Soft2D.Generated {

// function.create_world_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d_unity")]
#endif
private static extern S2World s2x_create_world_async_unity(
  TiArch arch,
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] S2WorldConfig[] config
);
public static S2World S2XCreateWorldAsyncUnity(
  TiArch arch,
  TiRuntime runtime,
  S2WorldConfig config
) {
  var arr_config = new S2WorldConfig[1];
  arr_config[0] = config;
  var rv = s2x_create_world_async_unity(
    arch,
    runtime,
    arr_config
  );
  return rv;
}
}

// function.destory_world_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d_unity")]
#endif
private static extern void s2x_destory_world_async_unity(
  S2World world
);
public static void S2XDestoryWorldAsyncUnity(
  S2World world
) {
  s2x_destory_world_async_unity(
    world
  );
}
}

// function.step_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d_unity")]
#endif
private static extern void s2x_step_async_unity(
  S2World world,
  float delta_time
);
public static void S2XStepAsyncUnity(
  S2World world,
  float delta_time
) {
  s2x_step_async_unity(
    world,
    delta_time
  );
}
}

// function.remove_particles_in_trigger_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_remove_particles_in_trigger_async(
  S2Trigger trigger
);
public static void S2RemoveParticlesInTriggerAsync(
  S2Trigger trigger
) {
  s2_remove_particles_in_trigger_async(
    trigger
  );
}
}

// function.manipulate_particles_in_trigger_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d_unity")]
#endif
private static extern void s2x_manipulate_particles_in_trigger_async_unity(
  S2Trigger trigger,
  S2ParticleManipulationCallback callback
);
public static void S2XManipulateParticlesInTriggerAsyncUnity(
  S2Trigger trigger,
  S2ParticleManipulationCallback callback
) {
  s2x_manipulate_particles_in_trigger_async_unity(
    trigger,
    callback
  );
}
}

} // namespace Soft2D.Generated
