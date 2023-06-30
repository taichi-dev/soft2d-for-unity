using UnityEditor;
using UnityEngine;

namespace Taichi.Soft2D.Plugin
{
    [CustomEditor(typeof(Soft2DManager))]
    public class Soft2DManagerUI : Editor
    {
        #region Register Serialized Objects

        static internal Soft2DManager Soft2DManager;
        private MaterialEditor _materialEditor;
        private string materialPath;

        private SerializedProperty shaderType;
        private SerializedProperty instanceMaterial;
        private SerializedProperty instanceSize;
        private SerializedProperty emissionColor;
        private SerializedProperty smoothness;
        private SerializedProperty metallic;
        private SerializedProperty occlusionSize;
        private SerializedProperty instanceMesh;
        private SerializedProperty WorldExtent;
        private SerializedProperty WorldOffset;
        private SerializedProperty enableGyro;
        private SerializedProperty worldStep;
        private SerializedProperty gyroScale;
        private SerializedProperty gravity;
        private SerializedProperty enableForceField;
        private SerializedProperty forceFieldScale;
        private SerializedProperty enableDebug;
        private SerializedProperty colliderCol;
        private SerializedProperty triggerCol;
        private SerializedProperty enableWorldBoundary;
        private SerializedProperty collisionType;
        private SerializedProperty frictionCoefficient;
        private SerializedProperty restitutionCoefficient;

        private SerializedProperty S2MaxParticleNum;
        private SerializedProperty S2MaxBodyNum;
        private SerializedProperty S2MaxTriggerNum;
        private SerializedProperty S2GridResolution;
        private SerializedProperty S2Substep;
        private SerializedProperty S2MeshBodyForceScale;
        private SerializedProperty S2NormalForceScale;
        private SerializedProperty S2VelocityForceScale;
        private SerializedProperty S2FineGridResolution;
        private SerializedProperty S2EnableWorldQuery;

        private void OnEnable()
        {
            Tools.current = Tool.None;
            Soft2DManager = target as Soft2DManager;
            materialPath = PathInitializer.MainPath + "Materials";
            
            shaderType = serializedObject.FindProperty("shaderType");
            instanceMaterial = serializedObject.FindProperty("instanceMaterial");
            instanceSize = serializedObject.FindProperty("instanceSize");
            emissionColor = serializedObject.FindProperty("emissionColor");
            smoothness = serializedObject.FindProperty("smoothness");
            metallic = serializedObject.FindProperty("metallic");
            occlusionSize = serializedObject.FindProperty("occlusionSize");
            instanceMesh = serializedObject.FindProperty("instanceMesh");
            WorldExtent = serializedObject.FindProperty("worldExtent");
            WorldOffset = serializedObject.FindProperty("worldOffset");
            enableGyro = serializedObject.FindProperty("enableGyro");
            worldStep = serializedObject.FindProperty("timeStep");
            gyroScale = serializedObject.FindProperty("gravity");
            gravity = serializedObject.FindProperty("gravity");
            enableForceField = serializedObject.FindProperty("enableForceField");
            forceFieldScale = serializedObject.FindProperty("forceFieldScale");
            enableDebug = serializedObject.FindProperty("enableDebuggingTools");
            colliderCol = serializedObject.FindProperty("colliderCol");
            triggerCol = serializedObject.FindProperty("triggerCol");
            enableWorldBoundary = serializedObject.FindProperty("enableWorldBoundary");
            collisionType = serializedObject.FindProperty("collisionType");
            frictionCoefficient = serializedObject.FindProperty("frictionCoefficient");
            restitutionCoefficient = serializedObject.FindProperty("restitutionCoefficient");
            
            S2MaxParticleNum = serializedObject.FindProperty("S2MaxParticleNum");
            S2MaxBodyNum = serializedObject.FindProperty("S2MaxBodyNum");
            S2MaxTriggerNum = serializedObject.FindProperty("S2MaxTriggerNum");
            S2GridResolution = serializedObject.FindProperty("S2GridResolution");
            S2Substep = serializedObject.FindProperty("S2Substep");
            S2MeshBodyForceScale = serializedObject.FindProperty("S2MeshBodyForceScale");
            S2NormalForceScale = serializedObject.FindProperty("S2NormalForceScale");
            S2VelocityForceScale = serializedObject.FindProperty("S2VelocityForceScale");
            S2FineGridResolution = serializedObject.FindProperty("S2FineGridScale");
            S2EnableWorldQuery = serializedObject.FindProperty("S2EnableWorldQuery");
        }

