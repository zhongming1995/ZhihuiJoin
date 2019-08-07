using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Helper;
using GameMgr;

namespace DataMgr
{
    public class DataManager : SingletonMono<DataManager>
    {
        string personFilePath = "";

        [HideInInspector]
        public List<PartData> partDataList = new List<PartData>();
        //private DisplayPartItem[] lstDisplayItem ;

        private GameObject curPerson;

        void Awake()
        {
            instance = this;
            //DeserializePersonData();
        }

        /// <summary>
        /// 传入一个Transform,将节点下的东西转成PartData对象并放入数组中，注意现在用的画布要和以后读取的一致
        /// trans下的节点分为：group_handleg,group_body,group_ryrmouthhair,group_hatheadwear
        /// </summary>
        /// <param name="trans">Trans.</param>
        public PartDataWhole TransformToPartsList(Transform trans,int selctIndex,byte[] pixels,byte[] drawPixel)
        {
            List<PartData> parts = new List<PartData>();
            for (int i = 0; i < trans.childCount; i++)
            {
                Transform t = trans.GetChild(i);
                for (int j = 0; j < t.childCount; j++)
                {
                    Transform img = t.GetChild(j);
                    if (img.GetComponent<ResDragItem>()==null)
                    {
                        continue;
                    }
                    PartType type = img.GetComponent<ResDragItem>().partType;
                    byte[] b = img.GetComponent<Image>().sprite.texture.EncodeToPNG();
                    float[] pos = { img.localPosition.x, img.localPosition.y, img.localPosition.z };
                    float[] scale =  { img.localScale.x, img.localScale.y, img.localScale.z };
                    PartData p = new PartData(type,b, pos, scale);
                    parts.Add(p);
                }
            }
            PartDataWhole partDataWhole = new PartDataWhole(selctIndex, pixels, drawPixel, parts);
            partDataList = parts;
            //序列化
            PersonManager.instance.SerializePerson(partDataWhole);
            return partDataWhole;
        }

        /// <summary>
        /// Serializes the person data.
        /// </summary>
        /// <param name="partsList">Parts list.</param>
        public void SerializePersonData(List<PartData> partsList)
        {
            IFormatter formatter = new BinaryFormatter();
            string folderPath = Application.persistentDataPath + "/join_person";
            DirectoryInfo info = new DirectoryInfo(folderPath);
            if (!info.Exists)
            {
                Debug.Log("文件夹不存在:" + folderPath);
                Directory.CreateDirectory(folderPath);
            }
            //按创建时间命名
            //string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff").Replace(":", "-");
            //string personName = "MyPhoto_" + date + ".bin";
            //string savePath = folderPath + "/" + personName;
            //先给一个固定名字
            string savePath = folderPath +"/" + "Person.bin";
            Stream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, partsList);
            stream.Close();
        }
        /*
        public void SerializePerson(PartDataWhole whole)
        {
            IFormatter formatter = new BinaryFormatter();
            //string folderPath = Application.persistentDataPath + "/join_person";
            DirectoryInfo info = new DirectoryInfo(PersonManager.instance.PersonDataPath);
            if (info.Exists)
            {
                Debug.Log("文件夹存在:" + PersonManager.instance.PersonDataPath);
                Directory.CreateDirectory(PersonManager.instance.PersonDataPath);
            }
            //按创建时间命名
            //string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff").Replace(":", "-");
            //string personName = "MyPhoto_" + date + ".bin";
            //string savePath = folderPath + "/" + personName;
            //先给一个固定名字
            //string savePath = folderPath + "/" + "Person.bin";
            string savePath = PersonManager.instance.SavePath;
            Stream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, whole);
            stream.Close();
        }
        */

        /// <summary>
        /// Deserializes the person data.
        /// </summary>
        /// <returns>The person data.</returns>
        public List<PartData> DeserializePersonData(string personPath)
        {
            Debug.Log("DeserializePersonData");
            IFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/join_person/Person.bin";
            if (!File.Exists(path))
            {
                return null;
            }
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            List<PartData> part = (List<PartData>)formatter.Deserialize(stream);
            stream.Close();
            Debug.Log("partcount:" + part.Count);
            return part;
        }



        /*
        public PartDataWhole DeserializePerson()
        {
            Debug.Log("DeserializePerson------");
            IFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/join_person/Person.bin";
            if (!File.Exists(path))
            {
                return null;
            }
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            PartDataWhole whole = (PartDataWhole)formatter.Deserialize(stream);
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            stream.Close();
            return whole;
        }
        */


