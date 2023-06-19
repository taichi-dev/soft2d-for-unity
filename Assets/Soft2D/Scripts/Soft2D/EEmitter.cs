using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Taichi.Soft2D.Generated;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Taichi.Soft2D.Plugin
{
    /// <summary>
    /// A struct storing Soft2D body and its lifetime
    /// </summary>
    public struct BodyInstance
    {
        public Soft2D.Body Body;
        public float lifetime;

        public BodyInstance(Soft2D.Body body, float lifetime)
        {
            this.Body = body;
            this.lifetime = lifetime;
        }
    }
    
    public class EEmitter : MonoBehaviour
    {
        [HideInInspector] [Tooltip("Emit when the scene awake if true")] public bool emitOnAwake;
        [HideInInspector] [Tooltip("Emitting body's linear velocity")] public Vector2 linearVelocity;
        [HideInInspector] [Tooltip("Emitting body's angular velocity")] public float angularVelocity;
        [HideInInspector] [Tooltip("Emitting body's lifetime, 0 means infinity")] public float lifetime = 1f;
        [HideInInspector] [Tooltip("Emitter's emitting frequency")] public float frequency = 7;

        [HideInInspector] [Tooltip("Emitting body material's type")] public MaterialType materialType;
        [HideInInspector] [Tooltip("Emitting body's density")] public float density;
        [HideInInspector] [Tooltip("Emitting body's Young's modulus")] public float youngsModulus;
        [HideInInspector] [Tooltip("Emitting body's Poisson's ratio")] public float poissonsRatio;
        [HideInInspector] [Tooltip("Emitting body's logical tag")] [Range(0, 7)] public uint particleTag;

        [HideInInspector] [Tooltip("Generate color randomly or not")] public bool isRandom;
        [HideInInspector] [Tooltip("The uniform color of particles (will be overridden by the random-color option)")] public Color32 uniformColor;
        [HideInInspector] [Tooltip("Emitting Body's possible colors, their color will be randomly picked from this list")] 
        public List<Color32> randColors;
        [HideInInspector] [Tooltip("Emitting body's color will be generated randomly if true")] public bool rainbow;
        [HideInInspector] [Tooltip("An event which will be invoked while emitting a body")] public UnityEvent OnEmitterOut;

        // Visit Shape.md for more information
        [HideInInspector] [Tooltip("Emitting body's shape type")] public ShapeType shapeType;
        // Box parameters, available when shapeType is Box
        [HideInInspector] [Tooltip("Box's half width")] public float halfWidth;
        [HideInInspector] [Tooltip("Box's half height")] public float halfHeight;
        // Circle parameter, available when shapeType is Circle
        [HideInInspector] [Tooltip("Circle's radius")] public float radius;
        // Capsule parameters, available when shapeType is Capsule
        [HideInInspector] [Tooltip("Capsule's half rect length")] public float halfRectLength;
        [HideInInspector] [Tooltip("Capsule's cap radius")]public float capRadius;
        // Ellipse parameters, available when shapeType is Ellipse
        [HideInInspector] [Tooltip("Ellipse's radius on X axis")] public float radiusX;
        [HideInInspector] [Tooltip("Ellipse's radius on Y axis")] public float radiusY;
        // Polygon parameters, available when shapeType is Polygon
        [HideInInspector] [Tooltip("Polygon vertices' local positions")] public List<Vector2> verticesPosition;
        
        [HideInInspector] [Tooltip("Use mesh body or not")] public bool useMesh;
        [HideInInspector] [Tooltip("2D Sprite with mesh")] public Sprite meshSprite;
        [HideInInspector] [Tooltip("The scale factor of mesh body")] public float meshScale;

        [Tooltip("A queue storing body instances emitted by this emitter")] 
        private Queue<BodyInstance> _bodyParticles;
        [Tooltip("Emitter is emitting or not")] private bool isActivate;
        
        /// <summary>
        /// Make emitter start emit.
        /// This function will be invoked in Start() function if emitOnAwake is true.
        /// Emitter will keep emitting until StopEmitting() function is invoked.
        /// </summary>
        public void StartEmitting()
        {
            if (!isActivate)
            {
                isActivate = true;
                StartCoroutine(Emit());
                if (lifetime > 0)
                {
                    StartCoroutine(CountDown());
                }
            }
        }

        /// <summary>
        /// Make emitter stop emit.
        /// </summary>
        public void StopEmitting()
        {
            isActivate = false;
        }

        /// <summary>
        /// Convert angle to Vector2.
        /// </summary>
        /// <param name="angle">angle</param>
        /// <returns>Vector2 after converting</returns>
        public static Vector2 AngleToVector(float angle)
        {
            float radian = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(radian);
            float y = Mathf.Sin(radian);
            return new Vector2(x, y);
        }

        #region Internal Functions

        private void Awake()
        {
            _bodyParticles = new Queue<BodyInstance>();
        }

        private void Start()
        {
            if (emitOnAwake)
            {
                StartEmitting();
            }
        }

        /// <summary>
        /// EEmitter INTERNAL USE.
        /// Create a Soft2D body for emitter to emit.
        /// </summary>
        private void CreateEmitterBody()
        {
            IntPtr ptr = IntPtr.Zero;
            var material = new S2Material(Utils.MaterialTypeDictionary[materialType], density, youngsModulus, poissonsRatio);
            KinematicsInfo createInfo;
            createInfo.center = transform.position;
            createInfo.rotation = Mathf.Deg2Rad * transform.rotation.eulerAngles.z;
            createInfo.linearVelocity = linearVelocity;
            createInfo.angularVelocity = angularVelocity;
            createInfo.mobility = S2Mobility.S2_MOBILITY_KINEMATIC;
            S2Kinematics kinematics = Utils.CreateKinematics(createInfo);

            uint tagBuffer;
            if (!isRandom)
            {
                tagBuffer = Utils.CreateTag(uniformColor, particleTag);
            }
            else
            {
                Random.InitState((int)DateTime.Now.Ticks);
                // Select color from randColors[] randomly
                if (!rainbow)
                {
                    int randomValue = Random.Range(0, randColors.Count);
                    tagBuffer = Utils.CreateTag(randColors[randomValue], particleTag);
                }
                // Generate colors randomly
                else
                {
                    Color randomColor = new Color(Random.value, Random.value, Random.value);
                    tagBuffer = Utils.CreateTag(randomColor, particleTag);
                }
            }
            if (!useMesh)
            {
                S2Shape shape;
                switch (shapeType)
                {
                    case ShapeType.Box:
                        shape = Utils.CreateBoxShape(halfWidth, halfHeight);
                        break;
                    case ShapeType.Circle:
                        shape = Utils.CreateCircleShape(radius);
                        break;
                    case ShapeType.Capsule:
                        shape = Utils.CreateCapsuleShape(halfRectLength, capRadius);
                        break;
                    case ShapeType.Ellipse:
                        shape = Utils.CreateEllipseShape(radiusX, radiusY);
                        break;
                    case ShapeType.Polygon:
                        shape = Utils.CreatePolygonShape(verticesPosition, out ptr);
                        break;
                    default:
                        shape = new S2Shape();
                        break;
                }
                // Insert new Body into queue
                InsertParticleQueue(World.CreateBody(material, kinematics, shape, tagBuffer));
                Marshal.FreeHGlobal(ptr);
            }
            else
            {
                Body body = Utils.CreateMeshBody(material, kinematics, meshSprite, tagBuffer, meshScale);
                InsertParticleQueue(body);
            }
        }
        
        /// <summary>
        /// EEmitter INTERNAL USE.
        /// Create a Body after 1 / frequency second.
        /// </summary>
        /// <returns>waiting 1 / frequency second</returns>
        private IEnumerator Emit()
        {
            while (isActivate)
            {
                if (!Soft2DManager.Instance.pause)
                {
                    CreateEmitterBody();
                    // Invoke OnEmitterOut Event while emitting new body
                    OnEmitterOut.Invoke();
                }
                yield return new WaitForSeconds(1 / frequency);
            }
        }
        
        /// <summary>
        /// Emitter INTERNAL USE.
        /// Insert new BodyInstance into queue.
        /// </summary>
        /// <param name="body">New Soft2D Body Handle</param>
        private void InsertParticleQueue(Body body)
        {
            if (lifetime <= 0)
            {
                // set lifetime as -1 so that this body won't be removed automatically
                BodyInstance instance =
                    new BodyInstance(body, -1f);
                _bodyParticles.Enqueue(instance);
            }
            else
            {
                // The moment at which the body is removed
                BodyInstance instance =
                    new BodyInstance(body, lifetime + Time.timeSinceLevelLoad);
                _bodyParticles.Enqueue(instance);
            }
        }
        
        /// <summary>
        /// Emitter INTERNAL USE.
        /// When lifetime is larger than 0, this coroutine function is called to count down.
        /// Body is automatically deleted when reaching its lifetime.
        /// </summary>
        /// <returns>NULL</returns>
        private IEnumerator CountDown()
        {
            for (float time = Time.fixedTime; _bodyParticles.Count > 0; time += Time.deltaTime)
            {
                if (_bodyParticles.TryPeek(out BodyInstance bodyParticle))
                {
                    if (bodyParticle.lifetime <= time)
                    {
                        _bodyParticles.Dequeue();
                        Soft2D.World.DestroyBody(bodyParticle.Body);
                    }
                }
                else
                {
                    continue;
                }
                yield return null;
            }
        }
        
        #endregion
    }
}
