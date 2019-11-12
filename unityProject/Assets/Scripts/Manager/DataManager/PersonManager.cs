using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System;

public class PersonManager : SingletonMono<PersonManager>
{
    //存储人物数据的本地路径
    [HideInInspector]
    public string PersonDataPath;
    [HideInInspector]
    public string PersonImgPath;
    [HideInInspector]
    public string PicPrefix = ".jpg";
    //人物文件名称
    public string PersonFileName { get; set; }

    public string SavePath
    {
        get
        {
            return PersonDataPath + PersonFileName;
        }
    }

    public string SaveImgPath
    {
        get
        {
            return PersonImgPath + PersonFileName;
        }
    }
    public int PersonCount { get; set; }
    public int CurPersonIndex { get; set; }
    public int PageCount { get; set; }
    public int CurPersonPageIndex { get; set; }

    public List<string> PersonPathList = new List<string>();

    void Awake()
    {
        Debug.Log("PersonManager Awake" + Time.realtimeSinceStartup);
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

    public int OnlyGetPersonNum()
    {
        FileInfo[] infos = FileHelper.GetFileList(PersonDataPath, "*.bin");
        if (infos==null)
        {
            return 0;
        }
        return infos.Length;
    }

    public int OnlyGetPageNum(int personCount)
    {
        int lastNumber = personCount % 6;
        if (lastNumber == 0)
        {
            PageCount = personCount / 6;
        }
        else
        {
            PageCount = personCount / 6 + 1;
        }
        return PageCount;
    }

    public List<string> GetPersonsList()
    {
        PersonPathList.Clear();
        FileInfo[] infos = FileHelper.GetFileList(PersonDataPath, "*.bin");
        FileCompare fileCompare = new FileCompare();
        if (infos!=null)
        {
            Array.Sort(infos, fileCompare);
            for (int i = 0; i < infos.Length; i++)
            {
                string[] lst = infos[i].Name.Split('.');
                if (lst[0]==string.Empty)
                {
                    continue;
                }
                PersonPathList.Add(lst[0]);
            }
        }
        //给PersonCount和PageCount赋值
        PersonCount = PersonPathList.Count;
        PageCount = OnlyGetPageNum(PersonCount);
        return PersonPathList;
    }

    //序列化
    public void SerializePerson(PartDataWhole whole)
    {
        IFormatter formatter = new BinaryFormatter();
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
        Debug.Log("des:"+path);
        if (!File.Exists(path))
        {
            return null;
        }
        Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        PartDataWhole whole = (PartDataWhole)formatter.Deserialize(stream);
        stream.Flush();
        stream.Close();
        return whole;
    }

    //删除文件
    public void DeletePerson(string fileName)
    {
        string personPath = PersonDataPath + fileName + ".bin";
        string imagePath = PersonImgPath + fileName + PicPrefix;//".png";
        FileHelper.DeleteFileByName(personPath);
        FileHelper.DeleteFileByName(imagePath);      
    }
}
