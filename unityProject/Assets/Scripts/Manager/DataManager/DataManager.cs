using System;
using System.Collections.Generic;
using UnityEngine;
using UI.Data;
using UnityEngine.UI;

namespace DataMgr
{
    public class DataManager : SingletonMono<DataManager>
    {
        string personFilePath = "filepath temp";
        List<PartData> parts = new List<PartData>();

        void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// 传入一个Transform,将节点下的东西转成PartData对象并放入数组中，注意现在用的画布要和以后读取的一致
        /// trans下的节点分为：group_handleg,group_body,group_ryrmouthhair,group_hatheadwear
        /// </summary>
        /// <param name="trans">Trans.</param>
        public void TransformToPartsList(Transform trans)
        {
            for (int i = 0; i < trans.childCount; i++)
            {
                Transform t = trans.GetChild(i);
                for (int j = 0; j < t.childCount; j++)
                {
                    Transform img = t.GetChild(j);
                    PartType type = img.GetComponent<ResDragItem>().partType;
                    byte[] b = img.GetComponent<Image>().sprite.texture.EncodeToPNG();
                    float[] pos = new float[] { img.localPosition.x, img.localPosition.y, img.localPosition.z };
                    float[] scale = new float[] { img.localScale.x, img.localScale.y, img.localScale.z };
                    PartData p = new PartData(type,b, pos, scale);
                    parts.Add(p);
                }
            }
            Debug.Log("个数：" + parts.Count);
        }
    }
}