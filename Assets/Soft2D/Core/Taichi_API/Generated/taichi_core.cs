using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Taichi.Generated {

// alias.bool


// definition.false
static partial class Def {
public const uint TI_FALSE = 0;
}

// definition.true
static partial class Def {
public const uint TI_TRUE = 1;
}

// alias.flags
// using TiFlags = uint;

// definition.null_handle
static partial class Def {
public const uint TI_NULL_HANDLE = 0;
}

// handle.runtime
[StructLayout(LayoutKind.Sequential)]
public struct TiRuntime {
  public IntPtr Inner;
}

// handle.aot_module
[StructLayout(LayoutKind.Sequential)]
public struct TiAotModule {
  public IntPtr Inner;
}

// handle.memory
[StructLayout(LayoutKind.Sequential)]
public struct TiMemory {
  public IntPtr Inner;
}

// handle.image
[StructLayout(LayoutKind.Sequential)]
public struct TiImage {
  public IntPtr Inner;
}

// handle.sampler
[StructLayout(LayoutKind.Sequential)]
public struct TiSampler {
  public IntPtr Inner;
}

// handle.kernel
[StructLayout(LayoutKind.Sequential)]
public struct TiKernel {
  public IntPtr Inner;
}

// handle.compute_graph
[StructLayout(LayoutKind.Sequential)]
public struct TiComputeGraph {
  public IntPtr Inner;
}

// enumeration.error
public enum TiError {
  TI_ERROR_SUCCESS = 0,
  TI_ERROR_NOT_SUPPORTED = -1,
  TI_ERROR_CORRUPTED_DATA = -2,
  TI_ERROR_NAME_NOT_FOUND = -3,
  TI_ERROR_INVALID_ARGUMENT = -4,
  TI_ERROR_ARGUMENT_NULL = -5,
  TI_ERROR_ARGUMENT_OUT_OF_RANGE = -6,
  TI_ERROR_ARGUMENT_NOT_FOUND = -7,
  TI_ERROR_INVALID_INTEROP = -8,
  TI_ERROR_INVALID_STATE = -9,
  TI_ERROR_INCOMPATIBLE_MODULE = -10,
  TI_ERROR_OUT_OF_MEMORY = -11,
  TI_ERROR_MAX_ENUM = 0x7fffffff,
}

// enumeration.arch
public enum TiArch {
  TI_ARCH_RESERVED = 0,
  TI_ARCH_VULKAN = 1,
  TI_ARCH_METAL = 2,
  TI_ARCH_CUDA = 3,
  TI_ARCH_X64 = 4,
  TI_ARCH_ARM64 = 5,
  TI_ARCH_OPENGL = 6,
  TI_ARCH_GLES = 7,
  TI_ARCH_MAX_ENUM = 0x7fffffff,
}

// enumeration.capability
public enum TiCapability {
  TI_CAPABILITY_RESERVED = 0,
  TI_CAPABILITY_SPIRV_VERSION = 1,
  TI_CAPABILITY_SPIRV_HAS_INT8 = 2,
  TI_CAPABILITY_SPIRV_HAS_INT16 = 3,
  TI_CAPABILITY_SPIRV_HAS_INT64 = 4,
  TI_CAPABILITY_SPIRV_HAS_FLOAT16 = 5,
  TI_CAPABILITY_SPIRV_HAS_FLOAT64 = 6,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_INT64 = 7,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT16 = 8,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT16_ADD = 9,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT16_MINMAX = 10,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT = 11,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT_ADD = 12,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT_MINMAX = 13,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT64 = 14,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT64_ADD = 15,
  TI_CAPABILITY_SPIRV_HAS_ATOMIC_FLOAT64_MINMAX = 16,
  TI_CAPABILITY_SPIRV_HAS_VARIABLE_PTR = 17,
  TI_CAPABILITY_SPIRV_HAS_PHYSICAL_STORAGE_BUFFER = 18,
  TI_CAPABILITY_SPIRV_HAS_SUBGROUP_BASIC = 19,
  TI_CAPABILITY_SPIRV_HAS_SUBGROUP_VOTE = 20,
  TI_CAPABILITY_SPIRV_HAS_SUBGROUP_ARITHMETIC = 21,
  TI_CAPABILITY_SPIRV_HAS_SUBGROUP_BALLOT = 22,
  TI_CAPABILITY_SPIRV_HAS_NON_SEMANTIC_INFO = 23,
  TI_CAPABILITY_SPIRV_HAS_NO_INTEGER_WRAP_DECORATION = 24,
  TI_CAPABILITY_MAX_ENUM = 0x7fffffff,
}

// structure.capability_level_info
[StructLayout(LayoutKind.Sequential)]
public struct TiCapabilityLevelInfo {
  public TiCapability capability;
  public uint level;
}

// enumeration.data_type
public enum TiDataType {
  TI_DATA_TYPE_F16 = 0,
  TI_DATA_TYPE_F32 = 1,
  TI_DATA_TYPE_F64 = 2,
  TI_DATA_TYPE_I8 = 3,
  TI_DATA_TYPE_I16 = 4,
  TI_DATA_TYPE_I32 = 5,
  TI_DATA_TYPE_I64 = 6,
  TI_DATA_TYPE_U1 = 7,
  TI_DATA_TYPE_U8 = 8,
  TI_DATA_TYPE_U16 = 9,
  TI_DATA_TYPE_U32 = 10,
  TI_DATA_TYPE_U64 = 11,
  TI_DATA_TYPE_GEN = 12,
  TI_DATA_TYPE_UNKNOWN = 13,
  TI_DATA_TYPE_MAX_ENUM = 0x7fffffff,
}

// enumeration.argument_type
public enum TiArgumentType {
  TI_ARGUMENT_TYPE_I32 = 0,
  TI_ARGUMENT_TYPE_F32 = 1,
  TI_ARGUMENT_TYPE_NDARRAY = 2,
  TI_ARGUMENT_TYPE_TEXTURE = 3,
  TI_ARGUMENT_TYPE_SCALAR = 4,
  TI_ARGUMENT_TYPE_MAX_ENUM = 0x7fffffff,
}

// bit_field.memory_usage
[Flags]
public enum TiMemoryUsageFlagBits {
  TI_MEMORY_USAGE_STORAGE_BIT = 1 << 0,
  TI_MEMORY_USAGE_UNIFORM_BIT = 1 << 1,
  TI_MEMORY_USAGE_VERTEX_BIT = 1 << 2,
  TI_MEMORY_USAGE_INDEX_BIT = 1 << 3,
};

// structure.memory_allocate_info
[StructLayout(LayoutKind.Sequential)]
public struct TiMemoryAllocateInfo {
  public ulong size;
  public uint host_write;
  public uint host_read;
  public uint export_sharing;
  public TiMemoryUsageFlagBits usage;
}

// structure.memory_slice
[StructLayout(LayoutKind.Sequential)]
public struct TiMemorySlice {
  public TiMemory memory;
  public ulong offset;
  public ulong size;
}

// structure.nd_shape
[StructLayout(LayoutKind.Sequential)]
public struct TiNdShape {
  public uint dim_count;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst=16)] public uint[] dims;
}

