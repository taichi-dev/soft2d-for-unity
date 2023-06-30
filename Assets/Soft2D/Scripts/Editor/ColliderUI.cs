using UnityEngine;
using UnityEditor;

namespace Taichi.Soft2D.Plugin
{
    [CustomEditor(typeof(ECollider), true)]
    public class ColliderUI : Editor
    {
        #region Register Serialized Objects

        static internal ECollider eCollider;

        private SerializedProperty uColl;
        private SerializedProperty isDynamic;
        private SerializedProperty autoCorrection;
        private SerializedProperty collisionType;
        private SerializedProperty frictionCoefficient;
        private SerializedProperty restitutionCoefficient;

        private void OnEnable()
        {
            Tools.current = Tool.Move;
            eCollider = target as ECollider;
            
            uColl = serializedObject.FindProperty("uCollider");
            isDynamic = serializedObject.FindProperty("isDynamic");
            autoCorrection = serializedObject.FindProperty("autoCorrection");
            collisionType = serializedObject.FindProperty("collisionType");
            frictionCoefficient = serializedObject.FindProperty("frictionCoefficient");
            restitutionCoefficient = serializedObject.FindProperty("restitutionCoefficient");
        }

        #endregion

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Collider Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(uColl, new GUIContent("Unity Collider 2D", "Unity Collider 2D (support box, circle, polygon, capsule, composite)"));
            if (eCollider.uCollider is not BoxCollider2D &&
                eCollider.uCollider is not CircleCollider2D &&
                eCollider.uCollider is not CompositeCollider2D &&
                eCollider.uCollider is not CapsuleCollider2D &&
                eCollider.uCollider is not PolygonCollider2D){
                EditorGUILayout.HelpBox("Plugin failed to support this collider type!",MessageType.Error);
            }
            else
            {
                EditorGUILayout.PropertyField(isDynamic, new GUIContent("Dynamic", "Moving by user-specified velocity or auto-simulating"));
                if (eCollider.isDynamic)
                {
                    EditorGUI.BeginChangeCheck();
                    Vector2 newLiVel = EditorGUILayout.Vector2Field(new GUIContent("Linear Velocity", "Collider's linear velocity"), eCollider.linearVelocity);
                    float newAnVel = EditorGUILayout.FloatField(new GUIContent("Angular Velocity", "Collider's angular velocity (degree)"), eCollider.angularVelocity);
                    if (EditorGUI.EndChangeCheck())
                    {
                        eCollider.linearVelocity = newLiVel;
                        eCollider.angularVelocity = newAnVel;
                        EditorUtility.SetDirty(eCollider);
                    }
                    EditorGUILayout.PropertyField(autoCorrection, new GUIContent("Auto Correction", "Automatically sync the position and velocity data of unity colliders to soft2d each frame"));
                    if (eCollider.autoCorrection)
                    {
                        EditorGUILayout.HelpBox("Turning this on may cause performance overhead.",MessageType.Warning);
                    }
                }
            }
            EditorGUILayout.PropertyField(collisionType, new GUIContent("Collision Type", "Collider's collision type\n.Separate: Particles will leave the collider after colliding with the collider\nSlip: Particles will slide along the edge after colliding with the collider\nSticky: Particles will stick to the collider after collision"));
            EditorGUILayout.Slider(frictionCoefficient, 0, 1,
                new GUIContent("Coefficient of Friction", "The friction coefficient when particles move along the edge of the collider"));
            EditorGUILayout.Slider(restitutionCoefficient, 0, 1,
                new GUIContent("Coefficient of Restitution", "The bounce coefficient when particles collide with the collider"));

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
