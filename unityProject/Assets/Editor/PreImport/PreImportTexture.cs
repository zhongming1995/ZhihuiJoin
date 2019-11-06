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
                    textureImporter.spritePackingTag = string.Empty; //atlasName;
                    textureImporter.mipmapEnabled = false;
                    textureImporter.spriteImportMode = SpriteImportMode.Single;
                    textureImporter.filterMode = FilterMode.Bilinear;
                    textureImporter.maxTextureSize = 2048;
                    //textureImporter.isReadable = false;

                    textureImporter.ClearPlatformTextureSettings("android");
                    textureImporter.ClearPlatformTextureSettings("iPhone");
                    textureImporter.ClearPlatformTextureSettings("Standalone");

#if UNITY_ANDROID
                    TextureImporterPlatformSettings androidTextureImporterPlatformSettings = new TextureImporterPlatformSettings();
                    androidTextureImporterPlatformSettings.format = TextureImporterFormat.RGBA32;
                    androidTextureImporterPlatformSettings.textureCompression = TextureImporterCompression.Uncompressed;
                    androidTextureImporterPlatformSettings.overridden = true;
                    textureImporter.SetPlatformTextureSettings(androidTextureImporterPlatformSettings);
#endif
#if UNITY_IOS
                    //TextureImporterPlatformSettings iOSTextureImporterPlatformSettings = new TextureImporterPlatformSettings();
                    //iOSTextureImporterPlatformSettings.format = TextureImporterFormat.PVRTC_RGBA4;
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