// structure.nd_array
[StructLayout(LayoutKind.Sequential)]
public struct TiNdArray {
  public TiMemory memory;
  public TiNdShape shape;
  public TiNdShape elem_shape;
  public TiDataType elem_type;
}

// bit_field.image_usage
[Flags]
public enum TiImageUsageFlagBits {
  TI_IMAGE_USAGE_STORAGE_BIT = 1 << 0,
  TI_IMAGE_USAGE_SAMPLED_BIT = 1 << 1,
  TI_IMAGE_USAGE_ATTACHMENT_BIT = 1 << 2,
};

// enumeration.image_dimension
public enum TiImageDimension {
  TI_IMAGE_DIMENSION_1D = 0,
  TI_IMAGE_DIMENSION_2D = 1,
  TI_IMAGE_DIMENSION_3D = 2,
  TI_IMAGE_DIMENSION_1D_ARRAY = 3,
  TI_IMAGE_DIMENSION_2D_ARRAY = 4,
  TI_IMAGE_DIMENSION_CUBE = 5,
  TI_IMAGE_DIMENSION_MAX_ENUM = 0x7fffffff,
}

// enumeration.image_layout
public enum TiImageLayout {
  TI_IMAGE_LAYOUT_UNDEFINED = 0,
  TI_IMAGE_LAYOUT_SHADER_READ = 1,
  TI_IMAGE_LAYOUT_SHADER_WRITE = 2,
  TI_IMAGE_LAYOUT_SHADER_READ_WRITE = 3,
  TI_IMAGE_LAYOUT_COLOR_ATTACHMENT = 4,
  TI_IMAGE_LAYOUT_COLOR_ATTACHMENT_READ = 5,
  TI_IMAGE_LAYOUT_DEPTH_ATTACHMENT = 6,
  TI_IMAGE_LAYOUT_DEPTH_ATTACHMENT_READ = 7,
  TI_IMAGE_LAYOUT_TRANSFER_DST = 8,
  TI_IMAGE_LAYOUT_TRANSFER_SRC = 9,
  TI_IMAGE_LAYOUT_PRESENT_SRC = 10,
  TI_IMAGE_LAYOUT_MAX_ENUM = 0x7fffffff,
}

