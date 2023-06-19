using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Taichi.Soft2D.Generated;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    public class EBody : BodyBase
    {
        // Visit Shape.md for more information
        [HideInInspector] [Tooltip("Body's shape type")] public ShapeType shapeType;
        // Box parameters, available when shapeType is Box
        [HideInInspector] [Tooltip("Box's half width")] public float halfWidth;
        [HideInInspector] [Tooltip("Box's half height")] public float halfHeight;
        // Circle parameter, available when shapeType is Circle
        [HideInInspector] [Tooltip("Circle's radius")] public float radius;
        // Capsule parameters, available when shapeType is Capsule
        [HideInInspector] [Tooltip("Capsule's Half Rect Length")] public float halfRectLength;
        [HideInInspector] [Tooltip("Capsule's Cap Radius")]public float capRadius;
        // Ellipse parameters, available when shapeType is Ellipse
        [HideInInspector] [Tooltip("Ellipse's radius on X axis")] public float radiusX;
        [HideInInspector] [Tooltip("Ellipse's radius on Y axis")] public float radiusY;
        // Polygon parameters, available when shapeType is Polygon
        [HideInInspector] [Tooltip("Polygon vertices' local positions")] public List<Vector2> verticesPosition;

        /// <summary>
        /// Create a Soft2D body with specified parameters.
        /// EBody's override function.
        /// </summary>
        /// <param name="material">Target S2Material</param>
        /// <param name="kinematics">Target S2Kinematics</param>
        /// <param name="tagBuffer">Target TagBuffer, include particle's tag and color</param>
        protected override void CreateS2Body(S2Material material, S2Kinematics kinematics, uint tagBuffer)
        {
            S2Shape shape;
            // If body's shapeType is Polygon, we need an IntPtr to pass vertices array to Soft2D
            IntPtr ptr = IntPtr.Zero;
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
            body = Soft2D.World.CreateBody(material, kinematics, shape, tagBuffer);
            // After polygon body is created, we have to free the vertices array
            Marshal.FreeHGlobal(ptr);
        }
    }
}
