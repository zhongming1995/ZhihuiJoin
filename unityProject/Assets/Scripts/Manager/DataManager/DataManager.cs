using System;
using System.Collections.Generic;
using UnityEngine;
using UI.Data;
using UnityEngine.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataMgr
{
    public class DataManager : SingletonMono<DataManager>
    {
        string personFilePath = "";
        List<PartData> parts = new List<PartData>();

        void Awake()
        {
            instance = this;
            DeserializePersonData();
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
                    Debug.Log("i:" + i + ",j" + j);
                    Transform img = t.GetChild(j);
                    PartType type = img.GetComponent<ResDragItem>().partType;
                    byte[] b = img.GetComponent<Image>().sprite.texture.EncodeToPNG();
                    Debug.Log("length:"+b.Length);
                    float[] pos = new float[] { img.localPosition.x, img.localPosition.y, img.localPosition.z };
                    Debug.Log("pos:"+pos[0] + "|" + pos[1] + "|" + pos[2]);
                    float[] scale = new float[] { img.localScale.x, img.localScale.y, img.localScale.z };
                    PartData p = new PartData(type,b, pos, scale);
                    Debug.Log("scale:" + scale[0] + "|" + scale[1] + "|" + scale[2]);
                    parts.Add(p);
                }
            }
            Debug.Log("个数：" + parts.Count);
            SerializePersonData();
        }

        public void SerializePersonData()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, parts);
            stream.Close();
        }

        public void DeserializePersonData()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<PartData> part = (List<PartData>)formatter.Deserialize(stream);
            stream.Close();

            //Texture2D t = new Texture2D(2048,1536);
            //t.LoadImage(part.ImgBytes);
            //Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
            //imgae.sprite = s;
            Debug.Log(part[0].Pos[0] + "," + part[0].Pos[1] + "," + part[0].Pos[2]);
            Debug.Log(part[0].Scale[0] + "," + part[0].Scale[1] + "," + part[0].Scale[2]);
            Debug.Log(part[1].Pos[0] + "," + part[1].Pos[1] + "," + part[1].Pos[2]);
            Debug.Log(part[1].Scale[0] + "," + part[1].Scale[1] + "," + part[1].Scale[2]);
            Debug.Log(part[2].Pos[0] + "," + part[2].Pos[1] + "," + part[2].Pos[2]);
            Debug.Log(part[2].Scale[0] + "," + part[2].Scale[1] + "," + part[2].Scale[2]);
        }
    }
}