#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using Taichi.Soft2D.Plugin;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Rendering;


public class InitializeSystem : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            
            if (str.EndsWith("soft2d_core.cs") && !EditorPrefs.GetBool("Soft2DInstalled"))
            {
                CheckGraphicsAPIWindow window = EditorWindow.GetWindow<CheckGraphicsAPIWindow>();
                window.Show();
                EditorPrefs.SetBool("Soft2DInstalled",true);
            }
        }
    }
}

public class CheckGraphicsAPIWindow : EditorWindow
{
    private string currentAPI;
    // private Texture2D icon;

    [MenuItem("Window/Soft2D/Check Graphics API")]
    public static void ShowWindow()
    {
        GetWindow<CheckGraphicsAPIWindow>("Soft2D Startup Window");
    }

    private void OnGUI()
    {
        // icon = AssetDatabase.LoadAssetAtPath<Texture2D>(PathInitializer.MainPath + "Textures/logo.png");
        // GUILayout.Label(icon);

        // GUILayout.Space(10);
        GUILayout.Label("Before using Soft2d-Unity plugin, please " +
                                 "ensure that your current project is using " +
                                 "Vulkan or Metal graphics API,\n for Soft2D only supports " +
                                 "them currently. Using other graphics APIs " +
                                 "may cause your project to crash.",
            EditorStyles.boldLabel,GUILayout.ExpandWidth(true));

        EditorGUILayout.Space(10);
        currentAPI = PlayerSettings.GetGraphicsAPIs(BuildTarget.StandaloneWindows64)[0].ToString();
        EditorGUILayout.LabelField("Current Graphics API: " + currentAPI, EditorStyles.largeLabel);

        if (currentAPI != "Vulkan")
        {
            EditorGUILayout.HelpBox("Your project isn't using Vulkan Graphics API!Click the button below to switch to Vulkan.",MessageType.Error);
            if (GUILayout.Button("Switch to Vulkan"))
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.Android,new [] { GraphicsDeviceType.Vulkan });
                PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64,new [] { GraphicsDeviceType.Vulkan });
            }

            if (GUILayout.Button("I will switch it myself later"))
            {
                this.Close();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Your project is using Vulkan Graphics API. Restart and enjoy Soft2D!",MessageType.Info);
            if (GUILayout.Button("Restart Project Now"))
            {
                UnityEditor.EditorApplication.OpenProject(Application.dataPath.Substring(0, Application.dataPath.Length - "Assets".Length));
            }
            if (GUILayout.Button("Restart Project Later"))
            {
                this.Close();
            }
        }
    }
}
#endif
