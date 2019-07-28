using UnityEngine;
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
    
    void Awake()
    {
        instance = this;
        PersonDataPath  = Application.persistentDataPath + "/persons/";
    }

    public int GetPersonsNum()
    {
        Debug.Log("GetAllPersons============"+PersonDataPath);
        int num = 0;
        DirectoryInfo info = new DirectoryInfo(PersonDataPath);
        if (info.Exists)
        {
            FileInfo[] files = info.GetFiles("*", SearchOption.AllDirectories);
            num = files.Length;
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                Debug.Log("Name:" + files[i].Name);
            }
        }
        Debug.Log("num:" + num);
        return num;
    }

    public List<string> GetPersonsList()
    {
        Debug.Log("GetPersonsList");
        DirectoryInfo info = new DirectoryInfo(PersonDataPath);
        List<string> pathList = new List<string>();
        if (info.Exists)
        {
            FileInfo[] files = info.GetFiles("*", SearchOption.AllDirectories);
            FileCompare fc = new FileCompare();
            //按创建时间排序
            Array.Sort(files, fc);
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                Debug.Log("Name:" + files[i].Name);
                pathList.Add(files[i].Name);
            }
        }
        return pathList;
    }

    //序列化
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

    //反序列化
    public PartDataWhole DeserializePerson(string fileName)
    {
        Debug.Log("DeserializePerson------");
        IFormatter formatter = new BinaryFormatter();
        string path = PersonDataPath + fileName;
        if (!File.Exists(path))
        {
            return null;
        }
        Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        PartDataWhole whole = (PartDataWhole)formatter.Deserialize(stream);
        //GameManager.instance.homeSelectIndex = whole.ModelIndex;
        stream.Close();
        return whole;
    }

    //删除文件
    public bool DeletePerson(string fileName)
    {
        bool isDelete = false;
        string path = PersonDataPath + fileName;
        if (File.Exists(path))
        {
            File.Delete(path);
            isDelete = true;
        }
        return isDelete;
    }


}