        #endregion

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("World Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.PropertyField(WorldExtent, new GUIContent("World Extent","Simulated area of scale"));
            EditorGUILayout.PropertyField(WorldOffset, new GUIContent("World Offset","Simulated area of position"));
            if (!Soft2DManager.enableGyro)
                EditorGUILayout.PropertyField(gravity, new GUIContent("Gravity","Gravity's scale & direction"));
            EditorGUILayout.PropertyField(enableGyro, new GUIContent("Enable Gyro","Enable Gyro Scope as gravity"));
            if (Soft2DManager.enableGyro)
                EditorGUILayout.PropertyField(gyroScale, new GUIContent("Gyro Scale","Gyroscope's gravity scale"));
            EditorGUILayout.PropertyField(enableForceField, new GUIContent("Enable Force Field","Enable force field"));
            if (Soft2DManager.enableForceField)
                EditorGUILayout.PropertyField(forceFieldScale, new GUIContent("Force Field Scale","Force field scale"));
            EditorGUILayout.PropertyField(enableWorldBoundary, new GUIContent("Enable World Boundary","Enable world boundary"));
            if (Soft2DManager.enableWorldBoundary)
            {
                EditorGUILayout.PropertyField(collisionType, new GUIContent("Collision Type", "Boundary's collision type"));
                EditorGUILayout.Slider(frictionCoefficient, 0, 1,
                    new GUIContent("Friction Coefficient", "Boundary's coefficient of friction"));
                EditorGUILayout.Slider(restitutionCoefficient, 0, 1,
                    new GUIContent("Restitution Coefficient", "Boundary's coefficient of restitution"));
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Debugging Tools Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.PropertyField(enableDebug, new GUIContent("Enable Debugging Tools","enable Debugging Tools"));
            if (Soft2DManager.enableDebuggingTools)
            {
                EditorGUILayout.PropertyField(colliderCol, new GUIContent("Collider Color","Collider's color showed on Debugging Tools"));
                EditorGUILayout.PropertyField(triggerCol, new GUIContent("Trigger Color","Trigger's color showed on Debugging Tools"));
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Render Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(instanceMesh, new GUIContent("Instance Mesh","Particle instance's mesh"));
            int layer = EditorGUILayout.LayerField("Particle Sorting Layer", Soft2DManager.layerIndex);
            EditorGUILayout.Space(10);
            EditorGUILayout.PropertyField(shaderType, new GUIContent("Particle Render Mode","Particle's render mode"));
            EditorGUILayout.BeginVertical("box");
            if (Soft2DManager.shaderType == ShaderType.Unlit)
            {
                Soft2DManager.instanceMaterial =
                    AssetDatabase.LoadAssetAtPath<Material>(materialPath + "/UnlitParticleMat.mat");
                EditorGUILayout.PropertyField(instanceSize, new GUIContent("Instance Size","Particle instance's size"));
            }
            else if (Soft2DManager.shaderType == ShaderType.Blinn_Phong)
            {
                Soft2DManager.instanceMaterial =
                    AssetDatabase.LoadAssetAtPath<Material>(materialPath + "/3DParticleMat.mat");
                EditorGUILayout.PropertyField(instanceSize, new GUIContent("Instance Size","Particle instance's size"));
                EditorGUILayout.Slider(smoothness, 0f, 1f, new GUIContent("Smoothness",""));
            }
            else if (Soft2DManager.shaderType == ShaderType.PBR)
            {
                Soft2DManager.instanceMaterial =
                    AssetDatabase.LoadAssetAtPath<Material>(materialPath + "/PBRParticleMat.mat");
                EditorGUILayout.PropertyField(instanceSize, new GUIContent("Instance Size","Particle instance's size"));
                EditorGUILayout.Slider(smoothness, 0f, 1f, new GUIContent("Smoothness",""));
                EditorGUILayout.Slider(metallic, 0f, 1f, new GUIContent("Metallic",""));
                EditorGUILayout.Slider(occlusionSize, 0f, 1f, new GUIContent("Occlusion Size",""));
                EditorGUILayout.PropertyField(emissionColor, new GUIContent("Emission Color",""));
            }
            else
            {
                EditorGUILayout.PropertyField(instanceMaterial);
                DrawMaterialProperties(Soft2DManager.instanceMaterial);
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(Soft2DManager);
                Soft2DManager.layerIndex = layer;
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Time Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(worldStep, new GUIContent("Time Step","Soft2D's simulated time step"));
            EditorGUILayout.PropertyField(S2Substep, new GUIContent("SubStep","The time step of the internal sub-step"));
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Max Num Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(S2MaxParticleNum, new GUIContent("Max Particle Number", "The maximum allowed number of particles"));
            EditorGUILayout.PropertyField(S2MaxBodyNum, new GUIContent("Max Body Number", "The maximum allowed number of bodies"));
            EditorGUILayout.PropertyField(S2MaxTriggerNum, new GUIContent("Max Trigger Number", "The maximum allowed number of triggers"));
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Resolution Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(S2GridResolution, new GUIContent("Grid Resolution","Debugging Tools' gird resolution"));
            EditorGUILayout.PropertyField(S2FineGridResolution, new GUIContent("Fine Grid Scale", "A scale factor of fine grid resolution compared to background grid resolution"));
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Collision Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(S2NormalForceScale, new GUIContent("Normal Force Scale", "Collision penalty force scale along normal direction"));
            EditorGUILayout.PropertyField(S2VelocityForceScale, new GUIContent("Velocity Force Scale", "Collision penalty force scale along velocity direction"));
            EditorGUILayout.PropertyField(S2MeshBodyForceScale, new GUIContent("Mesh Body Force Scale", ""));
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("World Query Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(S2EnableWorldQuery, new GUIContent("Enable World Query", "Whether enable world query"));

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawMaterialProperties(Material material)
        {
            if (material != null)
            {
                if (_materialEditor == null)
                {
                    _materialEditor = (MaterialEditor)CreateEditor(material);
                }
                else if (_materialEditor.target != material)
                {
                    DestroyImmediate(_materialEditor);
                    _materialEditor = (MaterialEditor)CreateEditor(material);
                }

                _materialEditor.DrawHeader();
                _materialEditor.OnInspectorGUI();
            }
        }
    }
}
