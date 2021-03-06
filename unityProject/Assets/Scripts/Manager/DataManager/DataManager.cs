﻿using System;
using System.Collections.Generic;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;

namespace DataMgr
{
    public class DataManager : SingletonMono<DataManager>
    {
        string personFilePath = "";

        private GameObject curPerson;

        void Awake()
        {
            instance = this;
        }
   
        public PartDataWhole TransformToPartsList(JoinType joinType,Transform trans, int selctIndex, byte[] pixels, byte[] drawPixel, byte[] drawTexture)
        {
            List<PartData> parts = new List<PartData>();
            ResDragItem []transList = trans.GetComponentsInChildren<ResDragItem>();
            for (int i = 0; i < transList.Length; i++)
            {
                Transform img = transList[i].transform;
                if (img.GetComponent<Image>().sprite==null)
                {
                    continue;
                }
                PartType type = transList[i].partType;
                byte[] b = img.GetComponent<Image>().sprite.texture.EncodeToPNG();
                float[] pos = { img.localPosition.x, img.localPosition.y, img.localPosition.z };
                float[] scale = { img.localScale.x, img.localScale.y, img.localScale.z };
                PartData p = new PartData(type, b, pos, scale);
                parts.Add(p);
            }
            PartDataWhole partDataWhole = new PartDataWhole(joinType, selctIndex, pixels, drawPixel, parts, drawTexture);
            GameManager.instance.SetCurPartDataWhole(partDataWhole);

            //序列化
            PersonManager.instance.SerializePerson(partDataWhole);
            return partDataWhole;
        }

        /// <summary>
        /// 异步加载一个人物
        /// </summary>
        /// <returns>The person object.</returns>
        /// <param name="part">Part.</param>
        public void GetPersonObjAsync(List<PartData> part,Action<GameObject> cb = null)
        {
            GameObject person = new GameObject("person");
            for (int i = 0; i < part.Count; i++)
            {
                PartType partType = part[i].PType;
                if (partType == PartType.Pixels || partType == PartType.drawPixels)
                {
                    continue;
                }
                Vector3 pos = new Vector3(part[i].Pos[0], part[i].Pos[1], part[i].Pos[2]);
                Vector3 scale = new Vector3(part[i].Scale[0], part[i].Scale[1], part[i].Scale[2]);

                string path = "Prefabs/display|display_item_" + partType.ToString().ToLower();

                if (i == part.Count - 1)
                {
                    //最后一个部位加载完,父节点要修改的！！！异步这块现在还没修改
                    GetOnePartAsync(path, person, pos, scale, part[i], (tmpPerson)=> {
                        Transform partParent = tmpPerson.transform;
                        for (int j = 0; j < tmpPerson.transform.childCount; j++)
                        {
                            Transform t = tmpPerson.transform.GetChild(j);
                            PartType type = t.GetComponent<DisplayPartItem>().partType;
                            if (type == PartType.Body)
                            {
                                partParent = t.Find("img_item").transform;
                            }
                            else if (type == PartType.LeftEye || type == PartType.RightEye || type == PartType.Mouth || type == PartType.Hat || type == PartType.Hair || type == PartType.HeadWear)
                            {
                                t.SetParent(partParent);
                                j--;
                            }
                        }
                        curPerson = tmpPerson;
                        GetListDiaplayItem(tmpPerson.transform);
                        if (cb!=null)
                        {
                            cb(tmpPerson);
                        }
                    });
                }
                else
                {
                    GetOnePartAsync(path, person, pos, scale, part[i], null);
                }
            }
        }

        /// <summary>
        /// 异步加载一个部位
        /// </summary>
        /// <param name="path"></param>
        /// <param name="person"></param>
        /// <param name="pos"></param>
        /// <param name="scale"></param>
        /// <param name="part"></param>
        /// <param name="cb"></param>
        private void GetOnePartAsync(string path,GameObject person,Vector3 pos,Vector3 scale,PartData part,Action<GameObject> cb = null)
        {
            PartType partType = part.PType;
            UIHelper.instance.LoadPrefabAsync(path, person.transform, pos, scale, false, null, (obj) => {
                obj.transform.SetParent(person.transform);
                RawImage img = obj.transform.Find("img_item").GetComponent<RawImage>();
                Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                t.filterMode = FilterMode.Point;
                t.LoadImage(part.ImgBytes);
                t.Apply(false);
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
                    cb(person);
                }
            });
        }

