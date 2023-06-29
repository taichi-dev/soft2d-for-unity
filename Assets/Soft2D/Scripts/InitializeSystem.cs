#if UNITY_EDITOR

using System.IO;
using Taichi.Soft2D.Plugin;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class InitializeSystem : AssetPostprocessor
{
    public static bool isSoft2DInstalled = false;
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            if (str.EndsWith("soft2d_core.cs") && !isSoft2DInstalled)
            {
                Soft2DLauncherWindow window = EditorWindow.GetWindow<Soft2DLauncherWindow>();
                window.Show();
                isSoft2DInstalled = true;
            }
        }
    }
}

public class Soft2DLauncherWindow : EditorWindow
{
    [MenuItem("Window/Soft2D/Soft2D Launcher")]
    public static void ShowWindow()
    {
        GetWindow<Soft2DLauncherWindow>("Soft2D Launcher");
    }

    private void OnGUI()
    {
        GUILayout.Label("Before using Soft2D for Unity,\n please " +
                        "click the button below to automatically modify some settings.",
            EditorStyles.boldLabel,GUILayout.ExpandWidth(false));
        EditorGUILayout.Space(20);
        if (GUILayout.Button("Run and Restart"))
        {
            UpdateProjectSettings();
        }
    }

    private void UpdateProjectSettings()
    {
        // Set Graphics APIs
        PlayerSettings.SetGraphicsAPIs(BuildTarget.Android,new [] { GraphicsDeviceType.Vulkan });
        PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows,new [] { GraphicsDeviceType.Vulkan });
        PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneLinux64,new [] { GraphicsDeviceType.Vulkan });
        PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64,new [] { GraphicsDeviceType.Vulkan });
        PlayerSettings.SetGraphicsAPIs(BuildTarget.iOS, new [] { GraphicsDeviceType.Metal });
        
        // Set Scripting Backend
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);

        // Set Default Contact Offset
        Physics2D.defaultContactOffset = 0.001f;
        
        // Set Architecture
        PlayerSettings.SetArchitecture(BuildTargetGroup.Android, 1);
        
        // Check Render Pipeline
        if (GraphicsSettings.defaultRenderPipeline == null)
        {
            string filePath = PathInitializer.MainPath + "/Samples/02_Sandbox/Resources/Materials/KawaseBlur.cs";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        else
        {
            CreateNewLayer("Soft2D");
        }
        
        // Restart this project
        EditorApplication.OpenProject(Application.dataPath.Substring(0, Application.dataPath.Length - "Assets".Length));
    }
    
    public static void CreateNewLayer(string layerName)
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty layersProperty = tagManager.FindProperty("layers");
        
        int emptyLayerIndex = -1;
        for (int i = 8; i < layersProperty.arraySize; i++)
        {
            SerializedProperty layerProperty = layersProperty.GetArrayElementAtIndex(i);
            if (string.IsNullOrEmpty(layerProperty.stringValue))
            {
                emptyLayerIndex = i;
                break;
            }
        }
        
        if (emptyLayerIndex != -1)
        {
            SerializedProperty newLayerProperty = layersProperty.GetArrayElementAtIndex(emptyLayerIndex);
            newLayerProperty.stringValue = layerName;
        }

        tagManager.ApplyModifiedProperties();
    }
}
#endif
