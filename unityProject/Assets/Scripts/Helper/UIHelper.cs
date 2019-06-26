using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ResMgr;
using UnityEngine.UI;

namespace Helper
{
    public class UIHelper : SingletonMono<UIHelper>
    {
        void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// 加载AB使用的是xx/xx|a 这样的路径，现在用Resources加载要转换成xx/xx/a
        /// </summary>
        /// <param name="path"></param>
        private string PathToResourcePath(string path)
        {
            string[] strLst = path.Split('|');
            string newPath = strLst[0] + "/" + strLst[1];
            return newPath;
        }

        public void SetImage(string path, Image image, bool useNativeSize = false, Action cb = null)
        {
            //path = PathToResourcePath(path);
            image.sprite = ResManager.instance.LoadSprite(path);
            //image.sprite = Resources.Load(path,typeof(Sprite)) as Sprite;
            if (useNativeSize)
            {
                image.SetNativeSize();
            }
            if (cb != null)
            {
                cb();
            }
        }

        public Sprite LoadSprite(string path)
        {
            Debug.Log(path);
            //path = PathToResourcePath(path);
            return ResManager.instance.LoadSprite(path);
            //Sprite s = Resources.Load(path,typeof(Sprite)) as Sprite;
            //return s;
        }


        /// <summary>
        /// Loads the prefab.
        /// </summary>
        /// <returns>The prefab.</returns>
        /// <param name="path">prefab预制体路径.</param>
        /// <param name="parent">父节点.</param>
        /// <param name="pos">初始位置.</param>
        /// <param name="scale">初始缩放.</param>
        /// <param name="stretch">是否是四周拉伸.</param>
        public GameObject LoadPrefab(string path, Transform parent, Vector3 pos, Vector3 scale, bool stretch = false)
        {
            //path = PathToResourcePath(path);
            UnityEngine.Object obj = ResManager.instance.LoadObject(path);
            //UnityEngine.Object obj = Resources.Load(path);
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.SetParent(parent);
            go.transform.localPosition = pos;
            go.transform.localScale = scale;
            if (stretch == true)
            {
                go.transform.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                go.transform.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            }
            return go;
        }

        public void LoadPrefabAsync(string path, Transform parent, Vector3 pos, Vector3 scale, bool stretch = false,Action<float> progressCall = null, Action<GameObject> loadCall = null)
        {
            StartCoroutine(Cor_LoadPrefabAsync(path, parent, pos, scale, stretch, progressCall,loadCall));
        }

        public IEnumerator Cor_LoadPrefabAsync(string path, Transform parent, Vector3 pos, Vector3 scale, bool stretch = false, Action<float> progressCall = null,Action<GameObject> loadCall=null)
        {
            path = PathToResourcePath(path);
            float progress;
            yield return new WaitForEndOfFrame();
            ResourceRequest request = Resources.LoadAsync(path);
            while (!request.isDone)
            {
                if (request.progress < 0.9f)
                {
                    progress = request.progress;
                }
                else
                {
                    progress = 1.0f;
                }
                progressCall?.Invoke(progress);

                yield return null;
            }
            /*
            float progress;
            yield return new WaitForEndOfFrame();
            AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(path);
            while (!abcr.isDone)
            {
                if (abcr.progress < 0.9f)
                {
                    progress = abcr.progress;
                }
                else
                {
                    progress = 1.0f;
                }
                progressCall?.Invoke(progress);

                yield return null;
            }
            */
            GameObject go = Instantiate(request.asset) as GameObject;
            go.transform.SetParent(parent);
            go.transform.localPosition = pos;
            go.transform.localScale = scale;
            if (stretch == true)
            {
                go.transform.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                go.transform.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            }
            loadCall?.Invoke(go);
            yield return go;
        }

        public AnimationClip LoadAnimationClip(string path)
        {
            //path = PathToResourcePath(path);
            //AnimationClip clip = Resources.Load<AnimationClip>(path) as AnimationClip;
            AnimationClip clip = ResManager.instance.LoadAnimationClip(path);
            return clip;
        }

        public AudioClip LoadAudioClip(string path)
        {
            //path = PathToResourcePath(path);
            //AudioClip clip = Resources.Load<AudioClip>(path) as AudioClip;
            return ResManager.instance.LoadAudioClip(path);
        }

        public RuntimeAnimatorController LoadAnimationController(string path)
        {
            //path = PathToResourcePath(path);
            //RuntimeAnimatorController aniController = Resources.Load<RuntimeAnimatorController>(path) as RuntimeAnimatorController;
            return ResManager.instance.LoadAnimationController(path);
        }


        /*
        public void SetImage(string path, Image image, bool useNativeSize = false, Action cb = null)
        {
            image.sprite = ResManager.instance.LoadSprite(path);
            if (useNativeSize)
            {
                image.SetNativeSize();
            }
            if (cb != null)
            {
                cb();
            }
        }

        public Sprite LoadSprite(string path)
        {
            return ResManager.instance.LoadSprite(path);
        }
        

        /// <summary>
        /// Loads the prefab.
        /// </summary>
        /// <returns>The prefab.</returns>
        /// <param name="path">prefab预制体路径.</param>
        /// <param name="parent">父节点.</param>
        /// <param name="pos">初始位置.</param>
        /// <param name="scale">初始缩放.</param>
        /// <param name="stretch">是否是四周拉伸.</param>
        public GameObject LoadPrefab(string path, Transform parent, Vector3 pos, Vector3 scale,bool stretch = false)
        {
            UnityEngine.Object obj = ResManager.instance.LoadObject(path);
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.SetParent(parent);
            go.transform.localPosition = pos;
            go.transform.localScale = scale;
            if (stretch==true)
            {
                Debug.Log("strtch");
                go.transform.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                go.transform.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            }
            return go;
        }

        /// <summary>
        /// Loads the prefab.
        /// </summary>
        /// <returns>The prefab.</returns>
        /// <param name="path">prefab预制体路径.</param>
        /// <param name="parent">父节点.</param>
        /// <param name="pos">初始位置(世界坐标).</param>
        /// <param name="scale">初始缩放.</param>
        public GameObject LoadPrefab3D(string path, Transform parent, Vector3 pos, Vector3 scale)
        {
            UnityEngine.Object obj = ResManager.instance.LoadObject(path);
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.SetParent(parent);
            go.transform.localScale = scale;
            int childCount = parent.childCount;
            float posZ = -0.1f*childCount;
            go.transform.position = new Vector3(pos.x, pos.y, posZ);
            return go;
        }*/

    }
}
