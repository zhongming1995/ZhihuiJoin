using System;
using System.Collections.Generic;

[Serializable]
public class PartDataWhole
{
    private int modelIndex;
    private byte[] pixels;
    private byte[] drawPixels;
    public List<PartData> partDataList = new List<PartData>();

    public int ModelIndex
    {
        get
        {
            return modelIndex;
        }
        set
        {
            modelIndex = value;
        }
    }

    public byte[] Pixels
    {
        get
        {
            return pixels;
        }
        set
        {
            pixels = value;
        }
    }

    public byte[] DrawPixels
    {
        get
        {
            return drawPixels;
        }
        set
        {
            drawPixels = value;
        }
    }

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

    public PartDataWhole(int _index,byte[] _pixels,byte[] _drawPixels,List<PartData> _list)
    {
        this.modelIndex = _index;
        this.pixels = _pixels;
        this.drawPixels = _drawPixels;
        this.partDataList = _list;
    }
}