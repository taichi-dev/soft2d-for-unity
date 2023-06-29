using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Taichi.Soft2D.Generated;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    [RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
    public class ECollider : MonoBehaviour
    {
        [Tooltip("Soft2D's collider")] private Collider eCollider;
        private Rigidbody2D rb;
        [HideInInspector] [Tooltip("Is initialized in Soft2D or not")] public bool isInitialized => eCollider != null;
        [Tooltip("Time step proportion between Unity and Soft2D")] private float stepProportion = 1f;
        [HideInInspector] [Tooltip("Collider's collision type")] public CollisionType collisionType;
        [HideInInspector] [Tooltip("Collider's friction coefficient")] public float frictionCoefficient;
        [HideInInspector] [Tooltip("Collider's restitution coefficient")] public float restitutionCoefficient;
        [Tooltip("Collider's linear velocity")] public Vector2 linearVelocity
        {
            get
            {
                if (isInitialized)
                {
                    linear_velocity = GetSoft2DLinearVelocity();
                    return linear_velocity * stepProportion;
                }
                return linear_velocity;
            }
            set
            {
                if (isInitialized)
                {
                    linear_velocity = value / stepProportion;
                    SetUnityAndSoft2DLinearVelocity(value / stepProportion);
                }
                else
                {
                    linear_velocity = value;
                }
            }
        }

        [Tooltip("Collider's angular velocity (degree)")] public float angularVelocity
        {
            get
            {
                if (isInitialized)
                {
                    angular_velocity = GetSoft2DAngularVelocity();
                    return angular_velocity * stepProportion * Mathf.Rad2Deg;
                }
                return angular_velocity;
            }
            set
            {
                angular_velocity = value / stepProportion;
                if (isInitialized)
                {
                    SetUnityAndSoft2DAngularVelocity(value / stepProportion);
                }
            }
        }
        [HideInInspector] [Tooltip("Unity's collider")] public Collider2D uCollider;
        [HideInInspector] [Tooltip("Moving by user-specified velocity or auto-simulating")] public bool isDynamic;
        [SerializeField] [Tooltip("Collider's linear velocity")] private Vector2 linear_velocity;
        [SerializeField] [Tooltip("Collider's angular velocity (degree)")] private float angular_velocity;
        [HideInInspector] [Tooltip("Automatically sync the position and velocity data of unity colliders to soft2d each frame")] public bool autoCorrection;
        
        /// <summary>
        /// Set collider's position on both Unity and Soft2D side.
        /// This function will be invoked in Update() if autoCorrection is true.
        /// </summary>
        /// <param name="pos">collider's position</param>
        public void SetUnityAndSoft2DPosition(Vector2 pos)
        {
            if (isInitialized)
            {
                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
                eCollider.SetColliderPosition(pos);
            }
        }

        /// <summary>
        /// Set collider's position on Soft2D side.
        /// </summary>
        /// <param name="pos">collider's position</param>
        public void SetSoft2DPosition(Vector2 pos)
        {
            if(isInitialized)
            {
                eCollider.SetColliderPosition(pos);
            }
        }

        /// <summary>
        /// Get collider's position on Soft2D side.
        /// </summary>
        /// <returns>collider's position on Soft2D side</returns>
        public Vector2 GetSoft2DPosition()
        {
            if (isInitialized)
            {
                return eCollider.GetColliderPosition();
            }
            return transform.position;
        }

        /// <summary>
        /// Set collider's position on both Unity and Soft2D side.
        /// This function will be invoked in Update() if autoCorrection is true.
        /// </summary>
        /// <param name="rotation">trigger's rotation (degree)</param>
        public void SetUnityAndSoft2DRotation(float rotation)
        {
            if (isInitialized)
            {
                Vector3 angle = transform.eulerAngles;
                angle.z = rotation;
                transform.eulerAngles = angle;
                eCollider.SetColliderRotation(Mathf.Deg2Rad * rotation);
            }
        }

        /// <summary>
        /// Set collider's rotation on Soft2D side.
        /// </summary>
        /// <param name="rotation">collider's rotation on Soft2D side (degree)</param>
        public void SetSoft2DRotation(float rotation)
        {
            if (isInitialized)
            {
                eCollider.SetColliderRotation(Mathf.Deg2Rad * rotation);
            }
        }

        /// <summary>
        /// Get collider's position on Soft2D side.
        /// </summary>
        /// <returns>collider's rotation on Soft2D side (degree)</returns>
        public float GetSoft2DRotation()
        {
            if (isInitialized)
            {
                return eCollider.GetColliderRotation() * Mathf.Rad2Deg;
            }
            return transform.rotation.z;
        }

        /// <summary>
        /// Set collider's linear velocity on both Unity and Soft2D side.
        /// </summary>
        /// <param name="vel">collider's linear velocity</param>
        public void SetUnityAndSoft2DLinearVelocity(Vector2 vel)
        {
            if (isInitialized)
            {
                eCollider.SetColliderLinearVelocity(vel / stepProportion);
                rb.velocity = vel;
            }
        }

        /// <summary>
        /// Set collider's linear velocity on Soft2D side.
        /// </summary>
        /// <param name="vel">collider's linear velocity</param>
        public void SetSoft2DLinearVelocity(Vector2 vel)
        {
            if (isInitialized)
            {
                eCollider.SetColliderLinearVelocity(vel / stepProportion);
            }
        }

        /// <summary>
        /// Get collider's linear velocity on Soft2D side.
        /// </summary>
        /// <returns>collider's linear velocity on Soft2D side</returns>
        public Vector2 GetSoft2DLinearVelocity()
        {
            if (isInitialized)
            {
                return eCollider.GetColliderLinearVelocity();
            }
            return linear_velocity;
        }

        /// <summary>
        /// Set collider's angular velocity on both Unity and Soft2D side.
        /// </summary>
        /// <param name="vel">collider's angular velocity (degree per second)</param>
        public void SetUnityAndSoft2DAngularVelocity(float vel)
        {
            if (isInitialized)
            {
                eCollider.SetColliderAngularVelocity(vel / 180 * Mathf.PI / stepProportion);
                rb.angularVelocity = vel;
            }
        }

        /// <summary>
        /// Set collider's angular velocity on Soft2D side.
        /// </summary>
        /// <param name="vel">collider's angular velocity (degree per second)</param>
        public void SetSoft2DAngularVelocity(float vel)
        {
            if (isInitialized)
            {
                eCollider.SetColliderAngularVelocity(vel / 180 * Mathf.PI / stepProportion);
            }
        }

        /// <summary>
        /// Get collider's angular velocity on Soft2D side.
        /// </summary>
        /// <returns>collider's angular velocity (degree per second)</returns>
        public float GetSoft2DAngularVelocity()
        {
            if (isInitialized)
            {
                return eCollider.GetColliderAngularVelocity();
            }
            return angular_velocity;
        }
        
        /// <summary>
        /// Create a collider with specified parameters
        /// </summary>
        public void CreateCollider()
        {
            S2Kinematics kinematics;
            IntPtr ptr=IntPtr.Zero;
            if(uCollider is CapsuleCollider2D)
                kinematics = CreateEColliderKinematics(true);
            else
            {
                kinematics = CreateEColliderKinematics();
            }
            S2Shape shape=new S2Shape();
            switch (uCollider)
            {
                case BoxCollider2D:
                    shape = CreateEColliderBoxShape();
                    break;
                case CircleCollider2D:
                    shape = CreateEColliderCircleShape();
                    break;
                case CapsuleCollider2D:
                    shape = CreateEColliderCapsuleShape();
                    break;
                case PolygonCollider2D:
                    shape = CreateEColliderPolygonShape(out ptr);
                    break;
                case CompositeCollider2D:
                    shape = CreateEColliderCompositeShape(out ptr);
                    break;
            }

            S2CollisionParameter parameter = new S2CollisionParameter()
            {
                collision_type = Utils.CollisionTypeDictionary[collisionType],
                friction_coeff = frictionCoefficient,
                restitution_coeff = restitutionCoefficient,
            };
            eCollider = Soft2D.World.CreateCollider(kinematics, shape, parameter);
            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        /// Remove a collider from World and destroy it.
        /// </summary>
        public void DestroyCollider()
        {
            if (isInitialized)
            {
                Soft2D.World.DestroyCollider(eCollider);
                Destroy(this.gameObject);
            }
        }
        
        #region INTERNAL Functions
        
        private void Awake()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
            }
            if (uCollider == null)
            {
                uCollider = GetComponent<Collider2D>();
            }
        }

        public void Start()
        {
            Soft2DManager.Instance.colliderAction += CreateCollider;
            stepProportion = Soft2DManager.Instance.timeStep / Time.fixedDeltaTime;
            if (isDynamic)
            {
                rb.velocity = linear_velocity;
                rb.angularVelocity = angular_velocity;
                rb.angularDrag = 0;
            }
        }

        private void Update()
        {
            if (autoCorrection)
            {
                SetSoft2DPosition(transform.position);
                eCollider.SetColliderLinearVelocity(rb.velocity / stepProportion);
                SetSoft2DRotation(transform.eulerAngles.z);
            }
            else if (isDynamic)
            {
                if (Soft2DManager.Instance.pause)
                {
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0;
                }
                else
                {
                    rb.velocity = linear_velocity;
                    rb.angularVelocity = angular_velocity;
                }
            }
        }

        /// <summary>
        /// ECollider INTERNAL USE.
        /// Create a Kinematics with specified parameters.
        /// </summary>
        /// <param name="isCapsule">whether shape is capsule or not</param>
        /// <returns>Output S2Kinematics</returns>
        private S2Kinematics CreateEColliderKinematics(bool isCapsule=false)
        {
            KinematicsInfo createInfo;
            createInfo.rotation = Mathf.Deg2Rad * transform.rotation.eulerAngles.z;
            createInfo.linearVelocity = linear_velocity / stepProportion;
            createInfo.angularVelocity = angular_velocity / 180 * Mathf.PI / stepProportion;
            createInfo.mobility = isDynamic ? S2Mobility.S2_MOBILITY_DYNAMIC : S2Mobility.S2_MOBILITY_STATIC;

            float centerX = transform.position.x + uCollider.offset.x * Mathf.Cos(createInfo.rotation) +
                            uCollider.offset.y * Mathf.Cos(Mathf.PI - createInfo.rotation);
            float centerY = transform.position.y + uCollider.offset.y * Mathf.Sin(createInfo.rotation) +
                            uCollider.offset.y * Mathf.Sin(Mathf.PI - createInfo.rotation);
            createInfo.center = new Vector2(centerX,centerY);
            
            // Soft2D capsule's default shape is horizontal.
            // It's various from Unity's capsule (vertical).
            // So we have to add 90 degree to Soft2D capsule's rotation.
            if (isCapsule)
            {
                createInfo.rotation = Mathf.Deg2Rad * (transform.rotation.z + 90);
            }
            var kinematics = Utils.CreateKinematics(createInfo);
            return kinematics;
        }

        /// <summary>
        /// ECollider INTERNAL USE.
        /// Create a box shape if Collider2D is BoxCollider2D.
        /// </summary>
        /// <returns>Output S2Shape</returns>
        private S2Shape CreateEColliderBoxShape()
        {
            var coll = uCollider as BoxCollider2D;
            float width = coll.size.x * transform.localScale.x / 2;
            float height = coll.size.y * transform.localScale.y / 2;
            var shape = Utils.CreateBoxShape(width, height);
            return shape;
        }

        /// <summary>
        /// ECollider INTERNAL USE.
        /// Create a capsule shape if Collider2D is CapsuleCollider2D.
        /// </summary>
        /// <returns>Output S2Shape</returns>
        private S2Shape CreateEColliderCapsuleShape()
        {
            var coll = uCollider as CapsuleCollider2D;
            Vector2 size = coll.size;
            var localScale = transform.localScale;
            float halfRectLength;
            float capRadius;
            if (coll.direction == CapsuleDirection2D.Vertical)
            {
                halfRectLength = (size.y * localScale.y - size.x * localScale.x) / 2;
                capRadius = size.x * localScale.x / 2;
            }
            else
            {
                halfRectLength = (size.x * localScale.x - size.y * localScale.y) / 2;
                capRadius = size.y * localScale.y / 2;
            }
            var shape = Utils.CreateCapsuleShape(halfRectLength, capRadius);
            return shape;
        }

        /// <summary>
        /// ECollider INTERNAL USE.
        /// Create a circle shape if Collider2D is CircleCollider2D.
        /// </summary>
        /// <returns>Output S2Shape</returns>
        private S2Shape CreateEColliderCircleShape()
        {
            var coll = uCollider as CircleCollider2D;
            float radius = coll.radius * transform.localScale.x;
            var shape = Utils.CreateCircleShape(radius);
            return shape;
        }

        /// <summary>
        /// ECollider INTERNAL USE.
        /// Create a polygon shape if Collider2D is PolygonCollider2D.
        /// </summary>
        /// <param name="ptr">IntPtr to vertices positions array, return back for free this array</param>
        /// <returns>Output S2Shape</returns>
        private S2Shape CreateEColliderPolygonShape(out IntPtr ptr)
        {
            var coll = uCollider as PolygonCollider2D;
            Vector2 scale = transform.localScale;
            if (coll.points.Length == 0)
            {
                Debug.LogError("The quantity of points should above 0!");
                ptr = IntPtr.Zero;
                return new S2Shape();
            }
            List<Vector2> points = new List<Vector2>();

            foreach (var point in coll.points)
            {
                points.Add(point);
            }

            var shape = new S2Shape()
            {
                type = S2ShapeType.S2_SHAPE_TYPE_POLYGON,
                shape_union = new S2ShapeUnion(),
            };
            float[] vertices = new float[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                vertices[i * 2] = points[i].x*scale.x;
                vertices[i * 2 + 1] = points[i].y*scale.y;
            }

            ptr = Marshal.AllocHGlobal(vertices.Length * sizeof(float));
            Marshal.Copy(vertices, 0, ptr, vertices.Length);
            shape.shape_union.polygon = new S2PolygonShape { vertex_num = (uint)vertices.Length / 2, vertices = ptr };
            return shape;
        }

        /// <summary>
        /// ECollider INTERNAL USE.
        /// Create a composite shape if Collider2D is CompositeCollider2D.
        /// </summary>
        /// <param name="ptr">IntPtr to vertices positions array. This pointer should be freed manually.</param>
        /// <returns>Output S2Shape</returns>
        private S2Shape CreateEColliderCompositeShape(out IntPtr ptr)
        {
            var coll = uCollider as CompositeCollider2D;
            Vector2 scale = transform.localScale;
            if (coll.pathCount == 0)
            {
                Debug.LogError("The quantity of points should above 0!");
                ptr = IntPtr.Zero;
                return new S2Shape();
            }
            List<Vector2> points = new List<Vector2>();
            for (int i = 0; i < coll.pathCount; i++)
            {
                Vector2[] pathVerts = new Vector2[coll.GetPathPointCount(i)];
                coll.GetPath(i, pathVerts);
                points.AddRange(pathVerts);
            }

            var shape = new S2Shape()
            {
                type = S2ShapeType.S2_SHAPE_TYPE_POLYGON,
                shape_union = new S2ShapeUnion(),
            };
            float[] vertices = new float[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                vertices[i * 2] = points[i].x*scale.x;
                vertices[i * 2 + 1] = points[i].y*scale.y;
            }
            ptr = Marshal.AllocHGlobal(vertices.Length * sizeof(float));
            Marshal.Copy(vertices, 0, ptr, vertices.Length);
            shape.shape_union.polygon = new S2PolygonShape { vertex_num = (uint)vertices.Length / 2, vertices = ptr };
            return shape;
        }

        #endregion
    }
}