// enumeration.format
public enum TiFormat {
  TI_FORMAT_UNKNOWN = 0,
  TI_FORMAT_R8 = 1,
  TI_FORMAT_RG8 = 2,
  TI_FORMAT_RGBA8 = 3,
  TI_FORMAT_RGBA8SRGB = 4,
  TI_FORMAT_BGRA8 = 5,
  TI_FORMAT_BGRA8SRGB = 6,
  TI_FORMAT_R8U = 7,
  TI_FORMAT_RG8U = 8,
  TI_FORMAT_RGBA8U = 9,
  TI_FORMAT_R8I = 10,
  TI_FORMAT_RG8I = 11,
  TI_FORMAT_RGBA8I = 12,
  TI_FORMAT_R16 = 13,
  TI_FORMAT_RG16 = 14,
  TI_FORMAT_RGB16 = 15,
  TI_FORMAT_RGBA16 = 16,
  TI_FORMAT_R16U = 17,
  TI_FORMAT_RG16U = 18,
  TI_FORMAT_RGB16U = 19,
  TI_FORMAT_RGBA16U = 20,
  TI_FORMAT_R16I = 21,
  TI_FORMAT_RG16I = 22,
  TI_FORMAT_RGB16I = 23,
  TI_FORMAT_RGBA16I = 24,
  TI_FORMAT_R16F = 25,
  TI_FORMAT_RG16F = 26,
  TI_FORMAT_RGB16F = 27,
  TI_FORMAT_RGBA16F = 28,
  TI_FORMAT_R32U = 29,
  TI_FORMAT_RG32U = 30,
  TI_FORMAT_RGB32U = 31,
  TI_FORMAT_RGBA32U = 32,
  TI_FORMAT_R32I = 33,
  TI_FORMAT_RG32I = 34,
  TI_FORMAT_RGB32I = 35,
  TI_FORMAT_RGBA32I = 36,
  TI_FORMAT_R32F = 37,
  TI_FORMAT_RG32F = 38,
  TI_FORMAT_RGB32F = 39,
  TI_FORMAT_RGBA32F = 40,
  TI_FORMAT_DEPTH16 = 41,
  TI_FORMAT_DEPTH24STENCIL8 = 42,
  TI_FORMAT_DEPTH32F = 43,
  TI_FORMAT_MAX_ENUM = 0x7fffffff,
}

// structure.image_offset
[StructLayout(LayoutKind.Sequential)]
public struct TiImageOffset {
  public uint x;
  public uint y;
  public uint z;
  public uint array_layer_offset;
}

// structure.image_extent
[StructLayout(LayoutKind.Sequential)]
public struct TiImageExtent {
  public uint width;
  public uint height;
  public uint depth;
  public uint array_layer_count;
}

// structure.image_allocate_info
[StructLayout(LayoutKind.Sequential)]
public struct TiImageAllocateInfo {
  public TiImageDimension dimension;
  public TiImageExtent extent;
  public uint mip_level_count;
  public TiFormat format;
  public uint export_sharing;
  public TiImageUsageFlagBits usage;
}

// structure.image_slice
[StructLayout(LayoutKind.Sequential)]
public struct TiImageSlice {
  public TiImage image;
  public TiImageOffset offset;
  public TiImageExtent extent;
  public uint mip_level;
}

// enumeration.filter
public enum TiFilter {
  TI_FILTER_NEAREST = 0,
  TI_FILTER_LINEAR = 1,
  TI_FILTER_MAX_ENUM = 0x7fffffff,
}

