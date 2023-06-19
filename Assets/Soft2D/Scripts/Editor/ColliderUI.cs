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
        private SerializedProperty autoUpdate;
        private SerializedProperty collisionType;
        private SerializedProperty frictionCoefficient;
        private SerializedProperty restitutionCoefficient;

        private void OnEnable()
        {
            Tools.current = Tool.Move;
            eCollider = target as ECollider;
            
            uColl = serializedObject.FindProperty("uCollider");
            isDynamic = serializedObject.FindProperty("isDynamic");
            autoUpdate = serializedObject.FindProperty("autoUpdate");
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
            EditorGUILayout.PropertyField(uColl, new GUIContent("Collider 2D", "Unity Collider 2D (support box, circle, polygon, capsule, composite)"));
            if (eCollider.uCollider is not BoxCollider2D &&
                eCollider.uCollider is not CircleCollider2D &&
                eCollider.uCollider is not CompositeCollider2D &&
                eCollider.uCollider is not CapsuleCollider2D &&
                eCollider.uCollider is not PolygonCollider2D){
                EditorGUILayout.HelpBox("Plugin failed to support this collider type!",MessageType.Error);
            }
            else
            {
                EditorGUILayout.PropertyField(isDynamic, new GUIContent("Dynamic", "This collider is dynamic or not"));
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
                    EditorGUILayout.PropertyField(autoUpdate, new GUIContent("Auto Update Position & Rotation", "Auto update collider's position and rotation on Unity and Soft2D each frame"));
                    if (eCollider.autoUpdate)
                    {
                        EditorGUILayout.HelpBox("Turning this on may cause performance overhead.",MessageType.Warning);
                    }
                }
            }
            EditorGUILayout.PropertyField(collisionType, new GUIContent("Collision Type", "Collider's collision type"));
            EditorGUILayout.Slider(frictionCoefficient, 0, 1,
                new GUIContent("Coefficient of Friction", "Collider's coefficient of friction"));
            EditorGUILayout.Slider(restitutionCoefficient, 0, 1,
                new GUIContent("Coefficient of Restitution", "Collider's coefficient of restitution"));

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
