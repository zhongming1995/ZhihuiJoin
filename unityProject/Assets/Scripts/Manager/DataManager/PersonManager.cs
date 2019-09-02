﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GameMgr;
using System.Collections.Generic;
using System;

public class PersonManager : SingletonMono<PersonManager>
{
    //存储人物数据的本地路径
    [HideInInspector]
    public string PersonDataPath;
    [HideInInspector]
    public string PersonImgPath;

    //人物文件名称
    private string personFileName;
    public string PersonFileName
    {
        get
        {
            return PersonFileName;
        }
        set
        {
            personFileName = value;
        }
    }

    public string SavePath
    {
        get
        {
            return PersonDataPath + personFileName;
        }
    }

    public string SaveImgPath
    {
        get
        {
            return PersonImgPath + personFileName;
        }
    }

    private int personCount;
    public int PersonCount
    {
        get
        {
            return personCount;
        }
    }

    public int CurPersonIndex { get; set; }

    public List<string> pathList = new List<string>();
    public List<string> imagePathList = new List<string>();

    void Awake()
    {
        instance = this;
        PersonDataPath = Application.persistentDataPath + "/persons_1.1.1/";
        PersonImgPath = Application.persistentDataPath + "/person_images_1.1.1/";
    }

    private void Start()
    {
        //移除旧文件
        RemoveOldFile();
    }

    void RemoveOldFile()
    {
        string oldPersonPath = Application.persistentDataPath + "/persons/";
        string oldImagePath = Application.persistentDataPath + "/person_images/";
        string oldImageCutPath = Application.persistentDataPath + "/image_shot/";

        FileHelper.DeleteAllFiles(oldPersonPath);
        FileHelper.DeleteAllFiles(oldImagePath);
        FileHelper.DeleteAllFiles(oldImageCutPath);
    }

    public int GetPersonsNum()
    {
        personCount = GetPersonsList().Count;
        return personCount;
    }

    public List<string> GetPersonsList()
    {
        pathList.Clear();
        FileInfo[] infos = FileHelper.GetFileList(PersonDataPath, "*.bin");
        FileCompare fileCompare = new FileCompare();
        Array.Sort(infos, fileCompare);
        for (int i = 0; i < infos.Length; i++)
        {
            string[] lst = infos[i].Name.Split('.');
            pathList.Add(lst[0]);
        }
        return pathList;
    }

    //序列化
    public void SerializePerson(PartDataWhole whole)
    {
        IFormatter formatter = new BinaryFormatter();
        //string folderPath = Application.persistentDataPath + "/join_person";
        DirectoryInfo info = new DirectoryInfo(PersonDataPath);
        if (!info.Exists)
        {
            Debug.Log("文件夹不存在:" + PersonDataPath);
            Directory.CreateDirectory(PersonDataPath);
        }
        string savePath = SavePath + ".bin";
        Stream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, whole);
        stream.Flush();
        stream.Close();
    }

    //反序列化
    public PartDataWhole DeserializePerson(string fileName)
    {
        IFormatter formatter = new BinaryFormatter();
        string path = PersonDataPath + fileName +".bin";
        if (!File.Exists(path))
        {
            return null;
        }
        Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        PartDataWhole whole = (PartDataWhole)formatter.Deserialize(stream);
        //GameManager.instance.homeSelectIndex = whole.ModelIndex;
        stream.Flush();
        stream.Close();
        return whole;
    }
 

    //删除文件
    public void DeletePerson(string fileName)
    {
        string personPath = PersonDataPath + fileName + ".bin";
        string imagePath = PersonImgPath + fileName + ".png";
        FileHelper.DeleteFileByName(personPath);
        FileHelper.DeleteFileByName(imagePath);      
    }


}
