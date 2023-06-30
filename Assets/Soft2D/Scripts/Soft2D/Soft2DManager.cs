using System;
using Taichi.Soft2D.Generated;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace Taichi.Soft2D.Plugin
{
    /// <summary>
    /// Structure specifying parameters of particle's shader
    /// </summary>
    public enum ShaderType
    {
        Unlit, // 2D Unlit Shader
        PBR, // PBR Shader (URP available)
        Blinn_Phong, // Blinn_Phong Shader (URP available)
        Custom, // User Custom Shader
    }
    
    [HelpURL("https://docs.unity3d.com/ScriptReference/Graphics.DrawMeshInstancedIndirect.html")]
    public class Soft2DManager : Singleton<Soft2DManager>
    {
        [Tooltip("An NdArray for storing particle quantity")] private NdArray<int> quantityArray;
        [Tooltip("An NdArray for storing particle position")] private NdArray<float> positionArray;
        [Tooltip("An NdArray for storing particle velocity")] private NdArray<float> velocityArray;
        [Tooltip("An NdArray for storing particle tag")] private NdArray<int> tagArray;
        [Tooltip("An NdArray for storing particle id")] private NdArray<int> idArray;

        [HideInInspector] [Tooltip("Particle instance's mesh")] public Mesh instanceMesh;
        [HideInInspector] [Tooltip("Particle instance's material")] public Material instanceMaterial;
        [HideInInspector] [Tooltip("Particle instance's size")] public float instanceSize;
        [HideInInspector] public Color emissionColor;
        [HideInInspector] public float smoothness;
        [HideInInspector] public float metallic;
        [HideInInspector] public float occlusionSize;

        [HideInInspector] public int layerIndex;

        private ComputeBuffer argsBuffer;
        private ComputeBuffer positionBuffer;
        private ComputeBuffer velocityBuffer;
        private ComputeBuffer idBuffer;
        private ComputeBuffer tagBuffer;

        private int _subMeshIndex;
        private uint[] _args = { 0, 0, 0, 0, 0 };

        private IntPtr argsBufferPtr;
        private IntPtr positionBufferPtr;
        private IntPtr velocityBufferPtr;
        private IntPtr tagBufferPtr;
        private IntPtr idBufferPtr;

        public UnityAction colliderAction;
        public UnityAction triggerAction;
        public UnityAction bodyAction;

#if UNITY_EDITOR
        [Tooltip("An NdArray for storing collider data")] private NdArray<int> colliderPosArray;
        [Tooltip("An NdArray for storing trigger data")] private NdArray<int> triggerPosArray;
        [Tooltip("A ComputeBuffer for storing collider data")] private ComputeBuffer colliderPosBuffer;
        [Tooltip("A ComputeBuffer for storing trigger data")] private ComputeBuffer triggerPosBuffer;
        [Tooltip("An IntPtr to colliderBuffer")] private IntPtr colliderPosBufferPtr;
        [Tooltip("An IntPtr to triggerBuffer")] private IntPtr triggerPosBufferPtr;

        private ComputeShader debugShader;
        private Material debugMaterial;
        private RenderTexture outputRT;
        private int kernelIndex;
        private Vector2Int resolution;
        [HideInInspector] [Tooltip("Quad screening Debugging Tools")] public GameObject debugQuad;
        [HideInInspector] [Tooltip("Collider's color showed on Debugging Tools")] public Color colliderCol = new(93 / 255f, 231 / 255f, 0, 1);
        [HideInInspector] [Tooltip("Trigger's color showed on Debugging Tools")] public Color triggerCol = new(246 / 255f, 238 / 255f, 6 / 255f, 1);
#endif

        [Tooltip("Already invoked UnityActions or not")] private bool isInvoked;

        #region ForceField INTERNAL Parameters

        private bool onDrag;
        private Vector2 lastPos;

        #endregion

        [HideInInspector] [Tooltip("Pause Soft2D simulation")] public bool pause;
        [HideInInspector] [Tooltip("Simulated area of position")] public Vector2 worldOffset;
        [HideInInspector] [Tooltip("Simulated area of scale")] public Vector2 worldExtent;
        [HideInInspector] [Tooltip("Enable Gyro Scope as gravity")] public bool enableGyro;
        [HideInInspector] [Tooltip("Gyroscope's gravity scale")] public int gyroScale;
        [HideInInspector] [Tooltip("Enable force field")] public bool enableForceField;
        [HideInInspector] [Tooltip("Force field scale")] public float forceFieldScale;
        [HideInInspector] [Tooltip("Gravity's scale & direction")] public Vector2 gravity;
        [HideInInspector] [Tooltip("Soft2D's simulated time step")] public float timeStep;
        [HideInInspector] [Tooltip("Enable Debugging Tools")] public bool enableDebuggingTools;
        [HideInInspector] [Tooltip("Particle's render mode")] public ShaderType shaderType;
        [HideInInspector] [Tooltip("Enable world boundary")] public bool enableWorldBoundary;
        [HideInInspector] [Tooltip("Boundary's collision type")] public CollisionType collisionType;
        [HideInInspector] [Tooltip("Boundary's coefficient of friction")] public float frictionCoefficient;
        [HideInInspector] [Tooltip("Boundary's coefficient of restitution")] public float restitutionCoefficient;

        #region Soft2D Project Settings

        [HideInInspector] public int S2MaxParticleNum;
        [HideInInspector] public int S2MaxBodyNum;
        [HideInInspector] public int S2MaxTriggerNum;
        [HideInInspector] public int S2GridResolution;
        [HideInInspector] public float S2Substep;
        [HideInInspector] public float S2MeshBodyForceScale;
        [HideInInspector] public float S2NormalForceScale;
        [HideInInspector] public float S2VelocityForceScale;
        [HideInInspector] public int S2FineGridScale;
        [HideInInspector] public bool S2EnableWorldQuery = true;

        #endregion

        #region Shader Properties To ID

        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private static readonly int PositionBuffer = Shader.PropertyToID("positionBuffer");
        private static readonly int VelocityBuffer = Shader.PropertyToID("velocityBuffer");
        private static readonly int TagBuffer = Shader.PropertyToID("tagBuffer");
        private static readonly int CColor = Shader.PropertyToID("_CColor");
        private static readonly int TColor = Shader.PropertyToID("_TColor");
        private static readonly int InstanceSize = Shader.PropertyToID("_InstanceSize");
        private static readonly int Smoothness = Shader.PropertyToID("_Smoothness");
        private static readonly int Metallic = Shader.PropertyToID("_Metallic");
        private static readonly int Occlusion = Shader.PropertyToID("_Occlusion");
        private static readonly int EmissionColor = Shader.PropertyToID("_Emission");
        private static readonly int IDBuffer = Shader.PropertyToID("IDBuffer");

        #endregion

        /// <summary>
        /// Soft2DManager INTERNAL USE.
        /// Update buffers to instanceMaterial.
        /// invoked in OnEnable().
        /// </summary>
        private void UpdateBuffers()
        {
            // Ensure sub mesh index is in range
            if (instanceMesh != null)
                _subMeshIndex = Mathf.Clamp(_subMeshIndex, 0, instanceMesh.subMeshCount - 1);

            // Positions
            positionBuffer?.Release();
            positionBuffer = new ComputeBuffer((int)Soft2D.World.GetWorldMaxParticleNum(), sizeof(float) * 2);
            instanceMaterial.SetBuffer(PositionBuffer, positionBuffer);

            //Velocity
            velocityBuffer?.Release();
            velocityBuffer = new ComputeBuffer((int)Soft2D.World.GetWorldMaxParticleNum(), sizeof(float) * 2);
            instanceMaterial.SetBuffer(VelocityBuffer, velocityBuffer);

            //Tags
            tagBuffer?.Release();
            tagBuffer = new ComputeBuffer((int)Soft2D.World.GetWorldMaxParticleNum(), sizeof(int));
            instanceMaterial.SetBuffer(TagBuffer, tagBuffer);
            
            //ID
            idBuffer?.Release();
            idBuffer = new ComputeBuffer((int)World.GetWorldMaxParticleNum(),sizeof(int));
            instanceMaterial.SetBuffer(IDBuffer, idBuffer);
            
            // Indirect args
            if (instanceMesh != null)
            {
                _args[0] = instanceMesh.GetIndexCount(_subMeshIndex);
                _args[1] = (uint)0;
                _args[2] = instanceMesh.GetIndexStart(_subMeshIndex);
                _args[3] = instanceMesh.GetBaseVertex(_subMeshIndex);
                _args[4] = 0;
            }
            else
            {
                _args[0] = _args[1] = _args[2] = _args[3] = _args[4] = 0;
            }

            argsBuffer.SetData(_args);
        }

        /// <summary>
        /// Soft2DManager INTERNAL USE.
        /// Set instanceMaterial's parameters.
        /// invoked in Update() if shaderType is not set as custom.
        /// </summary>
        private void SetMaterialProperties()
        {
            if (shaderType != ShaderType.Custom)
            {
                instanceMaterial.SetFloat(InstanceSize, instanceSize);
                if (shaderType != ShaderType.Unlit)
                {
                    instanceMaterial.SetFloat(Smoothness, smoothness);
                }

                if (shaderType == ShaderType.PBR)
                {
                    instanceMaterial.SetFloat(Metallic, metallic);
                    instanceMaterial.SetFloat(Occlusion, occlusionSize);
                    instanceMaterial.SetColor(EmissionColor, emissionColor);
                }
            }
        }

#if UNITY_EDITOR
        /// <summary>
        /// Soft2DManager INTERNAL USE.
        /// Set DebugTool's parameters.
        /// Invoked in OnEnable(), only available in Unity Editor.
        /// </summary>
        private void SetDebugTools()
        {
            // load compute shader
            debugShader = AssetDatabase.LoadAssetAtPath<ComputeShader>(PathInitializer.MainPath + "Materials/DebugTools/DebugComputeShader.compute");


            // load debug quad
            debugQuad = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(PathInitializer.MainPath + "Prefabs/DebugQuad.prefab"),
                new Vector3(worldExtent.x / 2, worldExtent.y / 2, -0.2f), Quaternion.identity);
            debugQuad.transform.localScale = new Vector3(worldExtent.x, worldExtent.y, 1);
            debugMaterial = debugQuad.GetComponent<MeshRenderer>().material;
            debugMaterial.SetColor(CColor, colliderCol);
            debugMaterial.SetColor(TColor, triggerCol);

            // calculate resolution
            resolution = World.GetWorldFineGridResolution();
            int count = resolution.x * resolution.y;
            uint ratio = 4;

            //load Render Texture
            outputRT = new RenderTexture(resolution.x, resolution.y, 0)
            {
                enableRandomWrite = true,
                useMipMap = false
            };
            outputRT.Create();
            debugMaterial.SetTexture(MainTex, outputRT);

            // load debug buffer
            kernelIndex = debugShader.FindKernel("DrawValidationImage");

            // init collider & trigger buffer
            colliderPosBuffer?.Release();
            colliderPosBuffer = new ComputeBuffer(count, sizeof(int));
            colliderPosBufferPtr = colliderPosBuffer.GetNativeBufferPtr();
            debugShader.SetBuffer(kernelIndex, "colliderBuffer", colliderPosBuffer);

            triggerPosBuffer?.Release();
            triggerPosBuffer = new ComputeBuffer(count, sizeof(int));
            triggerPosBufferPtr = triggerPosBuffer.GetNativeBufferPtr();
            debugShader.SetBuffer(kernelIndex, "triggerBuffer", triggerPosBuffer);

            debugShader.SetTexture(kernelIndex, "ResultTexture", outputRT);
            debugShader.SetInt("resolutionY", resolution.y);
            debugShader.SetInt("ratio", (int)ratio);
        }
#endif
        private void OnEnable()
        {
            if (worldExtent is { x: <= 0, y: <= 0 })
            {
                Debug.LogError("World Extent should above 0!");
                return;
            }
            gameObject.transform.hideFlags = HideFlags.HideInInspector;
            Application.targetFrameRate = (int)(1.0f / timeStep);
            UpdateWorldConfig();
            World.Reset();
            World.SetWorldExtent(worldExtent);
            World.SetSubstepTimeStep(1.6e-4f);

#if UNITY_EDITOR
            if (enableDebuggingTools)
            {
                SetDebugTools();
            }
#endif

            argsBuffer = new ComputeBuffer(_args.Length, sizeof(uint), ComputeBufferType.IndirectArguments);
            UpdateBuffers();

            argsBufferPtr = argsBuffer.GetNativeBufferPtr();
            positionBufferPtr = positionBuffer.GetNativeBufferPtr();
            velocityBufferPtr = velocityBuffer.GetNativeBufferPtr();
            tagBufferPtr = tagBuffer.GetNativeBufferPtr();
            idBufferPtr = idBuffer.GetNativeBufferPtr();

            Input.gyro.enabled = true;
        }

        /// <summary>
        /// Soft2DManager INTERNAL USE.
        /// Calculate the force added to particles.
        /// invoked in Update() if enableForceField is true.
        /// </summary>
        private void MouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var pos = new Vector2(pos3.x, pos3.y);
                if (!onDrag)
                {
                    lastPos = pos;
                    onDrag = true;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                onDrag = false;
            }

            if (onDrag)
            {
                var pos3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var pos = new Vector2(pos3.x, pos3.y);
                if (!(pos.x < 0.0f || pos.x > 4.0f || pos.y < 0.0f || pos.y > 2.0f))
                {
                    Vector2 force = (pos - lastPos) * forceFieldScale;
                    World.AddForceFieldTransient(force, pos, 0.03f);
                }
                lastPos = pos;
            }
        }

        private void Start()
        {
            if (enableWorldBoundary)
            {
                colliderAction += AddWorldBoundary;
            }

            if (LayerMask.LayerToName(layerIndex) == "")
            {
                layerIndex = 0;
            }
        }

        private void FixedUpdate()
        {
            if (!pause)
            {
                World.Step(timeStep);
            }
        }

        private void Update()
        {
            quantityArray = World.GetParticleNumBuffer();
            positionArray = World.GetParticlePositionBuffer();
            velocityArray = World.GetParticleVelocityBuffer();
            tagArray = World.GetParticleTagBuffer();
            idArray = World.GetParticleIdBuffer();

#if UNITY_EDITOR
            colliderPosArray = World.GetGridColliderNumFineBuffer();
            triggerPosArray = World.GetGridTriggerIdFineBuffer();
#endif
            if (!isInvoked)
            {
                colliderAction?.Invoke();
                bodyAction?.Invoke();
                triggerAction?.Invoke();
                isInvoked = true;
            }

            if (enableGyro)
            {
                if (SystemInfo.supportsGyroscope)
                    World.SetGravity(Input.gyro.gravity * gyroScale);
                else
                {
                    Debug.LogWarning("Device failed to support gyroscope!");
                    World.SetGravity(gravity);
                }
            }
            else
            {
                World.SetGravity(gravity);
            }

            if (enableForceField)
                MouseDown();

            // Copy current number of particles to the (second uint argument of) arg buffer
            quantityArray.CopyToNativeBufferRangeAsync(argsBufferPtr, 0, 4, 4);
            positionArray.CopyToNativeBufferAsync(positionBufferPtr);
            velocityArray.CopyToNativeBufferAsync(velocityBufferPtr);
            tagArray.CopyToNativeBufferAsync(tagBufferPtr);
            idArray.CopyToNativeBufferAsync(idBufferPtr);

            Runtime.Submit();

            SetMaterialProperties();
            Graphics.DrawMeshInstancedIndirect(instanceMesh, _subMeshIndex, instanceMaterial, new Bounds(
                 new Vector3(0.0f, 0.0f, 0.0f),
                 new Vector3(500.0f, 500.0f, 500.0f)), argsBuffer, 0, null, ShadowCastingMode.On, true, layerIndex);

#if UNITY_EDITOR
            if (enableDebuggingTools)
            {
                Vector2 offset = World.GetWorldOffset();
                debugQuad.transform.position = new Vector3(offset.x + worldExtent.x / 2, offset.y + worldExtent.y / 2, debugQuad.transform.position.z);
                colliderPosArray.CopyToNativeBufferAsync(colliderPosBufferPtr);
                triggerPosArray.CopyToNativeBufferAsync(triggerPosBufferPtr);
                debugShader.Dispatch(kernelIndex, resolution.x / 8, resolution.y / 8, 1);
            }
#endif

        }

        /// <summary>
        /// Soft2DManager INTERNAL USE.
        /// Update parameters from Project Settings.
        /// invoked in OnEnable().
        /// </summary>
        private void UpdateWorldConfig()
        {
            WorldConfig.config.enable_debugging = enableDebuggingTools ? (uint)1 : 0;
            WorldConfig.config.gravity = new S2Vec2(gravity.x, gravity.y);
            WorldConfig.config.extent = new S2Vec2(worldExtent.x, worldExtent.y);
            WorldConfig.config.offset = new S2Vec2(worldOffset.x, worldOffset.y);

            WorldConfig.config.max_allowed_particle_num = (uint)S2MaxParticleNum;
            WorldConfig.config.max_allowed_body_num = (uint)S2MaxBodyNum;
            WorldConfig.config.max_allowed_trigger_num = (uint)S2MaxTriggerNum;
            WorldConfig.config.grid_resolution = (uint)S2GridResolution;
            WorldConfig.config.substep_dt = S2Substep;
            WorldConfig.config.mesh_body_force_scale = S2MeshBodyForceScale;
            WorldConfig.config.collision_penalty_force_scale_along_normal_dir = S2NormalForceScale;
            WorldConfig.config.collision_penalty_force_scale_along_velocity_dir = S2VelocityForceScale;
            WorldConfig.config.enable_world_query = S2EnableWorldQuery ? (uint)1 : 0;

            if (S2FineGridScale <= 0)
                Utils.Assert("Fine Grid Scale should above 0!");
            else
                WorldConfig.config.fine_grid_scale = (uint)S2FineGridScale;
        }

        /// <summary>
        /// Soft2DManager INTERNAL USE.
        /// Create colliders as world boundary if enableWorldBoundary is true.
        /// invoked in Start().
        /// </summary>
        private void AddWorldBoundary()
        {
            S2CollisionParameter parameter = new S2CollisionParameter()
            {
                collision_type = Utils.CollisionTypeDictionary[collisionType],
                friction_coeff = frictionCoefficient,
                restitution_coeff = restitutionCoefficient,
            };
            KinematicsInfo kinematicsInfo = new KinematicsInfo
            {
                center = new Vector2(worldOffset.x + worldExtent.x / 2, worldOffset.y + worldExtent.y),
                mobility = S2Mobility.S2_MOBILITY_STATIC
            };
            var kinematics = Utils.CreateKinematics(kinematicsInfo);
            var shape = Utils.CreateBoxShape(worldExtent.x / 2, 0.01f);
            World.CreateCollider(kinematics, shape, parameter);

            kinematicsInfo.center = new Vector2(worldOffset.x + worldExtent.y / 2, worldOffset.y);
            kinematics = Utils.CreateKinematics(kinematicsInfo);
            shape = Utils.CreateBoxShape(worldExtent.x / 2, 0.01f);
            World.CreateCollider(kinematics, shape, parameter);

            kinematicsInfo.center = new Vector2(worldOffset.x, worldOffset.y + worldExtent.y / 2);
            kinematics = Utils.CreateKinematics(kinematicsInfo);
            shape = Utils.CreateBoxShape(0.01f, worldExtent.y / 2);
            World.CreateCollider(kinematics, shape, parameter);

            kinematicsInfo.center = new Vector2(worldOffset.x + worldExtent.x,worldOffset.y + worldExtent.y / 2);
            kinematics = Utils.CreateKinematics(kinematicsInfo);
            shape = Utils.CreateBoxShape(0.01f, worldExtent.y / 2);
            World.CreateCollider(kinematics, shape, parameter);
        }

        private void OnDisable()
        {
            // release all buffers
            positionBuffer?.Release();
            positionBuffer = null;

            velocityBuffer?.Release();
            velocityBuffer = null;

            tagBuffer?.Release();
            tagBuffer = null;
            
            idBuffer?.Release();
            idBuffer = null;

            argsBuffer?.Release();
            argsBuffer = null;

#if UNITY_EDITOR
            colliderPosBuffer?.Release();
            colliderPosBuffer = null;

            triggerPosBuffer?.Release();
            triggerPosBuffer = null;
#endif
        }
    }
}
