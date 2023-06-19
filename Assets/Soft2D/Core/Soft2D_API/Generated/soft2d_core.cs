using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Taichi.Generated;

namespace Taichi.Soft2D.Generated {

// alias.bool


// definition.false
static partial class Def {
public const uint S2_FALSE = 0;
}

// definition.true
static partial class Def {
public const uint S2_TRUE = 1;
}

// alias.flags
// using S2Flags = uint;

// definition.null_handle
static partial class Def {
public const uint S2_NULL_HANDLE = 0;
}

// handle.world
[StructLayout(LayoutKind.Sequential)]
public struct S2World {
  public IntPtr Inner;
}

// handle.body
[StructLayout(LayoutKind.Sequential)]
public struct S2Body {
  public IntPtr Inner;
}

// handle.collider
[StructLayout(LayoutKind.Sequential)]
public struct S2Collider {
  public IntPtr Inner;
}

// handle.trigger
[StructLayout(LayoutKind.Sequential)]
public struct S2Trigger {
  public IntPtr Inner;
}

// structure.vec2
[StructLayout(LayoutKind.Sequential)]
public struct S2Vec2 {
  public float x;
  public float y;
  public S2Vec2(float x, float y) {
    this.x = x;
    this.y = y;
  }
  public S2Vec2(S2Vec2 instance) {
    this.x = instance.x;
    this.y = instance.y;
  }
}

// structure.vec2i
[StructLayout(LayoutKind.Sequential)]
public struct S2Vec2I {
  public int x;
  public int y;
  public S2Vec2I(int x, int y) {
    this.x = x;
    this.y = y;
  }
  public S2Vec2I(S2Vec2I instance) {
    this.x = instance.x;
    this.y = instance.y;
  }
}

// enumeration.material_type
public enum S2MaterialType {
  S2_MATERIAL_TYPE_FLUID = 0,
  S2_MATERIAL_TYPE_ELASTIC = 1,
  S2_MATERIAL_TYPE_SNOW = 2,
  S2_MATERIAL_TYPE_SAND = 3,
  S2_MATERIAL_TYPE_MAX_ENUM = 0x7fffffff,
}

// structure.material
[StructLayout(LayoutKind.Sequential)]
public struct S2Material {
  public S2MaterialType type;
  public float density;
  public float youngs_modulus;
  public float poissons_ratio;
  public S2Material(S2MaterialType type, float density, float youngs_modulus, float poissons_ratio) {
    this.type = type;
    this.density = density;
    this.youngs_modulus = youngs_modulus;
    this.poissons_ratio = poissons_ratio;
  }
  public S2Material(S2Material instance) {
    this.type = instance.type;
    this.density = instance.density;
    this.youngs_modulus = instance.youngs_modulus;
    this.poissons_ratio = instance.poissons_ratio;
  }
}

// enumeration.mobility
public enum S2Mobility {
  S2_MOBILITY_STATIC = 0,
  S2_MOBILITY_KINEMATIC = 1,
  S2_MOBILITY_DYNAMIC = 2,
  S2_MOBILITY_MAX_ENUM = 0x7fffffff,
}

// structure.kinematics
[StructLayout(LayoutKind.Sequential)]
public struct S2Kinematics {
  public S2Vec2 center;
  public float rotation;
  public S2Vec2 linear_velocity;
  public float angular_velocity;
  public S2Mobility mobility;
  public S2Kinematics(S2Vec2 center, float rotation, S2Vec2 linear_velocity, float angular_velocity, S2Mobility mobility) {
    this.center = center;
    this.rotation = rotation;
    this.linear_velocity = linear_velocity;
    this.angular_velocity = angular_velocity;
    this.mobility = mobility;
  }
  public S2Kinematics(S2Kinematics instance) {
    this.center = instance.center;
    this.rotation = instance.rotation;
    this.linear_velocity = instance.linear_velocity;
    this.angular_velocity = instance.angular_velocity;
    this.mobility = instance.mobility;
  }
}

// enumeration.shape_type
public enum S2ShapeType {
  S2_SHAPE_TYPE_BOX = 0,
  S2_SHAPE_TYPE_CIRCLE = 1,
  S2_SHAPE_TYPE_ELLIPSE = 2,
  S2_SHAPE_TYPE_CAPSULE = 3,
  S2_SHAPE_TYPE_POLYGON = 4,
  S2_SHAPE_TYPE_MAX_ENUM = 0x7fffffff,
}

// structure.box_shape
[StructLayout(LayoutKind.Sequential)]
public struct S2BoxShape {
  public S2Vec2 half_extent;
  public S2BoxShape(S2Vec2 half_extent) {
    this.half_extent = half_extent;
  }
  public S2BoxShape(S2BoxShape instance) {
    this.half_extent = instance.half_extent;
  }
}

// structure.circle_shape
[StructLayout(LayoutKind.Sequential)]
public struct S2CircleShape {
  public float radius;
  public S2CircleShape(float radius) {
    this.radius = radius;
  }
  public S2CircleShape(S2CircleShape instance) {
    this.radius = instance.radius;
  }
}

// structure.ellipse_shape
[StructLayout(LayoutKind.Sequential)]
public struct S2EllipseShape {
  public float radius_x;
  public float radius_y;
  public S2EllipseShape(float radius_x, float radius_y) {
    this.radius_x = radius_x;
    this.radius_y = radius_y;
  }
  public S2EllipseShape(S2EllipseShape instance) {
    this.radius_x = instance.radius_x;
    this.radius_y = instance.radius_y;
  }
}

// structure.capsule_shape
[StructLayout(LayoutKind.Sequential)]
public struct S2CapsuleShape {
  public float rect_half_length;
  public float cap_radius;
  public S2CapsuleShape(float rect_half_length, float cap_radius) {
    this.rect_half_length = rect_half_length;
    this.cap_radius = cap_radius;
  }
  public S2CapsuleShape(S2CapsuleShape instance) {
    this.rect_half_length = instance.rect_half_length;
    this.cap_radius = instance.cap_radius;
  }
}

// structure.polygon_shape
[StructLayout(LayoutKind.Sequential)]
public struct S2PolygonShape {
  public uint vertex_num;
  public IntPtr vertices;
  public S2PolygonShape(uint vertex_num, IntPtr vertices) {
    this.vertex_num = vertex_num;
    this.vertices = vertices;
  }
  public S2PolygonShape(S2PolygonShape instance) {
    this.vertex_num = instance.vertex_num;
    this.vertices = instance.vertices;
  }
}

// union.shape_union
[StructLayout(LayoutKind.Explicit)]
public struct S2ShapeUnion {
  [FieldOffset(0)] public S2BoxShape box;
  [FieldOffset(0)] public S2CircleShape circle;
  [FieldOffset(0)] public S2EllipseShape ellipse;
  [FieldOffset(0)] public S2CapsuleShape capsule;
  [FieldOffset(0)] public S2PolygonShape polygon;
}

// structure.shape
[StructLayout(LayoutKind.Sequential)]
public struct S2Shape {
  public S2ShapeType type;
  public S2ShapeUnion shape_union;
  public S2Shape(S2ShapeType type, S2ShapeUnion shape_union) {
    this.type = type;
    this.shape_union = shape_union;
  }
  public S2Shape(S2Shape instance) {
    this.type = instance.type;
    this.shape_union = instance.shape_union;
  }
}

// structure.particle
[StructLayout(LayoutKind.Sequential)]
public struct S2Particle {
  public uint id;
  public S2Vec2 position;
  public S2Vec2 velocity;
  public uint tag;
  public uint is_removed;
  public S2Particle(uint id, S2Vec2 position, S2Vec2 velocity, uint tag, uint is_removed) {
    this.id = id;
    this.position = position;
    this.velocity = velocity;
    this.tag = tag;
    this.is_removed = is_removed;
  }
  public S2Particle(S2Particle instance) {
    this.id = instance.id;
    this.position = instance.position;
    this.velocity = instance.velocity;
    this.tag = instance.tag;
    this.is_removed = instance.is_removed;
  }
}

// enumeration.out_world_boundary_policy
public enum S2OutWorldBoundaryPolicy {
  S2_OUT_WORLD_BOUNDARY_POLICY_DEACTIVATION = 0,
  S2_OUT_WORLD_BOUNDARY_POLICY_REMOVING = 1,
  S2_OUT_WORLD_BOUNDARY_POLICY_MAX_ENUM = 0x7fffffff,
}

// enumeration.collision_type
public enum S2CollisionType {
  S2_COLLISION_TYPE_STICKY = 0,
  S2_COLLISION_TYPE_SLIP = 1,
  S2_COLLISION_TYPE_SEPARATE = 2,
  S2_COLLISION_TYPE_MAX_ENUM = 0x7fffffff,
}

// structure.collision_parameter
[StructLayout(LayoutKind.Sequential)]
public struct S2CollisionParameter {
  public S2CollisionType collision_type;
  public float friction_coeff;
  public float restitution_coeff;
  public S2CollisionParameter(S2CollisionType collision_type, float friction_coeff, float restitution_coeff) {
    this.collision_type = collision_type;
    this.friction_coeff = friction_coeff;
    this.restitution_coeff = restitution_coeff;
  }
  public S2CollisionParameter(S2CollisionParameter instance) {
    this.collision_type = instance.collision_type;
    this.friction_coeff = instance.friction_coeff;
    this.restitution_coeff = instance.restitution_coeff;
  }
}

// structure.world_config
[StructLayout(LayoutKind.Sequential)]
public struct S2WorldConfig {
  public uint max_allowed_particle_num;
  public uint max_allowed_body_num;
  public uint max_allowed_element_num;
  public uint max_allowed_trigger_num;
  public uint grid_resolution;
  public S2Vec2 offset;
  public S2Vec2 extent;
  public float substep_dt;
  public S2Vec2 gravity;
  public S2OutWorldBoundaryPolicy out_world_boundary_policy;
  public uint enable_debugging;
  public uint enable_world_query;
  public float mesh_body_force_scale;
  public float collision_penalty_force_scale_along_normal_dir;
  public float collision_penalty_force_scale_along_velocity_dir;
  public uint fine_grid_scale;
  public S2WorldConfig(uint max_allowed_particle_num, uint max_allowed_body_num, uint max_allowed_element_num, uint max_allowed_trigger_num, uint grid_resolution, S2Vec2 offset, S2Vec2 extent, float substep_dt, S2Vec2 gravity, S2OutWorldBoundaryPolicy out_world_boundary_policy, uint enable_debugging, uint enable_world_query, float mesh_body_force_scale, float collision_penalty_force_scale_along_normal_dir, float collision_penalty_force_scale_along_velocity_dir, uint fine_grid_scale) {
    this.max_allowed_particle_num = max_allowed_particle_num;
    this.max_allowed_body_num = max_allowed_body_num;
    this.max_allowed_element_num = max_allowed_element_num;
    this.max_allowed_trigger_num = max_allowed_trigger_num;
    this.grid_resolution = grid_resolution;
    this.offset = offset;
    this.extent = extent;
    this.substep_dt = substep_dt;
    this.gravity = gravity;
    this.out_world_boundary_policy = out_world_boundary_policy;
    this.enable_debugging = enable_debugging;
    this.enable_world_query = enable_world_query;
    this.mesh_body_force_scale = mesh_body_force_scale;
    this.collision_penalty_force_scale_along_normal_dir = collision_penalty_force_scale_along_normal_dir;
    this.collision_penalty_force_scale_along_velocity_dir = collision_penalty_force_scale_along_velocity_dir;
    this.fine_grid_scale = fine_grid_scale;
  }
  public S2WorldConfig(S2WorldConfig instance) {
    this.max_allowed_particle_num = instance.max_allowed_particle_num;
    this.max_allowed_body_num = instance.max_allowed_body_num;
    this.max_allowed_element_num = instance.max_allowed_element_num;
    this.max_allowed_trigger_num = instance.max_allowed_trigger_num;
    this.grid_resolution = instance.grid_resolution;
    this.offset = instance.offset;
    this.extent = instance.extent;
    this.substep_dt = instance.substep_dt;
    this.gravity = instance.gravity;
    this.out_world_boundary_policy = instance.out_world_boundary_policy;
    this.enable_debugging = instance.enable_debugging;
    this.enable_world_query = instance.enable_world_query;
    this.mesh_body_force_scale = instance.mesh_body_force_scale;
    this.collision_penalty_force_scale_along_normal_dir = instance.collision_penalty_force_scale_along_normal_dir;
    this.collision_penalty_force_scale_along_velocity_dir = instance.collision_penalty_force_scale_along_velocity_dir;
    this.fine_grid_scale = instance.fine_grid_scale;
  }
}

// function_pointer_type.particle_manipulation_callback
public delegate void S2ParticleManipulationCallback(
  IntPtr particles,
  uint size
);

// enumeration.buffer_name
public enum S2BufferName {
  S2_BUFFER_NAME_PARTICLE_NUM = 0,
  S2_BUFFER_NAME_PARTICLE_POSITION = 1,
  S2_BUFFER_NAME_PARTICLE_VELOCITY = 2,
  S2_BUFFER_NAME_PARTICLE_TAG = 3,
  S2_BUFFER_NAME_PARTICLE_ID = 4,
  S2_BUFFER_NAME_FINE_GRID_COLLIDER_NUM = 5,
  S2_BUFFER_NAME_FINE_GRID_TRIGGER_ID = 6,
  S2_BUFFER_NAME_ELEMENT_INDICES = 7,
  S2_BUFFER_NAME_MAX_ENUM = 0x7fffffff,
}

// function.create_world
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2World s2_create_world(
  TiArch arch,
  TiRuntime runtime,
  [MarshalAs(UnmanagedType.LPArray)] S2WorldConfig[] config
);
public static S2World S2CreateWorld(
  TiArch arch,
  TiRuntime runtime,
  S2WorldConfig config
) {
  var arr_config = new S2WorldConfig[1];
  arr_config[0] = config;
  var rv = s2_create_world(
    arch,
    runtime,
    arr_config
  );
  return rv;
}
}

