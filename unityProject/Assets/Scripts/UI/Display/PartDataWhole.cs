using System;
using System.Collections.Generic;
using GameMgr;

[Serializable]
public class PartDataWhole
{
    public List<PartData> partDataList = new List<PartData>();

    public JoinType JoinType { get; set; }

    public int ModelIndex { get; set; }

    public byte[] Pixels { get; set; }

    public byte[] DrawPixels { get; set; }

    public byte[] DrawTexture { get; set; }

    public List<PartData> PartDataList
    {
        get
        {
            return partDataList;
        }
        set
        {
            partDataList = value;
        }
    }



    public PartDataWhole(JoinType _joinType,int _index,byte[] _pixels,byte[] _drawPixels,List<PartData> _list,byte[] _drawTexture)
    {
        this.JoinType = _joinType;
        this.ModelIndex = _index;
        this.Pixels = _pixels;
        this.DrawPixels = _drawPixels;
        this.partDataList = _list;
        this.DrawTexture = _drawTexture;
    }
}