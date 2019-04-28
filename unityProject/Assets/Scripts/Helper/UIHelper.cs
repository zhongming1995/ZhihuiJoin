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
            path = PathToResourcePath(path);
            //image.sprite = ResManager.instance.LoadSprite(path);
            image.sprite = Resources.Load(path,typeof(Sprite)) as Sprite;
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
            path = PathToResourcePath(path);
            //return ResManager.instance.LoadSprite(path);
            Sprite s = Resources.Load(path,typeof(Sprite)) as Sprite;
            return s;
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
            path = PathToResourcePath(path);
            //UnityEngine.Object obj = ResManager.instance.LoadObject(path);
            UnityEngine.Object obj = Resources.Load(path);
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.SetParent(parent);
            go.transform.localPosition = pos;
            go.transform.localScale = scale;
            if (stretch == true)
            {
                Debug.Log("stretch");
                go.transform.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                go.transform.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            }
            return go;
        }

        public AnimationClip LoadAnimationClip(string path)
        {
            path = PathToResourcePath(path);
            AnimationClip clip = Resources.Load<AnimationClip>(path) as AnimationClip;
            return clip;
        }

        public AudioClip LoadAudioClip(string path)
        {
            path = PathToResourcePath(path);
            AudioClip clip = Resources.Load<AudioClip>(path) as AudioClip;
            return clip;
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