// function.destroy_world
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_destroy_world(
  S2World world
);
public static void S2DestroyWorld(
  S2World world
) {
  s2_destroy_world(
    world
  );
}
}

// function.create_body
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  [MarshalAs(UnmanagedType.LPArray)] S2Shape[] shape,
  uint tag
);
public static S2Body S2CreateBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  S2Shape shape,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var arr_shape = new S2Shape[1];
  arr_shape[0] = shape;
  var rv = s2_create_body(
    world,
    arr_material,
    arr_kinematics,
    arr_shape,
    tag
  );
  return rv;
}
}

// function.create_custom_body
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_custom_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint tag
);
public static S2Body S2CreateCustomBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_custom_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    tag
  );
  return rv;
}
}

// function.create_mesh_body
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  byte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  sbyte[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  short[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  ushort[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  int[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  uint[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  long[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  ulong[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  IntPtr[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  float[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] byte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  byte[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] sbyte[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  sbyte[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] short[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  short[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ushort[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ushort[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] int[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  int[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] uint[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  uint[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] long[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  long[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] ulong[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  ulong[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] IntPtr[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  IntPtr[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] float[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  float[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Body s2_create_mesh_body(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  uint particle_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] particles_in_local_space,
  uint index_num,
  [MarshalAs(UnmanagedType.LPArray)] double[] indices,
  uint tag
);
public static S2Body S2CreateMeshBody(
  S2World world,
  S2Material material,
  S2Kinematics kinematics,
  uint particle_num,
  double[] particles_in_local_space,
  uint index_num,
  double[] indices,
  uint tag
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var rv = s2_create_mesh_body(
    world,
    arr_material,
    arr_kinematics,
    particle_num,
    particles_in_local_space,
    index_num,
    indices,
    tag
  );
  return rv;
}
}

// function.destroy_body
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_destroy_body(
  S2Body body
);
public static void S2DestroyBody(
  S2Body body
) {
  s2_destroy_body(
    body
  );
}
}

// function.create_collider
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Collider s2_create_collider(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  [MarshalAs(UnmanagedType.LPArray)] S2Shape[] shape,
  [MarshalAs(UnmanagedType.LPArray)] S2CollisionParameter[] collision_parameter
);
public static S2Collider S2CreateCollider(
  S2World world,
  S2Kinematics kinematics,
  S2Shape shape,
  S2CollisionParameter collision_parameter
) {
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var arr_shape = new S2Shape[1];
  arr_shape[0] = shape;
  var arr_collision_parameter = new S2CollisionParameter[1];
  arr_collision_parameter[0] = collision_parameter;
  var rv = s2_create_collider(
    world,
    arr_kinematics,
    arr_shape,
    arr_collision_parameter
  );
  return rv;
}
}

// function.destroy_collider
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_destroy_collider(
  S2Collider collider
);
public static void S2DestroyCollider(
  S2Collider collider
) {
  s2_destroy_collider(
    collider
  );
}
}

// function.create_trigger
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Trigger s2_create_trigger(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Kinematics[] kinematics,
  [MarshalAs(UnmanagedType.LPArray)] S2Shape[] shape
);
public static S2Trigger S2CreateTrigger(
  S2World world,
  S2Kinematics kinematics,
  S2Shape shape
) {
  var arr_kinematics = new S2Kinematics[1];
  arr_kinematics[0] = kinematics;
  var arr_shape = new S2Shape[1];
  arr_shape[0] = shape;
  var rv = s2_create_trigger(
    world,
    arr_kinematics,
    arr_shape
  );
  return rv;
}
}

// function.destroy_trigger
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_destroy_trigger(
  S2Trigger trigger
);
public static void S2DestroyTrigger(
  S2Trigger trigger
) {
  s2_destroy_trigger(
    trigger
  );
}
}

// function.step
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_step(
  S2World world,
  float delta_time
);
public static void S2Step(
  S2World world,
  float delta_time
) {
  s2_step(
    world,
    delta_time
  );
}
}

// function.get_world_config
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2WorldConfig s2_get_world_config(
  S2World world
);
public static S2WorldConfig S2GetWorldConfig(
  S2World world
) {
  var rv = s2_get_world_config(
    world
  );
  return rv;
}
}

// function.get_world_grid_resolution
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Vec2I s2_get_world_grid_resolution(
  S2World world
);
public static S2Vec2I S2GetWorldGridResolution(
  S2World world
) {
  var rv = s2_get_world_grid_resolution(
    world
  );
  return rv;
}
}

// function.set_substep_timestep
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_substep_timestep(
  S2World world,
  float delta_time
);
public static void S2SetSubstepTimestep(
  S2World world,
  float delta_time
) {
  s2_set_substep_timestep(
    world,
    delta_time
  );
}
}

// function.set_gravity
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_gravity(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] gravity
);
public static void S2SetGravity(
  S2World world,
  S2Vec2 gravity
) {
  var arr_gravity = new S2Vec2[1];
  arr_gravity[0] = gravity;
  s2_set_gravity(
    world,
    arr_gravity
  );
}
}

// function.set_world_query_enabled
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_world_query_enabled(
  S2World world,
  uint enable
);
public static void S2SetWorldQueryEnabled(
  S2World world,
  uint enable
) {
  s2_set_world_query_enabled(
    world,
    enable
  );
}
}

// function.set_world_offset
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_world_offset(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] offset
);
public static void S2SetWorldOffset(
  S2World world,
  S2Vec2 offset
) {
  var arr_offset = new S2Vec2[1];
  arr_offset[0] = offset;
  s2_set_world_offset(
    world,
    arr_offset
  );
}
}

// function.set_world_extent
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_world_extent(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] extent
);
public static void S2SetWorldExtent(
  S2World world,
  S2Vec2 extent
) {
  var arr_extent = new S2Vec2[1];
  arr_extent[0] = extent;
  s2_set_world_extent(
    world,
    arr_extent
  );
}
}

// function.set_mesh_body_force_scale
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_mesh_body_force_scale(
  S2World world,
  float scale
);
public static void S2SetMeshBodyForceScale(
  S2World world,
  float scale
) {
  s2_set_mesh_body_force_scale(
    world,
    scale
  );
}
}

