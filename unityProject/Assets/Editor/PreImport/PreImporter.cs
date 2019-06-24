/*  主要用于资源导入时批量处理资源，比如设置assetbundle的tag等    */
using UnityEngine;
using UnityEditor;

namespace Editor.PreImport
{
    public class PreImporter : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (var str in importedAssets)
            {
                if (str.EndsWith(".cs") || str.EndsWith(".js") || str.EndsWith(".asset") || str.EndsWith(".txt"))
                    continue;
                if (!str.Contains(".")) continue;
                //设置atlas ab tag
                if ((str.Contains(@"Assets/Res/Atlas") || str.Contains(@"Assets/Res/Sprite")) && (str.EndsWith(".png") || str.EndsWith(".tga")))
                {
                    AssetImporter assetImport = AssetImporter.GetAtPath(str);
                    if (str.Contains(@"Assets/Res/Atlas/always")/*|| str.Contains(@"Assets/_Res/Atlas/touch")*/)//always目录下的不打包ab
                    {
                        assetImport.assetBundleName = string.Empty;
                    }
                    else
                    {
                        string fileName = str.Substring(str.LastIndexOf("/"));
                        string assetBundleName = str.Replace(@"Assets/Res/", string.Empty);
                        assetBundleName = assetBundleName.Replace(fileName, string.Empty);
                        assetBundleName = assetBundleName.Replace("Atlas", "atlas");
                        assetImport.assetBundleName = assetBundleName;
                        assetImport.assetBundleVariant = ResMgr.ResConf.ASSET_BUNDLE_SUFFIX.Replace(".", string.Empty);
                        Debug.Log("assetBundleName:" + assetBundleName);
                        Debug.Log("prefix:" + assetImport.assetBundleVariant);
                    }
                }
                if (str.Contains(@"Assets/Res/Texture") && (str.EndsWith(".png") || str.EndsWith(".tga")))
                {
                    AssetImporter assetImport = AssetImporter.GetAtPath(str);
                    if (str.Contains(@"Assets/_Res/Atlas/always")/*|| str.Contains(@"Assets/_Res/Atlas/touch")*/)//always目录下的不打包ab
                    {
                        assetImport.assetBundleName = string.Empty;
                    }
                    else
                    {
                        string fileName = str.Substring(str.LastIndexOf("/"));
                        string assetBundleName = str.Replace(@"Assets/Res/", string.Empty);
                        assetBundleName = assetBundleName.Replace(".png", string.Empty);
                        assetBundleName = assetBundleName.Replace("Texture", "texture");
                        //Debugger.Log(assetBundleName+"   "+ fileName);
                        assetImport.assetBundleName = assetBundleName;
                        assetImport.assetBundleVariant = ResMgr.ResConf.ASSET_BUNDLE_SUFFIX.Replace(".", string.Empty);
                    }
                }

                //设置ab tag
                if (str.Contains(@"Res/Models") || str.Contains(@"Res/Materials") || str.Contains(@"Res/Font") || str.Contains(@"Res/Prefabs") || str.Contains(@"Res/textures") || str.Contains(@"Res/Audio") || str.Contains(@"Res/Animator"))
                {
                    AssetImporter assetImport = AssetImporter.GetAtPath(str);
                    if (str.Contains(@"Res/prefabs/download") || str.Contains(@"Res/prefabs/password"))//download ui不打包ab
                    {
                        assetImport.assetBundleName = string.Empty;
                    }
                    else
                    {
                        string fileName = str.Substring(str.LastIndexOf("/"));
                        string extension = str.Substring(str.LastIndexOf("."));
                        //Debugger.LogError(extension);
                        string assetBundleName = str.Replace(@"Assets/Res/", string.Empty);
                        assetBundleName = assetBundleName.Replace(fileName, string.Empty);
                        assetBundleName = assetBundleName.Replace(extension, string.Empty);
                        assetBundleName = assetBundleName.Replace(@"Resources/", string.Empty);
                        assetImport.assetBundleName = assetBundleName;
                        assetImport.assetBundleVariant = ResMgr.ResConf.ASSET_BUNDLE_SUFFIX.Replace(".", string.Empty);
                        Debug.Log("assetBundleName:" + assetBundleName);
                    }
                }
                AssetDatabase.RemoveUnusedAssetBundleNames();
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
