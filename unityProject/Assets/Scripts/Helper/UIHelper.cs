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
        }
    }
}