// function.apply_impulse_in_circular_area
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_apply_impulse_in_circular_area(
  S2World world,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] impulse,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] center,
  float radius
);
public static void S2ApplyImpulseInCircularArea(
  S2World world,
  S2Vec2 impulse,
  S2Vec2 center,
  float radius
) {
  var arr_impulse = new S2Vec2[1];
  arr_impulse[0] = impulse;
  var arr_center = new S2Vec2[1];
  arr_center[0] = center;
  s2_apply_impulse_in_circular_area(
    world,
    arr_impulse,
    arr_center,
    radius
  );
}
}

// function.get_buffer
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_get_buffer(
  S2World world,
  S2BufferName buffer_name,
  [MarshalAs(UnmanagedType.LPArray)] [In, Out] TiNdArray[] buffer
);
public static void S2GetBuffer(
  S2World world,
  S2BufferName buffer_name,
  ref TiNdArray buffer
) {
  var arr_buffer = new TiNdArray[1];
  arr_buffer[0] = buffer;
  s2_get_buffer(
    world,
    buffer_name,
    arr_buffer
  );
  buffer = arr_buffer[0];
}
}

// function.export_buffer_to_texture
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_export_buffer_to_texture(
  S2World world,
  S2BufferName buffer_name,
  uint y_flipped,
  float scale,
  [MarshalAs(UnmanagedType.LPArray)] TiTexture[] texture
);
public static void S2ExportBufferToTexture(
  S2World world,
  S2BufferName buffer_name,
  uint y_flipped,
  float scale,
  TiTexture texture
) {
  var arr_texture = new TiTexture[1];
  arr_texture[0] = texture;
  s2_export_buffer_to_texture(
    world,
    buffer_name,
    y_flipped,
    scale,
    arr_texture
  );
}
}

