using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ResMgr
{
    public class ResManager : SingletonMono<ResManager>
    {
        //字典存放加载过的AssetBundle，ex: "sprite/homeitems.ab":ab
        private Dictionary<string, AssetBundle> _assetBundleDic = new Dictionary<string, AssetBundle>();
        //字段存放加载过的res，ex: "prefabs/home|home_item":res
        private Dictionary<string, Object> _resDic = new Dictionary<string, Object>();

        //加载AssetBundleManifest的超时时间
        private const byte TIMEOUT = 30;
        //总Manifest
        AssetBundleManifest mainManifest;
         
        void Awake()
        {
            instance = this;
            LoadMainAssetBundle();
            Debug.Log("Awake=====");
        }

        void Start()
        {
            
        }

        public string[] GetFileListOfAB(string bundleName)
        {
            if (bundleName == null)
            {
                return null;
            }
            AssetBundle bundle = null;
            _assetBundleDic.TryGetValue(bundleName,out bundle);
             if (bundle)
            {
                //Debug.Log("cunzai ");
                return bundle.GetAllAssetNames();

            }
            else
            {
                bundle = LoadAssetBundle(bundleName);
                return bundle.GetAllAssetNames();
            }
        }

        public bool LoadMainAssetBundle(Action completeCall = null)
        {
            //Debug.Log("UnityTest====================平台：" + ResConf.resPlatForm);
            string path = ResUtil.GetStreamingAssetPathWithoutFile(ResConf.BUNDLE_NAME);//用LoadFromFile方法不能加file://
            //Debug.Log("UnityTest====================path:" + path);
            AssetBundle bundle = AssetBundle.LoadFromFile(path);
            mainManifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            bundle.Unload(false);
            return true;
        }

        IEnumerator Cor_LoadAssetBundle(string path,Action<AssetBundle> completeCall = null)
        {
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
            yield return request;
        }

        private AssetBundle LoadAssetBundle(string bundlePath,Action completeCall = null)
        {
            Debug.LogError(bundlePath);
            string realBundlePath = string.Format(@"{0}{1}", bundlePath, ResConf.ASSET_BUNDLE_SUFFIX);
            Debug.LogError(realBundlePath);
            string[] dependeceList = mainManifest.GetAllDependencies(realBundlePath);
            Debug.LogError(dependeceList.Length);
            //先加载依赖AssetBundle
            for (int j = 0; j < dependeceList.Length; j++)
            {
                Debug.LogError("依赖：" + dependeceList[j]);
                if (_assetBundleDic.ContainsKey(dependeceList[j]))
                {
                    Debug.Log("此依赖已经被加载进来，存在于_assetBundleDic中:"+dependeceList[j]);
                    continue;
                }
                else
                {
                    string bundleFile = ResUtil.GetStreamingAssetPathWithoutFile(dependeceList[j]);
                    AssetBundle dep_Bundle = AssetBundle.LoadFromFile(bundleFile);
                    if (!dep_Bundle)
                    {
                        Debug.LogError("加载依赖失败:" + dep_Bundle.name);
                    }
                    else
                    {
                        Debug.Log("加载以来："+dep_Bundle.name);
                        _assetBundleDic.Add(dep_Bundle.name, dep_Bundle);
                    }
                }
            }
            //再加载自己本身AssetBundle
            if (!_assetBundleDic.ContainsKey(bundlePath))
            {
                AssetBundle ori_Bundle = AssetBundle.LoadFromFile(ResUtil.GetStreamingAssetPathWithoutFile(realBundlePath));
                if (ori_Bundle == null)
                {
                    Debug.LogError("加载AssetBundle失败：" + ori_Bundle.name);
                    return null;
                }
                else
                {
                    Debug.Log("加载AssetBundle成功:" + ori_Bundle);
                    _assetBundleDic.Add(ori_Bundle.name, ori_Bundle);
                    Debug.Log("加入字典:" + ori_Bundle.name);
                    Debug.Log(_assetBundleDic.Count);
                    Debug.Log(_assetBundleDic.ContainsKey(ori_Bundle.name));
                    if (completeCall!=null)
                    {
                        completeCall();
                    }
                    return ori_Bundle;
                }
            }
            else
            {
                Debug.Log("此AssetBundle已经被加载进来，存在于_assetBundleDic中:" + bundlePath);
                if (completeCall != null)
                {
                    completeCall();
                }
                return _assetBundleDic[bundlePath];
            }
        }
        
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">assetBundleName|assetName</param>
        /// <returns></returns>
        private T Load<T>(string path) where T : Object
        {
            path = path.ToLower();
            string[] pathList = path.Split('|');
            string assetBundleName = string.Format(@"{0}{1}", pathList[0], ResConf.ASSET_BUNDLE_SUFFIX);
            Debug.Log("Load assetBundleName:" + assetBundleName);
            string assetName = pathList[1];
           //Debug.Log("Load assetName：" + assetName);
//#if UNITY_EDITOR
            //string[] str = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(assetBundleName, assetName);
            //T t = AssetDatabase.LoadAssetAtPath<T>(str[0]);
            //return t;
//#endif
            if (_resDic.ContainsKey(path))
            {
                Debug.Log("该资源已经被加载过了：" + path);
                UnityEngine.Object asset;
                _resDic.TryGetValue(path, out asset);
                if (asset)
                {
                    Debug.Log("找到该资源1");
                    return asset as T;
                }
                else
                {
                    Debug.LogError("找不到该资源1");
                }
            }
            else
            {
                if (!_assetBundleDic.ContainsKey(assetBundleName))
                {
                    Debug.LogError("该AssetBundle还没有被加载进来：" + assetBundleName);
                    LoadAssetBundle(pathList[0]);
                }
                Debug.Log(assetBundleName);
                if (_assetBundleDic.ContainsKey(assetBundleName))
                {
                    Debug.Log("该AssetBundle已经被加载过了：" + assetBundleName);
                    AssetBundle ab;
                    _assetBundleDic.TryGetValue(assetBundleName, out ab);
                    if (ab)
                    {
                        T asset = ab.LoadAsset<T>(assetName);
                        if (asset)
                        {
                            Debug.Log("asset被加载：" + assetName);
                            _resDic.Add(path, asset);
                            return asset;
                        }
                        else
                        {
                            Debug.LogError("asset加载失败：" + assetName);
                        }
                    }
                    else
                    {
                        Debug.LogError("ab不存在");
                    }
                }
                else
                {
                    Debug.Log("wu========");
                }

            }
            return null;
        }

        public Sprite LoadSprite(string path)
        {
            Sprite t = Load<Sprite>(path);
            return Load<Sprite>(path);
        }

        public Object LoadObject(string path)
        {
            return Load<Object>(path);
        }

        public AnimationClip LoadAnimationClip(string path)
        {
            return Load<AnimationClip>(path);
        }

        public AudioClip LoadAudioClip(string path)
        {
            return Load<AudioClip>(path);
        }
        public RuntimeAnimatorController LoadAnimationController(string path)
        {
            return Load<RuntimeAnimatorController>(path);
        }
    }
}