        /// <summary>
        /// 异步获取人物
        /// </summary>
        /// <returns>The person object.</returns>
        /// <param name="part">Part.</param>
        public void GetPersonObjAsync(List<PartData> part,Action<GameObject> cb = null)
        {
            GameObject person = new GameObject("person");
            //Transform transBody = person.transform;
            float minY = float.MaxValue;
            for (int i = 0; i < part.Count; i++)
            {
                PartType partType = part[i].PType;
                if (partType == PartType.Pixels || partType == PartType.drawPixels)
                {
                    continue;
                }
                Vector3 pos = new Vector3(part[i].Pos[0], part[i].Pos[1], part[i].Pos[2]);
                Vector3 scale = new Vector3(part[i].Scale[0], part[i].Scale[1], part[i].Scale[2]);

                //GameObject obj;
                string path = "Prefabs/display|display_item_" + partType.ToString().ToLower();
                //obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                if (i == part.Count - 1)
                {
                    GetOnePersonAsync(path, person, pos, scale, part[i], cb);
                }
                else
                {
                    GetOnePersonAsync(path, person, pos, scale, part[i], null);
                }
            }
        }

        private void GetOnePersonAsync(string path,GameObject person,Vector3 pos,Vector3 scale,PartData part,Action<GameObject> cb = null)
        {
            Transform transBody = person.transform;
            PartType partType = part.PType;
            UIHelper.instance.LoadPrefabAsync(path, person.transform, pos, scale, false, null, (obj) => {
                if (partType == PartType.LeftLeg || partType == PartType.RightLeg || partType == PartType.LeftHand || partType == PartType.RightHand || partType == PartType.Body)
                {
                    if (partType == PartType.Body)
                    {
                        transBody = obj.transform.Find("img_item").transform;
                    }
                }
                else
                {
                    obj.transform.SetParent(transBody);
                }

                RawImage img = obj.transform.Find("img_item").GetComponent<RawImage>();
                Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                t.filterMode = FilterMode.Point;
                t.LoadImage(part.ImgBytes);
                t.Apply(false);
                //Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
                //img.sprite = s;
                img.texture = t;
                img.SetNativeSize();
                obj.transform.localScale = scale;

                //调整父节点的大小
                float w = img.GetComponent<RectTransform>().sizeDelta.x;
                float h = img.GetComponent<RectTransform>().sizeDelta.y;
                obj.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);

                DisplayPartItem item = obj.AddComponent<DisplayPartItem>();
                item.partType = part.PType;
                item.Init();

                if (cb != null)
                {
                    curPerson = person;
                    GetListDiaplayItem(person.transform);
                    
                    cb(person);
                 
                }
            });
        }

        /// <summary>
        /// Gets the person object by List.
        /// </summary>
        /// <returns>The person object.</returns>
        /// <param name="part">Part.</param>
        public GameObject GetPersonObj(List<PartData> part)
        {
            GameObject person = new GameObject("person");
            Transform transBody = person.transform;
            float minY = float.MaxValue;
            for (int i = 0; i < part.Count; i++)
            {
                PartType partType = part[i].PType;
                if (partType == PartType.Pixels || partType == PartType.drawPixels)
                {
                    continue;
                }
                Vector3 pos = new Vector3(part[i].Pos[0], part[i].Pos[1], part[i].Pos[2]);
                Vector3 scale = new Vector3(part[i].Scale[0], part[i].Scale[1], part[i].Scale[2]);
                
                GameObject obj;
                string path = "Prefabs/display|display_item_" + partType.ToString().ToLower() + " 1";  
                obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                if (partType == PartType.LeftLeg || partType == PartType.RightLeg || partType == PartType.LeftHand || partType == PartType.RightHand || partType == PartType.Body)
                {
                    if (partType == PartType.Body)
                    {
                        transBody = obj.transform.Find("img_item").transform;
                    }
                }
                else
                {
                    obj.transform.SetParent(transBody);
                }

                Image img = obj.transform.Find("img_item").GetComponent<Image>();
                Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                t.filterMode = FilterMode.Point;
                t.LoadImage(part[i].ImgBytes);
                t.Apply(false);
                Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
                img.sprite = s;
                img.SetNativeSize();
                obj.transform.localScale = scale;
               
                //调整父节点的大小
                float w = img.GetComponent<RectTransform>().sizeDelta.x;
                float h = img.GetComponent<RectTransform>().sizeDelta.y;
                obj.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);

                DisplayPartItem item = obj.AddComponent<DisplayPartItem>();
                item.partType = part[i].PType;
                item.Init();
            }
            curPerson = person;
            GetListDiaplayItem(person.transform);
            return person;
        }

        /// <summary>
        /// Gets the person object by List.
        /// </summary>
        /// <returns>The person object.</returns>
        /// <param name="part">Part.</param>
        public GameObject GetPersonObjWithFlag(List<PartData> part,out float minPosY)
        {
            GameObject person = new GameObject("person");
            Transform transBody = person.transform;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            for (int i = 0; i < part.Count; i++)
            {
                Vector3 pos = new Vector3(part[i].Pos[0], part[i].Pos[1], part[i].Pos[2]);
                Vector3 scale = new Vector3(part[i].Scale[0], part[i].Scale[1], part[i].Scale[2]);
                PartType partType = part[i].PType;
                GameObject obj;
                string path = "Prefabs/display|display_item_" + partType.ToString().ToLower();
                obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                if (partType == PartType.LeftLeg || partType == PartType.RightLeg || partType == PartType.LeftHand || partType == PartType.RightHand || partType == PartType.Body)
                {
                    if (partType == PartType.Body)
                    {
                        transBody = obj.transform.Find("img_item").transform;
                    }
                }
                else
                {
                    obj.transform.SetParent(transBody);
                }

                Image img = obj.transform.Find("img_item").GetComponent<Image>();
                Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                t.filterMode = FilterMode.Point;
                t.LoadImage(part[i].ImgBytes);
                t.Apply(false);
                Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
                img.sprite = s;
                img.SetNativeSize();
                obj.transform.localScale = scale;

                //调整父节点的大小
                float w = img.GetComponent<RectTransform>().sizeDelta.x;
                float h = img.GetComponent<RectTransform>().sizeDelta.y;
                obj.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);

                DisplayPartItem item = obj.AddComponent<DisplayPartItem>();
                item.partType = part[i].PType;
                item.Init();
                //Debug.Log(obj.transform.name);
                //Debug.Log("height:"+h);
                //Debug.Log("y:"+obj.GetComponent<RectTransform>().anchoredPosition.y);
                float bottom = obj.GetComponent<RectTransform>().anchoredPosition.y - h / 2;

                if (partType == PartType.Body)
                {
                    float j = Utils.GetPicHeightRate(t);
                    //Debug.Log("resultj================" + j);
                    bottom = h / 2 - h * (1 - j);
                }
                if (minY > bottom)
                {
                    minY = bottom;
                }
                //Debug.Log("bottom:"+bottom);
            }

            GameObject flagObj = new GameObject("flag_bottom");
            flagObj.transform.SetParent(person.transform);
            flagObj.transform.localPosition = new Vector3(0, minY, 0);

            curPerson = person;
            GetListDiaplayItem(person.transform);
            minPosY = minY;
            return person;
        }

        public DisplayPartItem[] GetListDiaplayItem(Transform personObj)
        {
            DisplayPartItem[] lstDisplayItem = personObj.GetComponentsInChildren<DisplayPartItem>(true);
            return lstDisplayItem;
        }

        public float PersonGreeting(DisplayPartItem[] itemList)
        {
            float aniTime = 0;
            if (itemList == null)
            {
                Debug.Log("itemList is null-----");
            }
            for (int i = 0; i < itemList.Length; i++)
            {
                float tmpAniTime = itemList[i].PlayGreeting();
                if (aniTime<tmpAniTime)
                {
                    aniTime = tmpAniTime;
                }
            }
            return aniTime;
        }

        public void PersonDance(DisplayPartItem[] itemList,int n)
        {
            Debug.Log("personDAnce");
            if (itemList == null)
            {
                Debug.Log("itemList is null-----");
                return;
            }
            for (int i = 0; i < itemList.Length; i++)
            {
                if (itemList[i].item_animation.isPlaying)
                {
                    return;
                }
            }
            for (int i = 0; i < itemList.Length; i++)
            {
                itemList[i].PlayDance(n);
            }
        }

        public void PersonDefaultAni(DisplayPartItem[] itemList)
        {
            if (itemList == null)
            {
                Debug.Log("itemList is null-----");
                return;
            }
            for (int i = 0; i < itemList.Length; i++)
            {
                itemList[i].PlayDefault();
            }
        }

        public void PersonBreathe(DisplayPartItem[] itemList)
        {
            if (itemList == null)
            {
                Debug.Log("itemList is null-----");
                return;
            }
            for (int i = 0; i < itemList.Length; i++)
            {
                itemList[i].PlayBreathe();
            }
        }

        public void PersonJumpAndWave(DisplayPartItem[] itemList)
        {
            if (itemList == null)
            {
                Debug.Log("itemList is null-----");
                return;
            }
            for (int i = 0; i < itemList.Length; i++)
            {
                itemList[i].PlayJumpAndWave();
            }
        }


    }
}