using UnityEditor;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    [CustomEditor(typeof(EBody))]
    public class BodyUI : Editor
    {
        #region Register Serialized Objects

        static internal EBody body;

        private SerializedProperty lifetime;
        private SerializedProperty materialType;
        private SerializedProperty density;
        private SerializedProperty youngsModulus;
        private SerializedProperty poissonsRatio;
        private SerializedProperty particleTag;
        private SerializedProperty baseColor;
        private SerializedProperty rainbow;
        private SerializedProperty shapeType;
        private SerializedProperty width;
        private SerializedProperty height;
        private SerializedProperty radius;
        private SerializedProperty halfRectLength;
        private SerializedProperty capRadius;
        private SerializedProperty radiusX;
        private SerializedProperty radiusY;
        private SerializedProperty li_v;
        private SerializedProperty an_v;
        private SerializedProperty points;

        private void OnEnable()
        {
            Tools.current = Tool.Move;
            body = target as EBody;
            
            li_v = serializedObject.FindProperty("linearVelocity");
            an_v = serializedObject.FindProperty("angularVelocity");
            lifetime = serializedObject.FindProperty("lifetime");
            materialType = serializedObject.FindProperty("materialType");
            density = serializedObject.FindProperty("density");
            youngsModulus = serializedObject.FindProperty("youngsModulus");
            poissonsRatio = serializedObject.FindProperty("poissonsRatio");
            particleTag = serializedObject.FindProperty("particleTag");
            baseColor = serializedObject.FindProperty("uniformColor");
            rainbow = serializedObject.FindProperty("randomColor");
            shapeType = serializedObject.FindProperty("shapeType");
            width = serializedObject.FindProperty("halfWidth");
            height = serializedObject.FindProperty("halfHeight");
            radius = serializedObject.FindProperty("radius");
            halfRectLength = serializedObject.FindProperty("halfRectLength");
            capRadius = serializedObject.FindProperty("capRadius");
            radiusX = serializedObject.FindProperty("radiusX");
            radiusY = serializedObject.FindProperty("radiusY");
            points = serializedObject.FindProperty("verticesPosition");
        }

        #endregion

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Body Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.PropertyField(li_v, new GUIContent("Linear Velocity", "Body's linear velocity"));
            EditorGUILayout.PropertyField(an_v, new GUIContent("Angular Velocity", "Body's angular velocity"));
            EditorGUILayout.PropertyField(lifetime, new GUIContent("Lifetime", "Body's lifetime, 0 means infinity"));
            EditorGUILayout.IntSlider(particleTag, 0, 9, new GUIContent("Particle Tag", "Particle's tag"));
            
            EditorGUILayout.Space(10);
            EditorGUILayout.PropertyField(shapeType, new GUIContent("Shape Type", "Body's shape type"));
            switch (body.shapeType)
            {
                case ShapeType.Box:
                    EditorGUILayout.PropertyField(width, new GUIContent("Half Width", "Box's half width"));
                    EditorGUILayout.PropertyField(height, new GUIContent("Half Height", "Box's half height"));
                    break;
                case ShapeType.Circle:
                    EditorGUILayout.PropertyField(radius, new GUIContent("Radius", "Circle's radius"));
                    break;
                case ShapeType.Capsule:
                    EditorGUILayout.PropertyField(halfRectLength, new GUIContent("Half Rect Length", "Capsule's Half Rect Length"));
                    EditorGUILayout.PropertyField(capRadius, new GUIContent("Cap Radius", "Capsule's Cap Radius"));
                    break;
                case ShapeType.Ellipse:
                    EditorGUILayout.PropertyField(radiusX, new GUIContent("Radius Horizontal", "Ellipse's radius on X axis"));
                    EditorGUILayout.PropertyField(radiusY, new GUIContent("Radius Vertical", "Ellipse's radius on Y axis"));
                    break;
                case ShapeType.Polygon:
                    EditorGUILayout.PropertyField(points, new GUIContent("Points Position", "Polygon vertices' local positions"));
                    break;
                default:
                    EditorGUILayout.HelpBox("Failed to support specific shape materialType!", MessageType.Error);
                    break;
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Material Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(materialType, new GUIContent("Material Type", "Body's Material Type"));
            EditorGUILayout.PropertyField(density, new GUIContent("Density", "Body's density"));
            EditorGUILayout.Slider(youngsModulus, 0f, 10f, new GUIContent("Young's Modulus", "Body's Young's modulus"));
            EditorGUILayout.Slider(poissonsRatio, 0f, 1f, new GUIContent("Poisson's Ratio", "Body's Poisson's ratio"));
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Color Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            if (!body.randomColor)
                EditorGUILayout.PropertyField(baseColor, new GUIContent("Base Color", "Particle's base color inside body"));
            EditorGUILayout.PropertyField(rainbow, new GUIContent("Random Color", "Generate a color randomly if true"));
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
