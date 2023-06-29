using System.Collections;
using System.Collections.Generic;
using Taichi.Soft2D.Generated;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    [CustomEditor(typeof(ECustomBody))]
    public class CustomBodyUI : Editor
    {
        #region Register Serialized Objects

        static internal ECustomBody customBody;


        private SerializedProperty lifetime;
        private SerializedProperty materialType;
        private SerializedProperty density;
        private SerializedProperty youngsModulus;
        private SerializedProperty poissonsRatio;
        private SerializedProperty particleTag;
        private SerializedProperty baseColor;
        private SerializedProperty rainbow;
        private SerializedProperty li_v;
        private SerializedProperty an_v;
        private SerializedProperty points;

        private void OnEnable()
        {
            Tools.current = Tool.Move;
            customBody = target as ECustomBody;

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
            points = serializedObject.FindProperty("particlesPosition");
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
            if (!customBody.randomColor)
                EditorGUILayout.PropertyField(baseColor, new GUIContent("Base Color", "Particle's base color inside body"));
            EditorGUILayout.PropertyField(rainbow, new GUIContent("Random Color", "Generate a color randomly if true"));
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Particle Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(points, new GUIContent("Particles Local Position", "CustomBody particles' local postion"));

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