// enumeration.address_mode
public enum TiAddressMode {
  TI_ADDRESS_MODE_REPEAT = 0,
  TI_ADDRESS_MODE_MIRRORED_REPEAT = 1,
  TI_ADDRESS_MODE_CLAMP_TO_EDGE = 2,
  TI_ADDRESS_MODE_MAX_ENUM = 0x7fffffff,
}

// structure.sampler_create_info
[StructLayout(LayoutKind.Sequential)]
public struct TiSamplerCreateInfo {
  public TiFilter mag_filter;
  public TiFilter min_filter;
  public TiAddressMode address_mode;
  public float max_anisotropy;
}

// structure.texture
[StructLayout(LayoutKind.Sequential)]
public struct TiTexture {
  public TiImage image;
  public TiSampler sampler;
  public TiImageDimension dimension;
  public TiImageExtent extent;
  public TiFormat format;
}

// union.scalar_value
[StructLayout(LayoutKind.Explicit)]
public struct TiScalarValue {
  [FieldOffset(0)] public byte x8;
  [FieldOffset(0)] public ushort x16;
  [FieldOffset(0)] public uint x32;
  [FieldOffset(0)] public ulong x64;
}

// structure.scalar
[StructLayout(LayoutKind.Sequential)]
public struct TiScalar {
  public TiDataType type;
  public TiScalarValue value;
}

// union.argument_value
[StructLayout(LayoutKind.Explicit)]
public struct TiArgumentValue {
  [FieldOffset(0)] public int i32;
  [FieldOffset(0)] public float f32;
  [FieldOffset(0)] public TiNdArray ndarray;
  [FieldOffset(0)] public TiTexture texture;
  [FieldOffset(0)] public TiScalar scalar;
}

// structure.argument
[StructLayout(LayoutKind.Sequential)]
public struct TiArgument {
  public TiArgumentType type;
  public TiArgumentValue value;
}

// structure.named_argument
[StructLayout(LayoutKind.Sequential)]
public struct TiNamedArgument {
  public string name;
  public TiArgument argument;
}

// function.get_version
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern uint ti_get_version(

);
public static uint TiGetVersion(

) {
  var rv = ti_get_version(
  );
  return rv;
}
}

// function.get_available_archs
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_get_available_archs(
  [MarshalAs(UnmanagedType.LPArray)] [In, Out] uint[] arch_count,
  [MarshalAs(UnmanagedType.LPArray)] TiArch[] archs
);
public static void TiGetAvailableArchs(
  uint arch_count,
  TiArch[] archs
) {
  var arr_arch_count = new uint[1];
  arr_arch_count[0] = arch_count;
  ti_get_available_archs(
    arr_arch_count,
    archs
  );
  arch_count = arr_arch_count[0];
}
}

// function.get_last_error
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiError ti_get_last_error(
  [MarshalAs(UnmanagedType.LPArray)] [In, Out] ulong[] message_size,
  [MarshalAs(UnmanagedType.LPArray)] [In, Out] byte[] message
);
public static TiError TiGetLastError(
  ulong message_size,
  byte[] message
) {
  var arr_message_size = new ulong[1];
  arr_message_size[0] = message_size;
  var rv = ti_get_last_error(
    arr_message_size,
    message
  );
  message_size = arr_message_size[0];
  return rv;
}
}

// function.set_last_error
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_set_last_error(
  TiError error,
  string message
);
public static void TiSetLastError(
  TiError error,
  string message
) {
  ti_set_last_error(
    error,
    message
  );
}
}

// function.create_runtime
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiRuntime ti_create_runtime(
  TiArch arch,
  uint device_index
);
public static TiRuntime TiCreateRuntime(
  TiArch arch,
  uint device_index
) {
  var rv = ti_create_runtime(
    arch,
    device_index
  );
  return rv;
}
}

// function.destroy_runtime
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_destroy_runtime(
  TiRuntime runtime
);
public static void TiDestroyRuntime(
  TiRuntime runtime
) {
  ti_destroy_runtime(
    runtime
  );
}
}

// function.set_runtime_capabilities
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_set_runtime_capabilities_ext(
  TiRuntime runtime,
  uint capability_count,
  [MarshalAs(UnmanagedType.LPArray)] TiCapabilityLevelInfo[] capabilities
);
public static void TiSetRuntimeCapabilitiesExt(
  TiRuntime runtime,
  uint capability_count,
  TiCapabilityLevelInfo[] capabilities
) {
  ti_set_runtime_capabilities_ext(
    runtime,
    capability_count,
    capabilities
  );
}
}

