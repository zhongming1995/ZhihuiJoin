/*  主要用于贴图资源导入时批量处理   */
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

namespace Common.PreImprot.Editor
{
    /// <summary>
    /// 各类资源导入时的压缩方式等设置
    /// </summary>
    public class PreImportTexture : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            if (assetPath.Contains("Res/Atlas") || assetPath.Contains("Res/Sprite")||assetPath.Contains("Res/Resources/Sprite"))
            {
                string atlasName = new DirectoryInfo(Path.GetDirectoryName(assetPath)).Name;
                TextureImporter textureImporter = assetImporter as TextureImporter;
                //string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1);
                //assetName = assetName.Replace(".png", string.Em pty);
                //if (atlasName == "Atlas")
                {
                    textureImporter.textureType = TextureImporterType.Sprite;
                    textureImporter.spritePackingTag = null; //atlasName;
                    textureImporter.mipmapEnabled = false;
                    textureImporter.spriteImportMode = SpriteImportMode.Single;
                    textureImporter.filterMode = FilterMode.Bilinear;
                    //textureImporter.maxTextureSize = 2048;
                    //textureImporter.isReadable = false;

                    //textureImporter.ClearPlatformTextureSettings("android");
                    //textureImporter.ClearPlatformTextureSettings("iPhone");
                    //textureImporter.ClearPlatformTextureSettings("Standalone");

#if UNITY_ANDROID
                    //TextureImporterPlatformSettings androidTextureImporterPlatformSettings = new TextureImporterPlatformSettings();
                    //androidTextureImporterPlatformSettings.format = TextureImporterFormat.RGBA32;
                    //androidTextureImporterPlatformSettings.textureCompression = TextureImporterCompression.Uncompressed;
                    //androidTextureImporterPlatformSettings.overridden = true;
                    //textureImporter.SetPlatformTextureSettings(androidTextureImporterPlatformSettings);
#endif
#if UNITY_IOS
                    TextureImporterPlatformSettings iOSTextureImporterPlatformSettings = new TextureImporterPlatformSettings();
                    iOSTextureImporterPlatformSettings.format = TextureImporterFormat.PVRTC_RGBA4;
                    iOSTextureImporterPlatformSettings.textureCompression = TextureImporterCompression.Uncompressed;
                    iOSTextureImporterPlatformSettings.overridden = true;
                    textureImporter.SetPlatformTextureSettings(iOSTextureImporterPlatformSettings);
#endif
                }
            }

            if (assetPath.Contains("Res/Textures"))
            {
                string atlasName = new DirectoryInfo(Path.GetDirectoryName(assetPath)).Name;
                TextureImporter textureImporter = assetImporter as TextureImporter;
                //string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1);
                //assetName = assetName.Replace(".png", string.Empty);
                //if (atlasName == "Atlas")
                {
                    string fileName = assetPath.Substring(assetPath.LastIndexOf("/"));
                    MemoryStream mstream = new MemoryStream();
                    FileStream fs = new FileStream(textureImporter.assetPath, FileMode.Open);
                   
                    byte[] byteData = new byte[fs.Length];
                    fs.Read(byteData, 0, byteData.Length);
                    fs.Close();
                    string root = Application.dataPath.Substring(0, Application.dataPath.IndexOf("Assets"));
                    string path = root  + textureImporter.assetPath;
                    Debug.LogError(path.LastIndexOf("/"));
                    path = path.Substring(0, path.LastIndexOf("/"))+"/"+ fileName+ ".bytes";
                    Debug.LogError(atlasName);
                    Debug.LogError(path);
                    Stream s = new FileStream(path, FileMode.Create);
                    BinaryWriter sw = new BinaryWriter(s, Encoding.Unicode);
                    for (int i = 0; i < byteData.Length; i++)
                    {
                        sw.Write(byteData[i]);
                    }
                    sw.Flush();
                    sw.Close();
                    s.Close();

                    textureImporter.textureType = TextureImporterType.Default;
                    textureImporter.spritePackingTag = null; //atlasName;
                    textureImporter.mipmapEnabled = false;
                    textureImporter.npotScale = TextureImporterNPOTScale.None;
                    textureImporter.filterMode = FilterMode.Bilinear;
                    textureImporter.isReadable = false;

                    textureImporter.ClearPlatformTextureSettings("android");
                    textureImporter.ClearPlatformTextureSettings("iPhone");
                    textureImporter.ClearPlatformTextureSettings("Standalone");

#if UNITY_ANDROID
                    //TextureImporterPlatformSettings androidTextureImporterPlatformSettings = new TextureImporterPlatformSettings();
                    //androidTextureImporterPlatformSettings.format = TextureImporterFormat.RGBA32;
                    //androidTextureImporterPlatformSettings.textureCompression = TextureImporterCompression.Uncompressed;
                    //androidTextureImporterPlatformSettings.overridden = true;
                    //textureImporter.SetPlatformTextureSettings(androidTextureImporterPlatformSettings);
#endif
#if UNITY_IOS
                    //TextureImporterPlatformSettings iOSTextureImporterPlatformSettings = new TextureImporterPlatformSettings();
                    //iOSTextureImporterPlatformSettings.format = TextureImporterFormat.RGBA32;
                    //iOSTextureImporterPlatformSettings.textureCompression = TextureImporterCompression.Uncompressed;
                    //iOSTextureImporterPlatformSettings.overridden = true;
                    //textureImporter.SetPlatformTextureSettings(iOSTextureImporterPlatformSettings);
#endif
                }
            }
            if (assetPath.Contains("Res/Materials"))
            {
                TextureImporter textureImporter = assetImporter as TextureImporter;
                //暂不知压缩格式
            }
            AssetDatabase.SaveAssets();
        }
    }
}