        /// <summary>
        /// 同步获取一个人物
        /// </summary>
        /// <returns>The person object.</returns>
        /// <param name="part">Part.</param>
        public GameObject GetPersonObj(PartDataWhole whole)
        {
            List<PartData> part = whole.PartDataList;
            GameObject person = new GameObject("person");
            Transform transBody = person.transform;
            Transform parentBody = null;
            GameObject parentObj = null;
            GameObject bodyRectTemp = null;
            if (whole.JoinType == JoinType.Animal)
            {
                string bodypath = "Prefabs/display|display_item_animalbody";
                parentObj = UIHelper.instance.LoadPrefab(bodypath, person.transform, Vector3.zero, Vector3.one);
                parentBody = parentObj.transform.Find("img_item").transform;
                DisplayPartItem item = parentObj.gameObject.AddComponent<DisplayPartItem>();
                item.partType = PartType.AnimalBody;
            }
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
                Debug.Log(partType + "   " + pos);
                string path = "Prefabs/display|display_item_" + partType.ToString().ToLower(); 
                if (partType==PartType.LeftEye||partType==PartType.RightEye||partType==PartType.Mouth)
                {
                    if (whole.JoinType==JoinType.Animal)
                    {
                        obj = UIHelper.instance.LoadPrefab(path, transBody, pos, scale);
                    }
                    else
                    {
                        obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                        obj.transform.SetParent(transBody);
                    }
                }
                else if (partType==PartType.Head||partType==PartType.TrueBody)
                {
                    obj = UIHelper.instance.LoadPrefab(path, parentBody, pos, scale);
                    if (bodyRectTemp==null)
                    {
                        bodyRectTemp = obj;
                    }
                }
                else
                {
                    obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                    obj.transform.SetParent(transBody);
                }
                //给后面的节点指定父节点
                if (partType == PartType.Head || partType == PartType.Body)
                {
                    transBody = obj.transform.Find("img_item").transform;
                }
               
                //使用RawImage
                RawImage img = obj.transform.Find("img_item").GetComponent<RawImage>();
                Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                t.filterMode = FilterMode.Point;
                t.LoadImage(part[i].ImgBytes);
                t.Apply(false);
                img.texture = t;
                img.SetNativeSize();
                //调整父节点的大小
                float w = img.GetComponent<RectTransform>().sizeDelta.x;
                float h = img.GetComponent<RectTransform>().sizeDelta.y;
                obj.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);