// function.get_runtime_capabilities
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_get_runtime_capabilities(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] [In, Out] uint[] capability_count,
  [MarshalAs(UnmanagedType.LPArray)] TiCapabilityLevelInfo[] capabilities
);
public static void TiGetRuntimeCapabilities(
  TiRuntime runtime,
  uint capability_count,
  TiCapabilityLevelInfo[] capabilities
) {
  var arr_capability_count = new uint[1];
  arr_capability_count[0] = capability_count;
  ti_get_runtime_capabilities(
    runtime,
    arr_capability_count,
    capabilities
  );
  capability_count = arr_capability_count[0];
}
}

// function.allocate_memory
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiMemory ti_allocate_memory(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemoryAllocateInfo[] allocate_info
);
public static TiMemory TiAllocateMemory(
  TiRuntime runtime,
  TiMemoryAllocateInfo allocate_info
) {
  var arr_allocate_info = new TiMemoryAllocateInfo[1];
  arr_allocate_info[0] = allocate_info;
  var rv = ti_allocate_memory(
    runtime,
    arr_allocate_info
  );
  return rv;
}
}

// function.free_memory
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_free_memory(
  TiRuntime runtime,
  TiMemory memory
);
public static void TiFreeMemory(
  TiRuntime runtime,
  TiMemory memory
) {
  ti_free_memory(
    runtime,
    memory
  );
}
}

// function.map_memory
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern IntPtr ti_map_memory(
  TiRuntime runtime,
  TiMemory memory
);
public static IntPtr TiMapMemory(
  TiRuntime runtime,
  TiMemory memory
) {
  var rv = ti_map_memory(
    runtime,
    memory
  );
  return rv;
}
}

// function.unmap_memory
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_unmap_memory(
  TiRuntime runtime,
  TiMemory memory
);
public static void TiUnmapMemory(
  TiRuntime runtime,
  TiMemory memory
) {
  ti_unmap_memory(
    runtime,
    memory
  );
}
}

// function.allocate_image
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiImage ti_allocate_image(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiImageAllocateInfo[] allocate_info
);
public static TiImage TiAllocateImage(
  TiRuntime runtime,
  TiImageAllocateInfo allocate_info
) {
  var arr_allocate_info = new TiImageAllocateInfo[1];
  arr_allocate_info[0] = allocate_info;
  var rv = ti_allocate_image(
    runtime,
    arr_allocate_info
  );
  return rv;
}
}

// function.free_image
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_free_image(
  TiRuntime runtime,
  TiImage image
);
public static void TiFreeImage(
  TiRuntime runtime,
  TiImage image
) {
  ti_free_image(
    runtime,
    image
  );
}
}

// function.create_sampler
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiSampler ti_create_sampler(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiSamplerCreateInfo[] create_info
);
public static TiSampler TiCreateSampler(
  TiRuntime runtime,
  TiSamplerCreateInfo create_info
) {
  var arr_create_info = new TiSamplerCreateInfo[1];
  arr_create_info[0] = create_info;
  var rv = ti_create_sampler(
    runtime,
    arr_create_info
  );
  return rv;
}
}

// function.destroy_sampler
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_destroy_sampler(
  TiRuntime runtime,
  TiSampler sampler
);
public static void TiDestroySampler(
  TiRuntime runtime,
  TiSampler sampler
) {
  ti_destroy_sampler(
    runtime,
    sampler
  );
}
}

// function.copy_memory_device_to_device
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_copy_memory_device_to_device(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] dst_memory,
  [MarshalAs(UnmanagedType.LPArray)] TiMemorySlice[] src_memory
);
public static void TiCopyMemoryDeviceToDevice(
  TiRuntime runtime,
  TiMemorySlice dst_memory,
  TiMemorySlice src_memory
) {
  var arr_dst_memory = new TiMemorySlice[1];
  arr_dst_memory[0] = dst_memory;
  var arr_src_memory = new TiMemorySlice[1];
  arr_src_memory[0] = src_memory;
  ti_copy_memory_device_to_device(
    runtime,
    arr_dst_memory,
    arr_src_memory
  );
}
}

