using System;
using System.Collections.Generic;

[Serializable]
public class PartDataWhole
{
    private int modelIndex;
    private byte[] pixels;
    private byte[] drawPixels;
    private byte[] drawTexture;
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

    public byte[] DrawTexture
    {
        get
        {
            return drawTexture;
        }
        set
        {
            drawTexture = value;
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



    public PartDataWhole(int _index,byte[] _pixels,byte[] _drawPixels,List<PartData> _list,byte[] _drawTexture)
    {
        this.modelIndex = _index;
        this.pixels = _pixels;
        this.drawPixels = _drawPixels;
        this.partDataList = _list;
        this.drawTexture = _drawTexture;
    }
}