// function.apply_linear_impulse
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_apply_linear_impulse(
  S2Body body,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] impulse
);
public static void S2ApplyLinearImpulse(
  S2Body body,
  S2Vec2 impulse
) {
  var arr_impulse = new S2Vec2[1];
  arr_impulse[0] = impulse;
  s2_apply_linear_impulse(
    body,
    arr_impulse
  );
}
}

// function.apply_angular_impulse
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_apply_angular_impulse(
  S2Body body,
  float impulse
);
public static void S2ApplyAngularImpulse(
  S2Body body,
  float impulse
) {
  s2_apply_angular_impulse(
    body,
    impulse
  );
}
}

// function.set_body_material
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_body_material(
  S2Body body,
  [MarshalAs(UnmanagedType.LPArray)] S2Material[] material
);
public static void S2SetBodyMaterial(
  S2Body body,
  S2Material material
) {
  var arr_material = new S2Material[1];
  arr_material[0] = material;
  s2_set_body_material(
    body,
    arr_material
  );
}
}

// function.set_body_tag
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_body_tag(
  S2Body body,
  uint tag
);
public static void S2SetBodyTag(
  S2Body body,
  uint tag
) {
  s2_set_body_tag(
    body,
    tag
  );
}
}

// function.set_collider_position
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_collider_position(
  S2Collider collider,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] position
);
public static void S2SetColliderPosition(
  S2Collider collider,
  S2Vec2 position
) {
  var arr_position = new S2Vec2[1];
  arr_position[0] = position;
  s2_set_collider_position(
    collider,
    arr_position
  );
}
}

