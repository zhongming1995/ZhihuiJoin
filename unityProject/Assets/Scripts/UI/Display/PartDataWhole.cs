using System;
using System.Collections.Generic;
using GameMgr;

[Serializable]
public class PartDataWhole
{
    public JoinType JoinType { get; set; }

    public int ModelIndex { get; set; }

    public byte[] Pixels { get; set; }

    public byte[] DrawPixels { get; set; }

    public byte[] DrawTexture { get; set; }

    public List<PartData> PartDataList { get; set; } = new List<PartData>();

    public PartDataWhole(JoinType _joinType,int _index,byte[] _pixels,byte[] _drawPixels,List<PartData> _list,byte[] _drawTexture)
    {
        JoinType = _joinType;
        ModelIndex = _index;
        Pixels = _pixels;
        DrawPixels = _drawPixels;
        PartDataList = _list;
        DrawTexture = _drawTexture;
    }
}