// function.copy_image_device_to_device
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_copy_image_device_to_device(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] TiImageSlice[] dst_image,
  [MarshalAs(UnmanagedType.LPArray)] TiImageSlice[] src_image
);
public static void TiCopyImageDeviceToDevice(
  TiRuntime runtime,
  TiImageSlice dst_image,
  TiImageSlice src_image
) {
  var arr_dst_image = new TiImageSlice[1];
  arr_dst_image[0] = dst_image;
  var arr_src_image = new TiImageSlice[1];
  arr_src_image[0] = src_image;
  ti_copy_image_device_to_device(
    runtime,
    arr_dst_image,
    arr_src_image
  );
}
}

// function.track_image
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_track_image_ext(
  TiRuntime runtime,
  TiImage image,
  TiImageLayout layout
);
public static void TiTrackImageExt(
  TiRuntime runtime,
  TiImage image,
  TiImageLayout layout
) {
  ti_track_image_ext(
    runtime,
    image,
    layout
  );
}
}

// function.transition_image
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_transition_image(
  TiRuntime runtime,
  TiImage image,
  TiImageLayout layout
);
public static void TiTransitionImage(
  TiRuntime runtime,
  TiImage image,
  TiImageLayout layout
) {
  ti_transition_image(
    runtime,
    image,
    layout
  );
}
}

// function.launch_kernel
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_launch_kernel(
  TiRuntime runtime,
  TiKernel kernel,
  uint arg_count,
  [MarshalAs(UnmanagedType.LPArray)] TiArgument[] args
);
public static void TiLaunchKernel(
  TiRuntime runtime,
  TiKernel kernel,
  uint arg_count,
  TiArgument[] args
) {
  ti_launch_kernel(
    runtime,
    kernel,
    arg_count,
    args
  );
}
}

// function.launch_compute_graph
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_launch_compute_graph(
  TiRuntime runtime,
  TiComputeGraph compute_graph,
  uint arg_count,
  [MarshalAs(UnmanagedType.LPArray)] TiNamedArgument[] args
);
public static void TiLaunchComputeGraph(
  TiRuntime runtime,
  TiComputeGraph compute_graph,
  uint arg_count,
  TiNamedArgument[] args
) {
  ti_launch_compute_graph(
    runtime,
    compute_graph,
    arg_count,
    args
  );
}
}

// function.flush
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_flush(
  TiRuntime runtime
);
public static void TiFlush(
  TiRuntime runtime
) {
  ti_flush(
    runtime
  );
}
}

// function.wait
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_wait(
  TiRuntime runtime
);
public static void TiWait(
  TiRuntime runtime
) {
  ti_wait(
    runtime
  );
}
}

// function.load_aot_module
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_load_aot_module(
  TiRuntime runtime,
  string module_path
);
public static TiAotModule TiLoadAotModule(
  TiRuntime runtime,
  string module_path
) {
  var rv = ti_load_aot_module(
    runtime,
    module_path
  );
  return rv;
}
}

// function.create_aot_module
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] byte[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  byte[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  sbyte[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] short[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  short[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  ushort[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] int[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  int[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] uint[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  uint[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] long[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  long[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  ulong[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  IntPtr[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] float[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  float[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiAotModule ti_create_aot_module(
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] double[] tcm,
  ulong size
);
public static TiAotModule TiCreateAotModule(
  TiRuntime runtime,
  double[] tcm,
  ulong size
) {
  var rv = ti_create_aot_module(
    runtime,
    tcm,
    size
  );
  return rv;
}
}

// function.destroy_aot_module
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern void ti_destroy_aot_module(
  TiAotModule aot_module
);
public static void TiDestroyAotModule(
  TiAotModule aot_module
) {
  ti_destroy_aot_module(
    aot_module
  );
}
}

// function.get_aot_module_kernel
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiKernel ti_get_aot_module_kernel(
  TiAotModule aot_module,
  string name
);
public static TiKernel TiGetAotModuleKernel(
  TiAotModule aot_module,
  string name
) {
  var rv = ti_get_aot_module_kernel(
    aot_module,
    name
  );
  return rv;
}
}

// function.get_aot_module_compute_graph
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("taichi_c_api")]
#endif
private static extern TiComputeGraph ti_get_aot_module_compute_graph(
  TiAotModule aot_module,
  string name
);
public static TiComputeGraph TiGetAotModuleComputeGraph(
  TiAotModule aot_module,
  string name
) {
  var rv = ti_get_aot_module_compute_graph(
    aot_module,
    name
  );
  return rv;
}
}

} // namespace Taichi.Generated
