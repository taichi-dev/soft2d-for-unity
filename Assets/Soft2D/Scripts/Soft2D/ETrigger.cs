using UnityEngine;
using Taichi.Soft2D.Generated;

namespace Taichi.Soft2D.Plugin
{
    [RequireComponent(typeof(Collider2D))]
    public class ETrigger : MonoBehaviour
    {
        protected Soft2D.Trigger trigger;
        [HideInInspector] [Tooltip("Trigger is initialized")] public bool isInitialized;

        /// <summary>
        /// Invoke input callback in Soft2D async.
        /// This function can ONLY invoke single callback, DO NOT add multiple callback functions with this function.
        /// </summary>
        /// <param name="callback">Function invoked by this trigger</param>
        public void InvokeCallbackAsync(S2ParticleManipulationCallback callback)
        {
            S2ParticleManipulationCallback s2ParticleManipulationCallback = callback;
            if (trigger == null)
                return;
            trigger.ManipulateParticlesInTriggerAsync(s2ParticleManipulationCallback);
        }

        /// <summary>
        /// Set trigger's position on both Unity and Soft2D side.
        /// </summary>
        /// <param name="pos">trigger's position</param>
        public void SetUnityAndSoft2DPosition(Vector2 pos)
        {
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            if(trigger != null)
                trigger.SetTriggerPosition(pos);
        }

        /// <summary>
        /// Set trigger's position on Soft2D side.
        /// </summary>
        /// <param name="pos">trigger's position</param>
        public void SetSoft2DPosition(Vector2 pos)
        {
            if(trigger != null)
                trigger.SetTriggerPosition(pos);
        }

        /// <summary>
        /// Get trigger's position on Soft2D side.
        /// </summary>
        /// <returns>trigger's position on Soft2D side</returns>
        public Vector2 GetSoft2DPosition()
        {
            return trigger.GetTriggerPosition();
        }

        /// <summary>
        /// Set trigger's rotation on both Unity and Soft2D side.
        /// </summary>
        /// <param name="rotation">trigger's rotation (degree)</param>
        public void SetUnityAndSoft2DRotation(float rotation)
        {
            Vector3 angle=transform.eulerAngles;
            angle.z = rotation;
            transform.eulerAngles = angle;
            trigger.SetTriggerRotation(Mathf.Deg2Rad * rotation);
        }

        /// <summary>
        /// Set trigger's rotation on Soft2D side.
        /// </summary>
        /// <param name="rotation">trigger's rotation (degree)</param>
        public void SetSoft2DRotation(float rotation)
        {
            trigger.SetTriggerRotation(Mathf.Deg2Rad * rotation);
        }

        /// <summary>
        /// Get trigger's rotation on Soft2D side.
        /// </summary>
        /// <returns>trigger's rotation in Soft2D side (degree)</returns>
        public float GetSoft2DRotation()
        {
            return trigger.GetTriggerRotation() * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Delete particles with specific tag inside the trigger area.
        /// </summary>
        /// <param name="tag">specific tag(above 0)</param>
        public void DestroyParticlesByTag(int tag)
        {
            Soft2D.World.RemoveParticlesInTriggerByTag(this.trigger, (uint)tag << 24, 0xff000000);
        }

        /// <summary>
        /// Delete particles inside the trigger area.
        /// </summary>
        public void DestroyParticles()
        {
            Soft2D.World.RemoveParticlesInTrigger(this.trigger);
        }

        /// <summary>
        /// Query if there are particles with specific tag inside the trigger area.
        /// </summary>
        /// <param name="tag">specific tag(above 0)</param>
        /// <returns>if there are particles with specific tag inside the trigger area</returns>
        public bool QueryParticlesByTag(int tag)
        {
            return Soft2D.World.QueryTriggerOverlappedByTag(this.trigger, (uint)tag << 24);
        }

        /// <summary>
        /// Query if there are particles inside the trigger area.
        /// </summary>
        /// <returns>if there are particles inside the trigger area</returns>
        public bool QueryParticles()
        {
            return Soft2D.World.QueryTriggerOverlapped(this.trigger);
        }

        /// <summary>
        /// Query the number of particles with specific tag in the trigger area.
        /// </summary>
        /// <param name="tag">specific tag(above 0)</param>
        /// <returns></returns>
        public uint QueryParticleNumByTag(int tag)
        {
            return Soft2D.World.QueryParticleNumInTriggerByTag(this.trigger, (uint)tag << 24);
        }

        /// <summary>
        /// Remove specific trigger from World and destroy it.
        /// </summary>
        public void DestroyTrigger()
        {
            Soft2D.World.DestroyTrigger(trigger);
        }

        #region Internal Functions

        protected void Start()
        {
            Soft2DManager.Instance.triggerAction += CreateTrigger;
        }

        /// <summary>
        /// ETrigger INTERNAL USE.
        /// Create Soft2D trigger.
        /// </summary>
        private void CreateTrigger()
        {
            var collider = GetComponent<BoxCollider2D>();
            Vector2 size = new Vector2(collider.size.x * transform.localScale.x,
                collider.size.y * transform.localScale.y);
            KinematicsInfo createInfo;
            createInfo.center = transform.position;
            createInfo.rotation = Mathf.Deg2Rad * transform.rotation.eulerAngles.z;
            createInfo.linearVelocity = Vector2.zero;
            createInfo.angularVelocity = .0f;
            createInfo.mobility = S2Mobility.S2_MOBILITY_STATIC;
            var kinematics = Utils.CreateKinematics(createInfo);
            var shape = Utils.CreateBoxShape(size.x / 2, size.y / 2);
            trigger = Soft2D.World.CreateTrigger(kinematics, shape);
            isInitialized = true;
        }

        #endregion
    }
}
