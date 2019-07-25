using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEditor;

namespace ResMgr
{
    public class ResManager : SingletonMono<ResManager>
    {
        //字典存放加载过的AssetBundle，ex: "Sprite/homeitems.ab":ab
        private Dictionary<string, AssetBundle> _assetBundleDic = new Dictionary<string, AssetBundle>();
        //字段存放加载过的res，ex: "Prefabs/home|home_item":res
        private Dictionary<string, Object> _resDic = new Dictionary<string, Object>();

        //加载AssetBundleManifest的超时时间
        private const byte TIMEOUT = 30;
        //总Manifest
        AssetBundleManifest mainManifest;
         
        void Awake()
        {
            instance = this;
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
                //Debug.Log("存在该bundle");
                return bundle.GetAllAssetNames();

            }
            else
            {
                bundle = LoadAssetBundle(bundleName);
                return bundle.GetAllAssetNames();
            }
        }

        /// <summary>
        /// 同步加载MainAssetBundle
        /// </summary>
        /// <returns><c>true</c>, if main asset bundle was loaded, <c>false</c> otherwise.</returns>
        /// <param name="completeCall">Complete call.</param>

        public bool LoadMainAssetBundle()
        {
#if UNITY_EDITOR && EditorDebug
                    Debug.Log("==========测试模式，不加载ab");
#else
            Debug.Log("UnityTest====================平台：" + ResConf.resPlatForm);
            string path = ResUtil.GetStreamingAssetPathWithoutFile(ResConf.BUNDLE_NAME);//用LoadFromFile方法不能加file://
                                                                                        //Debug.Log("UnityTest====================path:" + path);
            AssetBundle bundle = AssetBundle.LoadFromFile(path);
            mainManifest = bundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            bundle.Unload(false);
            bundle = null;
#endif
            return true;
        }


        /// <summary>
        /// 异步加载MainAssetBundle
        /// </summary>
        /// <returns><c>true</c>, if main asset bundle was loaded, <c>false</c> otherwise.</returns>
        /// <param name="completeCall">Complete call.</param>
        public void LoadMainAssetBundleAsync(Action completeCall = null)
        {
#if UNITY_EDITOR&&EditorDebug
            Debug.Log("==========测试模式，不加载ab");
#else
            Debug.Log("UnityTest====================平台：" + ResConf.resPlatForm);
            string path = ResUtil.GetStreamingAssetPathWithoutFile(ResConf.BUNDLE_NAME);//用LoadFromFile方法不能加file://
            Debug.Log("UnityTest====================path:" + path);
            StartCoroutine(Cor_LoadAssetBundle(path,(resultBundle) =>
            {
                Debug.Log("Cor_LoadAssetBundle CallBack===========");
                StartCoroutine(Cor_LoadAsset<AssetBundleManifest>(resultBundle,"AssetBundleManifest", (resultAsset) =>
                {
                    Debug.Log("Cor_LoadAsset CallBack");
                    mainManifest = resultAsset as AssetBundleManifest;
                    resultBundle.Unload(false);
                    resultBundle = null;
                    if (completeCall!=null)
                    {
                        Debug.Log("=============CopleteClal");
                        completeCall();
                    }
                }));
            }));
#endif
        }
     