                DisplayPartItem item = obj.AddComponent<DisplayPartItem>();
                item.partType = part[i].PType;
                item.Init();
            }
            if (whole.JoinType==JoinType.Animal&&parentObj!=null)
            {
                parentObj.transform.SetAsLastSibling();
                float offsetHeight = bodyRectTemp.transform.localPosition.y;
                parentBody.GetComponent<RectTransform>().sizeDelta = new Vector2(bodyRectTemp.GetComponent<RectTransform>().sizeDelta.x, bodyRectTemp.GetComponent<RectTransform>().sizeDelta.y - offsetHeight);//bodyRectTemp.GetComponent<RectTransform>().sizeDelta;
                parentObj.GetComponent<RectTransform>().sizeDelta = new Vector2(bodyRectTemp.GetComponent<RectTransform>().sizeDelta.x, bodyRectTemp.GetComponent<RectTransform>().sizeDelta.y - offsetHeight);
                parentBody.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
                parentBody.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
                parentBody.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0);
            }
            curPerson = person;
            GetListDiaplayItem(person.transform);
            return person;
        }

        /// <summary>
        /// 同步获取一个人物并计算出最低点
        /// </summary>
        /// <returns>The person object.</returns>
        /// <param name="part">Part.</param>
        public GameObject GetPersonObjWithFlag(PartDataWhole whole,out float minPosY)
        {
            float minY = float.MaxValue;
            List<PartData> part = whole.PartDataList;
            GameObject person = new GameObject("person");
            Transform transBody = person.transform;
            Transform parentBody = null;
            GameObject parentObj = null;
            GameObject bodyRectTemp = null;
            if (whole.JoinType == JoinType.Animal)
            {
                string bodypath = "Prefabs/display|display_item_animalbody";
                parentObj = UIHelper.instance.LoadPrefab(bodypath, person.transform, Vector3.zero, Vector3.one);
                parentBody = parentObj.transform.Find("img_item").transform;
                DisplayPartItem item = parentObj.gameObject.AddComponent<DisplayPartItem>();
                item.partType = PartType.AnimalBody;
            }
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
                Debug.Log(partType + "   " + pos);
                string path = "Prefabs/display|display_item_" + partType.ToString().ToLower();
                if (partType == PartType.LeftEye || partType == PartType.RightEye || partType == PartType.Mouth)
                {
                    if (whole.JoinType == JoinType.Animal)
                    {
                        obj = UIHelper.instance.LoadPrefab(path, transBody, pos, scale);
                    }
                    else
                    {
                        obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                        obj.transform.SetParent(transBody);
                    }
                }
                else if (partType == PartType.Head || partType == PartType.TrueBody)
                {
                    obj = UIHelper.instance.LoadPrefab(path, parentBody, pos, scale);
                    if (bodyRectTemp == null)
                    {
                        bodyRectTemp = obj;
                    }
                }
                else
                {
                    obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                    obj.transform.SetParent(transBody);
                }
                //给后面的节点指定父节点
                if (partType == PartType.Head || partType == PartType.Body)
                {
                    transBody = obj.transform.Find("img_item").transform;
                }

                //使用RawImage
                RawImage img = obj.transform.Find("img_item").GetComponent<RawImage>();
                Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                t.filterMode = FilterMode.Point;
                t.LoadImage(part[i].ImgBytes);
                t.Apply(false);
                img.texture = t;
                img.SetNativeSize();
                //调整父节点的大小
                float w = img.GetComponent<RectTransform>().sizeDelta.x;
                float h = img.GetComponent<RectTransform>().sizeDelta.y;
                obj.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);

                DisplayPartItem item = obj.AddComponent<DisplayPartItem>();
                item.partType = part[i].PType;
                item.Init();

                //最低点计算
                float bottom = obj.GetComponent<RectTransform>().anchoredPosition.y - h / 2;

                if (partType == PartType.Body)
                {
                    float j = Utils.GetPicHeightRate(t);
                    bottom = h / 2 - h * (1 - j);
                }
                if (minY > bottom)
                {
                    minY = bottom;
                }
            }
            if (whole.JoinType == JoinType.Animal && parentObj != null)
            {
                float offsetHeight = bodyRectTemp.transform.localPosition.y;
                parentObj.transform.SetAsLastSibling();
                parentBody.GetComponent<RectTransform>().sizeDelta = new Vector2(bodyRectTemp.GetComponent<RectTransform>().sizeDelta.x, bodyRectTemp.GetComponent<RectTransform>().sizeDelta.y - offsetHeight);//bodyRectTemp.GetComponent<RectTransform>().sizeDelta;
                parentObj.GetComponent<RectTransform>().sizeDelta = new Vector2(bodyRectTemp.GetComponent<RectTransform>().sizeDelta.x, bodyRectTemp.GetComponent<RectTransform>().sizeDelta.y - offsetHeight);
                parentBody.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
                parentBody.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
                parentBody.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0);
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
            if (itemList == null)
            {
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
                return;
            }
            for (int i = 0; i < itemList.Length; i++)
            {
                itemList[i].PlayJumpAndWave();
            }
        }


    }
}