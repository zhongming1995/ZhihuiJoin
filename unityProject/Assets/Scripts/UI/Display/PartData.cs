using System;

public enum TemplateResType {
    Body = 0,//字母
    Eye = 1,
    Mouth = 2,
    Hair = 3,
    Hat = 4,
    HeadWear = 5,
    Hand = 6,
    Leg = 7,
    Head = 8,
    TrueBody = 9,//真实身体
}

public enum PartType
{
    Pixels = -2,
    drawPixels = -1,
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
    RightLeg = 10,
    Head = 11,
    TrueBody = 12,
}

[Serializable]
public class PartData
{
    public PartType PType { get; set; }

    public byte[] ImgBytes { get; set; }

    public float[] Pos { get; set; }

    public float[] Scale { get; set; }

    public PartData(PartType _type, byte[] _imgBytes, float[] _pos, float[] _scale)
    {
        PType = _type;
        ImgBytes = _imgBytes;
        Pos = _pos;
        Scale = _scale;
    }

}