// function.get_collider_position
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Vec2 s2_get_collider_position(
  S2Collider collider
);
public static S2Vec2 S2GetColliderPosition(
  S2Collider collider
) {
  var rv = s2_get_collider_position(
    collider
  );
  return rv;
}
}

// function.set_collider_rotation
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_collider_rotation(
  S2Collider collider,
  float rotation
);
public static void S2SetColliderRotation(
  S2Collider collider,
  float rotation
) {
  s2_set_collider_rotation(
    collider,
    rotation
  );
}
}

// function.get_collider_rotation
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern float s2_get_collider_rotation(
  S2Collider collider
);
public static float S2GetColliderRotation(
  S2Collider collider
) {
  var rv = s2_get_collider_rotation(
    collider
  );
  return rv;
}
}

// function.set_collider_linear_velocity
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_collider_linear_velocity(
  S2Collider collider,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] linear_velocity
);
public static void S2SetColliderLinearVelocity(
  S2Collider collider,
  S2Vec2 linear_velocity
) {
  var arr_linear_velocity = new S2Vec2[1];
  arr_linear_velocity[0] = linear_velocity;
  s2_set_collider_linear_velocity(
    collider,
    arr_linear_velocity
  );
}
}

// function.get_collider_linear_velocity
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Vec2 s2_get_collider_linear_velocity(
  S2Collider collider
);
public static S2Vec2 S2GetColliderLinearVelocity(
  S2Collider collider
) {
  var rv = s2_get_collider_linear_velocity(
    collider
  );
  return rv;
}
}

