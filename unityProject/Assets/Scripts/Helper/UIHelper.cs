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
    }
}
