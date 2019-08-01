using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// 文件比较类
/// </summary>
public class FileCompare : IComparer
{
    public int Compare(object x, object y)
    {
        FileInfo fi1 = x as FileInfo;
        FileInfo fi2 = y as FileInfo;
        return -fi1.CreationTime.CompareTo(fi2.CreationTime);//文件或目录的创建日期
    }
}