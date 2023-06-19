using Taichi.Soft2D.Generated;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    public class EMeshBody : BodyBase
    {
        [HideInInspector] [Tooltip("2D Sprite with mesh")] public Sprite meshSprite;
        [HideInInspector] [Tooltip("MeshBody's mesh scale factor")] public float meshScale;
        
        /// <summary>
        /// Create a Soft2D body with specified parameters.
        /// EMeshBody's override function.
        /// </summary>
        /// <param name="material">Target S2Material</param>
        /// <param name="kinematics">Target S2Kinematics</param>
        /// <param name="tagBuffer">Target tagBuffer, includes particle's tag and color</param>
        protected override void CreateS2Body(S2Material material, S2Kinematics kinematics, uint tagBuffer)
        {
            body = Utils.CreateMeshBody(material, kinematics, meshSprite, tagBuffer, meshScale);
        }
    }
}
