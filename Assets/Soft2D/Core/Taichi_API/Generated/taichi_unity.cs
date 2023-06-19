using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Taichi.Generated {

// handle.native_buffer
[StructLayout(LayoutKind.Sequential)]
public struct TixNativeBufferUnity {
  public IntPtr Inner;
}

// callback.async_task
[StructLayout(LayoutKind.Sequential)]
public struct TixAsyncTaskUnity {
  public IntPtr Inner;
}

// function.import_native_runtime
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern TiRuntime tix_import_native_runtime_unity(

);
public static TiRuntime TixImportNativeRuntimeUnity(

) {
  var rv = tix_import_native_runtime_unity(
  );
  return rv;
}
}

// function.enqueue_task_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] byte[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  byte[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  sbyte[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] short[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  short[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] ushort[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  ushort[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] int[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  int[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] uint[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  uint[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] long[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  long[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] ulong[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  ulong[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  IntPtr[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] float[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  float[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_enqueue_task_async_unity(
  [MarshalAs(UnmanagedType.LPArray)] double[] user_data,
  TixAsyncTaskUnity async_task
);
public static void TixEnqueueTaskAsyncUnity(
  double[] user_data,
  TixAsyncTaskUnity async_task
) {
  tix_enqueue_task_async_unity(
    user_data,
    async_task
  );
}
}

// function.launch_kernel_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_launch_kernel_async_unity(
  TiRuntime runtime,
  TiKernel kernel,
  uint arg_count,
  [MarshalAs(UnmanagedType.LPArray)] TiArgument[] args
);
public static void TixLaunchKernelAsyncUnity(
  TiRuntime runtime,
  TiKernel kernel,
  uint arg_count,
  TiArgument[] args
) {
  tix_launch_kernel_async_unity(
    runtime,
    kernel,
    arg_count,
    args
  );
}
}

// function.launch_compute_graph_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_launch_compute_graph_async_unity(
  TiRuntime runtime,
  TiComputeGraph compute_graph,
  uint arg_count,
  [MarshalAs(UnmanagedType.LPArray)] TiNamedArgument[] args
);
public static void TixLaunchComputeGraphAsyncUnity(
  TiRuntime runtime,
  TiComputeGraph compute_graph,
  uint arg_count,
  TiNamedArgument[] args
) {
  tix_launch_compute_graph_async_unity(
    runtime,
    compute_graph,
    arg_count,
    args
  );
}
}

// function.copy_memory_to_native_buffer_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_to_native_buffer_async_unity(
  TiRuntime runtime,
  TixNativeBufferUnity dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryToNativeBufferAsyncUnity(
  TiRuntime runtime,
  TixNativeBufferUnity dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_to_native_buffer_async_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}

// function.copy_memory_device_to_host
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] byte[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  byte[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  sbyte[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] short[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  short[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  ushort[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] int[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  int[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] uint[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  uint[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] long[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  long[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  ulong[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  IntPtr[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] float[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  float[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_device_to_host_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] double[] dst,
  ulong dst_offset,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src
);
public static void TixCopyMemoryDeviceToHostUnity(
  TiRuntime runtime,
  double[] dst,
  ulong dst_offset,
  TiMemorySlice src
) {
  var arr_src = new TiMemorySlice[1];
  arr_src[0] = src;
  tix_copy_memory_device_to_host_unity(
    runtime,
    dst,
    dst_offset,
    arr_src
  );
}
}

// function.copy_memory_host_to_device
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] byte[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  byte[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  sbyte[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] short[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  short[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  ushort[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] int[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  int[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] uint[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  uint[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] long[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  long[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  ulong[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  IntPtr[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] float[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  float[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern void tix_copy_memory_host_to_device_unity(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst,
  [MarshalAs(UnmanagedType.LPArray)] double[] src,
  ulong src_offset
);
public static void TixCopyMemoryHostToDeviceUnity(
  TiRuntime runtime,
  TiMemorySlice dst,
  double[] src,
  ulong src_offset
) {
  var arr_dst = new TiMemorySlice[1];
  arr_dst[0] = dst;
  tix_copy_memory_host_to_device_unity(
    runtime,
    arr_dst,
    src,
    src_offset
  );
}
}

// function.submit_async
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_unity")]
#endif
private static extern IntPtr tix_submit_async_unity(
  TiRuntime runtime
);
public static IntPtr TixSubmitAsyncUnity(
  TiRuntime runtime
) {
  var rv = tix_submit_async_unity(
    runtime
  );
  return rv;
}
}

} // namespace Taichi.Generated
