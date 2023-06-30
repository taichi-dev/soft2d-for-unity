#if UNITY_EDITOR

using System;
using System.IO;
using Taichi.Soft2D.Plugin;
using UnityEditor;
using UnityEditor.Build;
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
        GUILayout.Label("Before using Soft2D for Unity,please " +
                        "click \"Run and Restart\" button, which will perform the following actions:\n" + 
                        "1. The project's Graphics API setting will be modified to Vulkan or Metal.\n" + 
                        "2. The project's Scripting Backend setting will be modified to IL2CPP.\n" + 
                        "3. If the current rendering pipeline is the URP, a macro \"SOFT2D_URP_PIPELINE\" will be added into the project settings.",
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
        if (GraphicsSettings.renderPipelineAsset != null && GraphicsSettings.renderPipelineAsset.GetType().Name == "UniversalRenderPipelineAsset")
        {
            CreateNewLayer("Soft2D");
            SetDefineSymbols(NamedBuildTarget.Android);
            SetDefineSymbols(NamedBuildTarget.Standalone);
            SetDefineSymbols(NamedBuildTarget.iOS);
        }
        
        // Restart this project
        EditorApplication.OpenProject(Application.dataPath.Substring(0, Application.dataPath.Length - "Assets".Length));
    }

    private void SetDefineSymbols(NamedBuildTarget buildTarget)
    {
        string[] symbols;
        PlayerSettings.GetScriptingDefineSymbols(buildTarget, out symbols);
        Array.Resize(ref symbols, symbols.Length + 1);
        symbols[^1] = "SOFT2D_URP_PIPELINE";
        PlayerSettings.SetScriptingDefineSymbols(buildTarget, "SOFT2D_URP_PIPELINE");
    }
    
    public static void CreateNewLayer(string layerName)
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty layersProperty = tagManager.FindProperty("layers");
        
        SerializedProperty layerProperty = layersProperty.GetArrayElementAtIndex(8);
        if (string.IsNullOrEmpty(layerProperty.stringValue))
        {
            layerProperty.stringValue = layerName;
        }
        tagManager.ApplyModifiedProperties();
    }
}
#endif
