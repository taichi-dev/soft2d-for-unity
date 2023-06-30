using System;
using System.Collections;
using System.Collections.Generic;
using Taichi.Soft2D.Generated;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    [CustomEditor(typeof(EEmitter))]
    public class EmitterUI : Editor
    {
        #region Register Serialized Objects

        static internal EEmitter eEmitter;

        private SerializedProperty emitOnAwake;
        private SerializedProperty li_v;
        private SerializedProperty an_v;
        private SerializedProperty frequency;
        private SerializedProperty lifetime;
        private SerializedProperty materialType;
        private SerializedProperty density;
        private SerializedProperty youngsModulus;
        private SerializedProperty poissonsRatio;
        private SerializedProperty particleTag;
        private SerializedProperty baseColor;
        private SerializedProperty randColors;
        private SerializedProperty isRandom;
        private SerializedProperty rainbow;
        private SerializedProperty shapeType;
        private SerializedProperty width;
        private SerializedProperty height;
        private SerializedProperty radius;
        private SerializedProperty halfRectLength;
        private SerializedProperty capRadius;
        private SerializedProperty radiusX;
        private SerializedProperty radiusY;
        private SerializedProperty OnEmitterOut;
        private SerializedProperty useMesh;
        private SerializedProperty points;
        private SerializedProperty meshSprite;
        private SerializedProperty meshScale;

        private void OnEnable()
        {
            Tools.current = Tool.Move;
            eEmitter = target as EEmitter;
            
            emitOnAwake = serializedObject.FindProperty("emitOnAwake");
            li_v = serializedObject.FindProperty("linearVelocity");
            an_v = serializedObject.FindProperty("angularVelocity");
            frequency = serializedObject.FindProperty("frequency");
            lifetime = serializedObject.FindProperty("lifetime");
            materialType = serializedObject.FindProperty("materialType");
            density = serializedObject.FindProperty("density");
            youngsModulus = serializedObject.FindProperty("youngsModulus");
            poissonsRatio = serializedObject.FindProperty("poissonsRatio");
            particleTag = serializedObject.FindProperty("particleTag");
            baseColor = serializedObject.FindProperty("uniformColor");
            randColors = serializedObject.FindProperty("randColors");
            isRandom = serializedObject.FindProperty("isRandom");
            rainbow = serializedObject.FindProperty("rainbow");
            shapeType = serializedObject.FindProperty("shapeType");
            width = serializedObject.FindProperty("halfWidth");
            height = serializedObject.FindProperty("halfHeight");
            radius = serializedObject.FindProperty("radius");
            halfRectLength = serializedObject.FindProperty("halfRectLength");
            capRadius = serializedObject.FindProperty("capRadius");
            radiusX = serializedObject.FindProperty("radiusX");
            radiusY = serializedObject.FindProperty("radiusY");
            OnEmitterOut = serializedObject.FindProperty("OnEmitterOut");
            useMesh = serializedObject.FindProperty("useMesh");
            points = serializedObject.FindProperty("particlesPosition");
            meshSprite = serializedObject.FindProperty("meshSprite");
            meshScale = serializedObject.FindProperty("meshScale");
        }

        #endregion

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Emitter Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(emitOnAwake, new GUIContent("Emit On Awake", "Emit when the scene awake if true"));
            EditorGUILayout.PropertyField(li_v, new GUIContent("Emit Linear Velocity", "Emitting Body's linear velocity"));
            EditorGUILayout.PropertyField(an_v, new GUIContent("Emit Angular Velocity", "Emitting Body's angular velocity"));
            EditorGUILayout.Slider(frequency, 0f, 50f, new GUIContent("Emitter Frequency", "Emitter's emitting frequency"));
            EditorGUILayout.PropertyField(lifetime, new GUIContent("Lifetime" ,"Emitting Body's lifetime, 0 means infinity"));
            if (eEmitter.lifetime == 0)
            {
                EditorGUILayout.HelpBox("Unity may crash after a large number of Soft2D particles are generated.",
                    MessageType.Info);
            }

            EditorGUILayout.Space(10);
            EditorGUILayout.PropertyField(useMesh, new GUIContent("Use Mesh Body", "Whether to let the emitter emit mesh bodies.\nWhen true, the emitter will emit mesh bodies."));
            if (!eEmitter.useMesh)
            {
                EditorGUILayout.PropertyField(shapeType, new GUIContent("Shape Type", "Emitting Body's shape type"));
                switch (eEmitter.shapeType)
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
                        EditorGUILayout.PropertyField(points, new GUIContent("Vertices Local Position", "Polygon vertices' local positions"));
                        break;
                    default:
                        EditorGUILayout.HelpBox("Failed to support specific shape materialType!", MessageType.Error);
                        break;
                }
            }
            else
            {
                EditorGUILayout.PropertyField(meshSprite, new GUIContent("Mesh Sprite", "2D Sprite with mesh"));
                EditorGUILayout.PropertyField(meshScale, new GUIContent("Mesh Scale", "MeshBody's mesh scale"));
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Material Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(materialType, new GUIContent("Physical Material Type", "Body's Physical Material Type"));
            EditorGUILayout.PropertyField(density, new GUIContent("Density", "Body's density"));
            EditorGUILayout.Slider(youngsModulus, 0f, 10f, new GUIContent("Young's Modulus", "Body's Young's modulus"));
            EditorGUILayout.Slider(poissonsRatio, 0f, 1f, new GUIContent("Poisson's Ratio", "Body's Poisson's ratio"));
            EditorGUILayout.IntSlider(particleTag, 0, 7, new GUIContent("Particle Tag", "Particle's tag"));
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Color Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(isRandom, new GUIContent("Random Color"));
            if (eEmitter.isRandom)
            {
                EditorGUILayout.PropertyField(rainbow, new GUIContent("Rainbow Mode", "Determines whether RGB values are randomly generated as particle colors"));
                if (!eEmitter.rainbow)
                {
                    EditorGUILayout.PropertyField(randColors, new GUIContent("Random Color List", "The collection of all colors that can be randomly selected"));
                }
            }
            else
            {
                EditorGUILayout.PropertyField(baseColor, new GUIContent("Base Color", "The color of the particles inside the emitted bodies"));
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Event Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.PropertyField(OnEmitterOut, new GUIContent("OnEmitterOut", "This event is automatically called when particles are emitted"));
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
