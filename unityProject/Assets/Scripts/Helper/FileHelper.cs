using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 文件比较
/// </summary>
public class FileCompare : IComparer
{
    public int Compare(object x, object y)
    {
        FileInfo fi1 = x as FileInfo;
        FileInfo fi2 = y as FileInfo;
        return -fi1.LastWriteTime.CompareTo(fi2.LastWriteTime);//文件或目录的创建日期
    }
}

/// <summary>
/// 文件公共处理类
/// </summary>
public static class FileHelper
{

    /// <summary>
    /// 将文件转换成byte[]数组
    /// </summary>
    /// <param name="fileUrl">文件路径文件名称</param>
    /// <returns>byte[]数组</returns>
    public static byte[] FileToByte(string fileUrl)
    {
        try
        {
            using (FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read))
            {
                byte[] byteArray = new byte[fs.Length];
                fs.Read(byteArray, 0, byteArray.Length);
                fs.Flush();
                fs.Close();
                fs.Dispose();
                return byteArray;
            }
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// 将byte[]数组保存成文件
    /// </summary>
    /// <param name="byteArray">byte[]数组</param>
    /// <param name="fileName">保存至硬盘的文件路径</param>
    /// <returns></returns>
    public static bool ByteToFile(byte[] byteArray, string fileName)
    {
        bool result = false;
        try
        {
            int index = fileName.LastIndexOf('/');
            int total = fileName.Length;
            string folder = fileName.Substring(0, index+1);
            DirectoryInfo info = new DirectoryInfo(folder);
            if (!info.Exists)
            {
                Directory.CreateDirectory(folder);
            }

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(byteArray, 0, byteArray.Length);
                fs.Flush();
                fs.Close();
                result = true;
            }
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public static FileInfo[] GetFileList(string path,string serachChar)
    {
        Debug.Log(path);
        DirectoryInfo info = new DirectoryInfo(path);
        if (info.Exists)
        {
            FileInfo[] files = info.GetFiles(serachChar, SearchOption.AllDirectories);
            return files;
        }
        return null;
    }

    public static bool DeleteAllFiles(string path)
    {
        DirectoryInfo directory = new DirectoryInfo(path);
        if (directory.Exists)
        {
            FileInfo[] infos = directory.GetFiles();
            for (int i = 0; i < infos.Length; i++)
            {
                infos[i].Delete();
            }
            directory.Delete();
            return true;
        }
        return false;
    }

    public static bool DeleteFileByName(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        return false;
    }
}
