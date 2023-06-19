using System.Collections.Generic;
using Taichi.Soft2D.Generated;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    public class ECustomBody : BodyBase
    {
        [HideInInspector] [Tooltip("CustomBody particles' local positions")] public List<Vector2> particlesPosition;
        
        /// <summary>
        /// Create a Soft2D body with specified parameters.
        /// ECustomBody's override function.
        /// </summary>
        /// <param name="material">Target S2Material</param>
        /// <param name="kinematics">Target S2Kinematics</param>
        /// <param name="tagBuffer">Target tagBuffer, includes particle's tag and color</param>
        protected override void CreateS2Body(S2Material material,S2Kinematics kinematics,uint tagBuffer)
        {
            float[] particles = new float[particlesPosition.Count * 2];

            for (int i = 0; i < particlesPosition.Count; i++)
            {
                particles[i * 2] = particlesPosition[i].x;
                particles[i * 2 + 1] = particlesPosition[i].y;
            }
            body = World.CreateCustomBody(material, kinematics, particlesPosition.Count, particles, tagBuffer);
        }
    }
}
