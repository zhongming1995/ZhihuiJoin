using UnityEngine;
using System.Collections.Generic;
using ResMgr;

public static class CSVUtil
{
    ///行分割符
    public static string[] SYMBOL_LINE = new string[] { "\r\n" };

    /// <summary>
    /// 素材表
    /// </summary>
    /// <returns>The list from path.</returns>
    /// <param name="csvPath">Csv path.</param>
    public static List<string> GetListFromPath(string csvPath)
    {
        string content = ResManager.instance.LoadText(csvPath).text;
        Debug.Log("content:" + content);
        string[] lineArray = content.Split(SYMBOL_LINE, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lineArray.Length; i++)
        {
            //Debug.Log("line:"+lineArray[i]);
        }
        List<string> arrayToList = new List<string>(lineArray);
        return arrayToList;
    }

    /// <summary>
    /// 素材限制表
    /// </summary>
    /// <returns>The list from restrict.</returns>
    /// <param name="csvPath">Csv path.</param>
    public static string[][] GetListFromRestrict(string csvPath)
    {
        string content = ResManager.instance.LoadText(csvPath).text;
        string[] lineArray = content.Split(SYMBOL_LINE, System.StringSplitOptions.RemoveEmptyEntries);
        string[][] Array = new string[lineArray.Length][];
        for (int i = 0; i < lineArray.Length; i++)
        {
            Array[i] = lineArray[i].Split(',');
        }
        for (int i = 0; i < Array.Length; i++)
        {
            for (int j = 0; j < Array[i].Length; j++)
            {
                Debug.Log(Array[i][j]);
            }
        }
        return Array;
    }
}