// function.set_collider_angular_velocity
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_collider_angular_velocity(
  S2Collider collider,
  float angular_velocity
);
public static void S2SetColliderAngularVelocity(
  S2Collider collider,
  float angular_velocity
) {
  s2_set_collider_angular_velocity(
    collider,
    angular_velocity
  );
}
}

// function.get_collider_angular_velocity
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern float s2_get_collider_angular_velocity(
  S2Collider collider
);
public static float S2GetColliderAngularVelocity(
  S2Collider collider
) {
  var rv = s2_get_collider_angular_velocity(
    collider
  );
  return rv;
}
}

// function.set_trigger_position
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_trigger_position(
  S2Trigger trigger,
  [MarshalAs(UnmanagedType.LPArray)] S2Vec2[] position
);
public static void S2SetTriggerPosition(
  S2Trigger trigger,
  S2Vec2 position
) {
  var arr_position = new S2Vec2[1];
  arr_position[0] = position;
  s2_set_trigger_position(
    trigger,
    arr_position
  );
}
}

// function.get_trigger_position
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern S2Vec2 s2_get_trigger_position(
  S2Trigger trigger
);
public static S2Vec2 S2GetTriggerPosition(
  S2Trigger trigger
) {
  var rv = s2_get_trigger_position(
    trigger
  );
  return rv;
}
}