/*
            if (mainManifest)
            {
                //将所有的assetBundle都先加载存到字典
                string[] allAssetList = mainManifest.GetAllAssetBundles();
                
                for (int i = 0; i < allAssetList.Length; i++)
                {
                    string[] dependeceList = mainManifest.GetAllDependencies(allAssetList[i]);
                    //先加载依赖AssetBundle
                    for (int j = 0; j < dependeceList.Length; j++)
                    {
                        if (!_assetBundleDic.ContainsKey(dependeceList[j]))
                        {
                            string bundleFile = ResUtil.GetStreamingAssetPathWithoutFile(dependeceList[j]);
                            AssetBundle dep_Bundle = AssetBundle.LoadFromFile(bundleFile);
                            if (dep_Bundle)
                            {
                                _assetBundleDic.Add(dep_Bundle.name, dep_Bundle);
                            }
                        }
                    }
                    //再加载自己本身AssetBundle
                    if (!_assetBundleDic.ContainsKey(allAssetList[i]))
                    {
                        AssetBundle ori_Bundle = AssetBundle.LoadFromFile(ResUtil.GetStreamingAssetPathWithoutFile(allAssetList[i]));
                        if (ori_Bundle)
                        {
                            _assetBundleDic.Add(ori_Bundle.name, ori_Bundle);
                        }
                    }
                }
                */

//StartCoroutine(LoadAssetBundleManifest(LoadAssetBundleManifestHandler));
//LoadAssetBundleManifest();
/*
IEnumerator LoadAssetBundleManifest(System.Action<bool> loadManifestAction)
{
    string localWWWPath = ResUtil.GetStreamingAssetPath(ResConf.BUNDLE_NAME);
    Debug.Log("streaminPath:" + localWWWPath);
    WWW www = new WWW(localWWWPath);
    float time = Time.realtimeSinceStartup;
    while (!www.isDone)
    {
        if (Time.realtimeSinceStartup - time > TIMEOUT)
        {
            www.Dispose();
            www = null;
            if (loadManifestAction != null)
            {
                loadManifestAction(false);
            }
            yield break;
        }
        yield return null;
    }
    if (!string.IsNullOrEmpty(www.error))
    {
        www.Dispose();
        www = null;
        if (loadManifestAction != null)
        {
            loadManifestAction(false);
        }
        yield break;
    }
    AssetBundle mainfestBundle = www.assetBundle;
    if (mainfestBundle == null)
    {
        www.Dispose();
        www = null;
        if (loadManifestAction != null)
        {
            loadManifestAction(false);
        }
        yield break;
    }
    mainManifest = (AssetBundleManifest)mainfestBundle.LoadAsset("AssetBundleManifest");
    mainfestBundle.Unload(false);
    www.Dispose();
    www = null;
    if (mainManifest == null)
    {
        if (loadManifestAction != null)
        {
            loadManifestAction(false);
        }
        yield return null;
    }
    if (loadManifestAction != null)
    {
        loadManifestAction(true);
    }
}

private void LoadAssetBundleManifestHandler(bool flag)
{
    if (!flag)
    {
        Debug.Log("Load AssetBundleManifest Fail");
    }
    else
    {
        Debug.Log("Load AssetBundleManifest Success");

    }
}
    */
