namespace Taichi.Soft2D.Plugin
{
    using UnityEngine;
    using UnityEditor;
    
    public class PathInitializer : ScriptableObject
    {
        private static string _mainPath;
        private static ScriptableObject path;
        public static string MainPath
        {
            get { return _mainPath ??= GetMainPath(); }
            set => _mainPath = value;
        }
        
        private static string GetMainPath()
        {
#if UNITY_EDITOR
            if (path == null)
            {
                path = CreateInstance<PathInitializer>();
            }

            MonoScript ms = MonoScript.FromScriptableObject(path);
            string absolutePath = AssetDatabase.GetAssetPath(ms);
            string assetsFolder = "PathInitializer.cs";
            int assetsFolderIndex = absolutePath.IndexOf(assetsFolder);
            string filePath = absolutePath.Substring(0, assetsFolderIndex);
            return filePath;
#endif
            return string.Empty;
        }
    }
}