        /// <summary>
        /// 同步加载AssetBundle
        /// </summary>
        /// <param name="bundlePath"></param>
        /// <param name="completeCall"></param>
        /// <returns></returns>
        private AssetBundle LoadAssetBundle(string bundlePath,Action completeCall = null)
        {
            string realBundlePath = string.Format(@"{0}{1}", bundlePath, ResConf.ASSET_BUNDLE_SUFFIX);
            string[] dependeceList = mainManifest.GetAllDependencies(realBundlePath);
            //先加载依赖AssetBundle
            for (int j = 0; j < dependeceList.Length; j++)
            {
                if (_assetBundleDic.ContainsKey(dependeceList[j]))
                {
                    //此依赖已经被加载进来，存在于_assetBundleDic中
                    continue;
                }
                else
                {
                    string bundleFile = ResUtil.GetStreamingAssetPathWithoutFile(dependeceList[j]);
                    AssetBundle dep_Bundle = AssetBundle.LoadFromFile(bundleFile);
                    if (!dep_Bundle)
                    {
                        //加载依赖失败
                    }
                    else
                    {
                        //加载依赖成功
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
                    //加载AssetBundle失败
                    Debug.LogError("加载AssetBundle失败：" + ori_Bundle.name);
                    return null;
                }
                else
                {
                    //加载AssetBundle成功
                    _assetBundleDic.Add(ori_Bundle.name, ori_Bundle);
                    if (completeCall!=null)
                    {
                        completeCall();
                    }
                    return ori_Bundle;
                }
            }
            else
            {
                //此AssetBundle已经被加载进来，存在于_assetBundleDic中
                if (completeCall != null)
                {
                    completeCall();
                }
                return _assetBundleDic[bundlePath];
            }
        }

        /// <summary>
        /// 异步加载AssetBundle
        /// </summary>
        /// <param name="path"></param>
        /// <param name="completeCall"></param>
        /// <returns></returns>
        private void LoadAssetBundleAsync(string bundlePath, Action<AssetBundle> completeCall = null)
        {
            Debug.Log("LoadAssetBundleAsync");
            string realBundlePath = string.Format(@"{0}{1}", bundlePath, ResConf.ASSET_BUNDLE_SUFFIX);
            string[] dependeceList = mainManifest.GetAllDependencies(realBundlePath);
            //先加载依赖AssetBundle
            LoadDependenceListAsync(dependeceList, () => {
                Debug.Log("依赖加载完毕=======");
                //再加载自己本身AssetBundle
                if (!_assetBundleDic.ContainsKey(bundlePath))
                {
                    //AssetBundle ori_Bundle = AssetBundle.LoadFromFile(ResUtil.GetStreamingAssetPathWithoutFile(realBundlePath));
                    StartCoroutine(Cor_LoadAssetBundle(ResUtil.GetStreamingAssetPathWithoutFile(realBundlePath), (resultBundle) => {
                        if (resultBundle == null)
                        {
                            //加载AssetBundle失败
                            Debug.LogError("加载AssetBundle失败：" + resultBundle.name);
                        }
                        else
                        {
                            //加载AssetBundle成功
                            _assetBundleDic.Add(resultBundle.name, resultBundle);
                            if (completeCall != null)
                            {
                                //加载完成
                                completeCall(resultBundle);
                            }
                        }
                    }));
                }
                else
                {
                    //此AssetBundle已经被加载进来，存在于_assetBundleDic中
                    if (completeCall != null)
                    {
                        completeCall(_assetBundleDic[bundlePath]);
                    }
                }
            });
        }

        /// <summary>
        /// 异步加载依赖列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="completeCall"></param>
        /// <returns></returns>
        private void LoadDependenceListAsync(string[] dependeceList,Action completeCall = null)
        {
            Debug.Log("LoadDependenceListAsync:"+dependeceList.Length);
            //先加载依赖AssetBundle
            for (int j = 0; j < dependeceList.Length; j++)
            {
                Debug.Log(j);
                if (_assetBundleDic.ContainsKey(dependeceList[j]))
                {
                    //此依赖已经被加载进来，存在于_assetBundleDic中
                    //continue;
                }
                else
                {
                    string bundleFile = ResUtil.GetStreamingAssetPathWithoutFile(dependeceList[j]);
                    //AssetBundle dep_Bundle = AssetBundle.LoadFromFile(bundleFile);
                    StartCoroutine(Cor_LoadAssetBundle(bundleFile, (resultBundle) => {
                        if (!resultBundle)
                        {
                            //加载依赖失败
                        }
                        else
                        {
                            //加载依赖成功
                            _assetBundleDic.Add(resultBundle.name, resultBundle);
                        }
                    }));
                }
                //加载到最后一个了
                if (j == dependeceList.Length - 1)
                {
                    Debug.Log("zuihouyige");
                    if (completeCall != null)
                    {
                        //依赖加载完毕
                        Debug.Log("completeCall");
                        completeCall();
                    }
                }
            }
        }

        /// <summary>
        /// 异步加载一个物体
        /// </summary>
        /// <param name="path"></param>
        /// <param name="completeCall"></param>
        private void LoadAssetAsync<T>(string path,Action<Object> completeCall) where T : Object
        {
#if UNITY_EDITOR && EditorDebug
            //Debug.Log("=========Resoure加载：" + path);
            UnityEngine.Object result = Resources.Load<T>(path);
            if (result != null)
            {
                completeCall(result);
            }
            else
            {
                Debug.LogError("resource result is null======");
            }
#else
            path = path.ToLower();
            Debug.Log("LoadAssetAsync path=================" + path);
            string[] pathList = path.Split('|');
            string assetBundleName = string.Format(@"{0}{1}", pathList[0], ResConf.ASSET_BUNDLE_SUFFIX);
            //Debug.Log("Load assetBundleName:" + assetBundleName);
            string assetName = pathList[1];
            //Debug.Log("Load assetName：" + assetName);
            if (_resDic.ContainsKey(path))
            {
                Debug.Log("该资源已经被加载过了：" + path);
                UnityEngine.Object asset;
                _resDic.TryGetValue(path, out asset);
                if (asset)
                {
                    //Debug.Log("找到该资源1");
                    if (completeCall!=null)
                    {
                        completeCall(asset);
                    }
                }
                else
                {
                    Debug.LogError("找不到该资源:"+assetName);
                }
            }
            else
            {
                if (!_assetBundleDic.ContainsKey(assetBundleName))
                {
                    Debug.LogError("该AssetBundle还没有被加载进来：" + assetBundleName);
                    //LoadAssetBundle(pathList[0]);
                    LoadAssetBundleAsync(pathList[0], (resultBundle) => {
                        if (resultBundle)
                        {
                            //T asset = resultBundle.LoadAsset<T>(assetName);
                            /*
                            LoadAssetAsync<T>(assetName, (resultObj) => {
                                if (resultObj)
                                {
                                    Debug.Log("asset被加载：" + assetName + ",path:"+path);
                                    _resDic.Add(path, resultObj);
                                }
                                else
                                {
                                    //Debug.LogError("asset加载失败：" + assetName);
                                }
                            });
                            */
                            StartCoroutine(Cor_LoadAsset<T>(resultBundle, assetName, (resultObj) => {
                                if (resultObj)
                                {
                                    Debug.Log("asset被加载：" + assetName + ",path:" + path);
                                    _resDic.Add(path, resultObj);
                                    if (completeCall!=null)
                                    {
                                        completeCall(resultObj);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("asset加载失败：" + assetName);
                                }
                            }));
                           
                        }
                        else
                        {
                            //Debug.LogError("ab不存在");
                        }
                    });
                }
                else
                {
                    Debug.Log("cunzai Ab");
                    AssetBundle resultBundle;
                    _assetBundleDic.TryGetValue(assetBundleName, out resultBundle);
                    if (resultBundle != null)
                    {
                        StartCoroutine(Cor_LoadAsset<T>(resultBundle, assetName, (resultObj) => {
                            if (resultObj)
                            {
                                Debug.Log("asset被加载：" + assetName + ",path:" + path);
                                _resDic.Add(path, resultObj);
                                if (completeCall != null)
                                {
                                    completeCall(resultObj);
                                }
                            }
                            else
                            {
                                Debug.LogError("asset加载失败：" + assetName);
                            }
                        }));
                    }
                }
            }
#endif
        }


        private IEnumerator Cor_LoadAssetBundle(string path,Action<AssetBundle> completeCall = null)
        {
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
            yield return request.assetBundle;
            if (completeCall!=null)
            {
                completeCall(request.assetBundle);
            }
        }

        private IEnumerator Cor_LoadAsset<T>(AssetBundle bundle,string assetName,Action<Object> completeCall = null)
        {
            AssetBundleRequest request = bundle.LoadAssetAsync<T>(assetName);
            yield return request.asset;
            if (completeCall!=null)
            {
                completeCall(request.asset);
            }
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">assetBundleName|assetName</param>
        /// <returns></returns>
        private T Load<T>(string path) where T : Object
        {
            T result = null;
#if UNITY_EDITOR && EditorDebug
            path = ResUtil.PathToResourcePath(path);
            //Debug.Log("=========Resoure加载：" + path);
            result = Resources.Load<T>(path);
            if (result == null)
            {
                Debug.Log("null");
            }
#else
            path = path.ToLower();
            string[] pathList = path.Split('|');
            string assetBundleName = string.Format(@"{0}{1}", pathList[0], ResConf.ASSET_BUNDLE_SUFFIX);
            //Debug.Log("Load assetBundleName:" + assetBundleName);
            string assetName = pathList[1];
           //Debug.Log("Load assetName：" + assetName);
            if (_resDic.ContainsKey(path))
            {
                //Debug.Log("该资源已经被加载过了：" + path);
                UnityEngine.Object asset;
                _resDic.TryGetValue(path, out asset);
                if (asset)
                {
                    //Debug.Log("找到该资源1");
                    return asset as T;
                }
                else
                {
                    //Debug.LogError("找不到该资源1");
                }
            }
            else
            {
                if (!_assetBundleDic.ContainsKey(assetBundleName))
                {
                    //Debug.LogError("该AssetBundle还没有被加载进来：" + assetBundleName);
                    LoadAssetBundle(pathList[0]);
                }
                //Debug.Log(assetBundleName);
                if (_assetBundleDic.ContainsKey(assetBundleName))
                {
                    //Debug.Log("该AssetBundle已经被加载过了：" + assetBundleName);
                    AssetBundle ab;
                    _assetBundleDic.TryGetValue(assetBundleName, out ab);
                    if (ab)
                    {
                        T asset = ab.LoadAsset<T>(assetName);
                        if (asset)
                        {
                            //Debug.Log("asset被加载：" + assetName);
                            _resDic.Add(path, asset);
                            return asset;
                        }
                        else
                        {
                            //Debug.LogError("asset加载失败：" + assetName);
                        }
                    }
                    else
                    {
                        //Debug.LogError("ab不存在");
                    }
                }
                else
                {
                    Debug.Log("wu========");
                }

            }
#endif
            return result;
        }

        public Sprite LoadSprite(string path)
        {
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

        public void LoadObjectAsync(string path,Action<Object> completeCall = null,Action<Object> progressCall = null)
        {
            Debug.Log("LoadObjectAsync==");
            LoadAssetAsync<Object>(path, completeCall);
        }
    }
}