// function.set_trigger_rotation
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_set_trigger_rotation(
  S2Trigger trigger,
  float rotation
);
public static void S2SetTriggerRotation(
  S2Trigger trigger,
  float rotation
) {
  s2_set_trigger_rotation(
    trigger,
    rotation
  );
}
}

// function.get_trigger_rotation
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern float s2_get_trigger_rotation(
  S2Trigger trigger
);
public static float S2GetTriggerRotation(
  S2Trigger trigger
) {
  var rv = s2_get_trigger_rotation(
    trigger
  );
  return rv;
}
}

// function.query_trigger_overlapped
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern uint s2_query_trigger_overlapped(
  S2Trigger trigger
);
public static uint S2QueryTriggerOverlapped(
  S2Trigger trigger
) {
  var rv = s2_query_trigger_overlapped(
    trigger
  );
  return rv;
}
}

// function.query_trigger_overlapped_by_tag
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern uint s2_query_trigger_overlapped_by_tag(
  S2Trigger trigger,
  uint tag,
  uint mask
);
public static uint S2QueryTriggerOverlappedByTag(
  S2Trigger trigger,
  uint tag,
  uint mask
) {
  var rv = s2_query_trigger_overlapped_by_tag(
    trigger,
    tag,
    mask
  );
  return rv;
}
}

// function.query_particle_num_in_trigger
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern uint s2_query_particle_num_in_trigger(
  S2Trigger trigger
);
public static uint S2QueryParticleNumInTrigger(
  S2Trigger trigger
) {
  var rv = s2_query_particle_num_in_trigger(
    trigger
  );
  return rv;
}
}

// function.query_particle_num_in_trigger_by_tag
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern uint s2_query_particle_num_in_trigger_by_tag(
  S2Trigger trigger,
  uint tag,
  uint mask
);
public static uint S2QueryParticleNumInTriggerByTag(
  S2Trigger trigger,
  uint tag,
  uint mask
) {
  var rv = s2_query_particle_num_in_trigger_by_tag(
    trigger,
    tag,
    mask
  );
  return rv;
}
}

// function.remove_particles_in_trigger
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_remove_particles_in_trigger(
  S2Trigger trigger
);
public static void S2RemoveParticlesInTrigger(
  S2Trigger trigger
) {
  s2_remove_particles_in_trigger(
    trigger
  );
}
}

// function.remove_particles_in_trigger_by_tag
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_remove_particles_in_trigger_by_tag(
  S2Trigger trigger,
  uint tag,
  uint mask
);
public static void S2RemoveParticlesInTriggerByTag(
  S2Trigger trigger,
  uint tag,
  uint mask
) {
  s2_remove_particles_in_trigger_by_tag(
    trigger,
    tag,
    mask
  );
}
}

// function.manipulate_particles_in_trigger
static partial class Ffi {
#if (UNITY_IOS || UNITY_TVOS || UNITY_WEBGL) && !UNITY_EDITOR
    [DllImport ("__Internal")]
#else
    [DllImport("soft2d")]
#endif
private static extern void s2_manipulate_particles_in_trigger(
  S2Trigger trigger,
  S2ParticleManipulationCallback callback
);
public static void S2ManipulateParticlesInTrigger(
  S2Trigger trigger,
  S2ParticleManipulationCallback callback
) {
  s2_manipulate_particles_in_trigger(
    trigger,
    callback
  );
}
}

} // namespace Soft2D.Generated
