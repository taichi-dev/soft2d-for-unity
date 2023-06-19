using System.Collections;
using UnityEngine;
using Taichi.Soft2D.Generated;
using Random = UnityEngine.Random;

namespace Taichi.Soft2D.Plugin
{
    public class BodyBase : MonoBehaviour
    {
        [HideInInspector] [Tooltip("Body's linear velocity")] public Vector2 linearVelocity;
        [HideInInspector] [Tooltip("Body's angular velocity")] public float angularVelocity;
        [HideInInspector] [Tooltip("Body's lifetime, 0 means infinity")] public float lifetime = 100f;
        [HideInInspector] [Tooltip("Body's material type")] public MaterialType materialType;
        [HideInInspector] [Tooltip("Body's density")] public float density;
        [HideInInspector] [Tooltip("Body's Young's modulus")] public float youngsModulus;
        [HideInInspector] [Tooltip("Body's Poisson's ratio")] public float poissonsRatio;
        [HideInInspector] [Tooltip("Body's logical tag")] public uint particleTag;
        [HideInInspector] [Tooltip("The uniform color of particles (will be overridden by the random-color option)")] public Color32 uniformColor;
        [HideInInspector] [Tooltip("Random colors")] public bool randomColor;

        [Tooltip("Soft2D's body")] protected Soft2D.Body body;
        [Tooltip("Body is initialized or not")] public bool isInitialized => body != null;

        /// <summary>
        /// Create a body with specified parameters.
        /// Automatically invoked in Soft2DManager's Start() function.
        /// </summary>
        public void CreateBody()
        {
            var material = new S2Material(Utils.MaterialTypeDictionary[materialType], density, youngsModulus, poissonsRatio);
            KinematicsInfo createInfo;
            createInfo.center = transform.position;
            createInfo.rotation = Mathf.Deg2Rad * transform.rotation.eulerAngles.z;
            createInfo.linearVelocity = linearVelocity;
            createInfo.angularVelocity = angularVelocity * Mathf.Deg2Rad;
            createInfo.mobility = S2Mobility.S2_MOBILITY_KINEMATIC;
            var kinematics = Utils.CreateKinematics(createInfo);

            uint tagBuffer;
            if (!randomColor)
            {
                tagBuffer = Utils.CreateTag(uniformColor, particleTag);
            }
            else
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                tagBuffer = Utils.CreateTag(randomColor, particleTag);
            }

            CreateS2Body(material,kinematics,tagBuffer);

            if (lifetime > 0)
                StartCoroutine(CountDown());
        }

        /// <summary>
        /// Set body's material type.
        /// </summary>
        /// <param name="matType">Target Material Type</param>
        public void SetBodyMaterialType(MaterialType matType)
        {
            var material = new S2Material(Utils.MaterialTypeDictionary[matType], density, youngsModulus, poissonsRatio);
            SetBodyMaterial(material);
        }

        /// <summary>
        /// Set body's density.
        /// </summary>
        /// <param name="density">Target Density</param>
        public void SetBodyDensity(float density)
        {
            var material = new S2Material(Utils.MaterialTypeDictionary[materialType], density, youngsModulus, poissonsRatio);
            SetBodyMaterial(material);
        }

        /// <summary>
        /// Set body's Young's modulus.
        /// </summary>
        /// <param name="modulus">Target Young's modulus</param>
        public void SetBodyYoungsModulus(float modulus)
        {
            var material = new S2Material(Utils.MaterialTypeDictionary[materialType], density, modulus, poissonsRatio);
            SetBodyMaterial(material);
        }

        /// <summary>
        /// Set body's Poisson's ratio.
        /// </summary>
        /// <param name="ratio">Target Poisson's ratio</param>
        public void SetBodyPoissonsRatio(float ratio)
        {
            var material = new S2Material(Utils.MaterialTypeDictionary[materialType], density, youngsModulus, ratio);
            SetBodyMaterial(material);
        }

        /// <summary>
        /// Set Body's S2Material.
        /// </summary>
        /// <param name="material">Target </param>
        protected internal void SetBodyMaterial(S2Material material)
        {
            if (isInitialized)
            {
                Soft2D.World.SetBodyMaterialType(this.body, material);
            }
        }

        /// <summary>
        /// Set body's linear velocity.
        /// </summary>
        /// <param name="linearVelocity">Target Linear Velocity</param>
        public void ApplyBodyLinearImpulse(Vector2 linearVelocity)
        {
            if (isInitialized)
            {
                Soft2D.World.ApplyBodyLinearImpulse(this.body, linearVelocity);
            }
        }

        /// <summary>
        /// Set body's angular velocity.
        /// </summary>
        /// <param name="angularVelocity">Target Angular Velocity</param>
        public void ApplyBodyAngularImpulse(float angularVelocity)
        {
            if (isInitialized)
            {
                Soft2D.World.ApplyBodyAngularImpulse(this.body, angularVelocity);
            }
        }

        public void SetBodyTagBuffer(uint tag)
        {
            if (isInitialized)
            {
                World.SetBodyTag(body, tag);
            }
        }

        /// <summary>
        /// Remove specific body from World and destroy it.
        /// </summary>
        public void DestroyBody()
        {
            Soft2D.World.DestroyBody(body);
            Destroy(this.gameObject);
        }

        #region Internal Functions

        protected void Start()
        {
            Soft2DManager.Instance.bodyAction += CreateBody;
        }

        /// <summary>
        /// Create a Soft2D body with specified parameters.
        /// Pure virtual function, override in EBody & EMeshBody & ECustomBody.
        /// </summary>
        /// <param name="material">Target S2Material</param>
        /// <param name="kinematics">Target S2Kinematics</param>
        /// <param name="tagBuffer">Target TagBuffer, including particle's tag and color</param>
        protected virtual void CreateS2Body(S2Material material,S2Kinematics kinematics,uint tagBuffer) { }

        /// <summary>
        /// When lifetime is larger than 0, this coroutine function is called to count down.
        /// This body is automatically destroyed when the countdown ends.
        /// </summary>
        /// <returns>NULL</returns>
        private IEnumerator CountDown()
        {
            for (float time = 0; time < lifetime; time += Time.deltaTime)
            {
                yield return null;
            }
            DestroyBody();
        }

        #endregion
    }
}
