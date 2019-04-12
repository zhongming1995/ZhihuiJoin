using System;

    //public enum PartType {
    //    Body = 0,
    //    Eye = 1,
    //    Mouth = 2,
    //    Hair = 3,
    //    Hat = 4,
    //    HeadWear = 5,
    //    Hand = 6,
    //    Leg = 7
    //}

    public enum PartType
    {
        Body = 0,
        LeftEye = 1,
        RightEye = 2,
        Mouth = 3,
        Hair = 4,
        Hat = 5,
        HeadWear = 6,
        LeftHand = 7,
        RightHand = 8,
        LeftLeg = 9,
        RightLeg = 10
    }

[Serializable]
public class PartData
{
    private PartType type;//部位类型
    private byte[] imgBytes;//图片转byte数组
    private float[] pos;//在画布上的局部坐标
    private float[] scale;//缩放

    public PartType Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    public byte[] ImgBytes
    {
        get
        {
            return imgBytes;
        }
        set
        {
            imgBytes = value;
        }
    }

    public float[] Pos
    {
        get
        {
            return pos;
        }
        set
        {
            pos = value;
        }
    }

    public float[] Scale
    {
        get
        {
            return scale;
        }
        set
        {
            scale = value;
        }
    }

    public PartData(PartType _type, byte[] _imgBytes, float[] _pos, float[] _scale)
    {
        this.type = _type;
        this.imgBytes = _imgBytes;
        this.pos = _pos;
        this.scale = _scale;
    }

}

