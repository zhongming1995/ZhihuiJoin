using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinPlus : MonoBehaviour
{
    private Transform HandLegGroup;
    private Transform EyeMouthHairGroup;
    private Transform HatHeadwearGroup;
    private JoinMainView joinMainView;

    // Start is called before the first frame update
    void Awake()
    {
        HandLegGroup = GameObject.Find("img_draw_bg/draw_panel/group_handleg").transform;
        EyeMouthHairGroup = GameObject.Find("img_draw_bg/draw_panel/group_eyemouthhair").transform;
        HatHeadwearGroup = GameObject.Find("img_draw_bg/draw_panel/group_hatheadwear").transform;
        joinMainView = GetComponent<JoinMainView>();
    }

    public void LoadFile(PartDataWhole whole)
    {
        Texture2D drawTexture = null;
        List<PartData> part = whole.partDataList;
        for (int i = 0; i < part.Count; i++)
        {
            PartType partType = part[i].PType;
            if (partType != PartType.Body && partType != PartType.Pixels && partType!=PartType.drawPixels)
            {
                Vector3 pos = new Vector3(part[i].Pos[0], part[i].Pos[1], part[i].Pos[2]);
                Vector3 scale = new Vector3(part[i].Scale[0], part[i].Scale[1], part[i].Scale[2]);
                GameObject obj = null;
                string path = "Prefabs/join|gen_res";
                //obj = UIHelper.instance.LoadPrefab(path, person.transform, pos, scale);
                if (partType == PartType.LeftHand || partType == PartType.RightHand || partType == PartType.LeftLeg || partType == PartType.RightLeg)//手脚
                {
                    obj = UIHelper.instance.LoadPrefab(path, HandLegGroup, pos, scale);
                }
                else if (partType == PartType.LeftEye || partType == PartType.RightEye || partType == PartType.Mouth || partType == PartType.Hair)
                {
                    obj = UIHelper.instance.LoadPrefab(path, EyeMouthHairGroup, pos, scale);
                }
                else if (partType == PartType.Hat || partType == PartType.HeadWear)
                {
                    obj = UIHelper.instance.LoadPrefab(path, HatHeadwearGroup, pos, scale);
                }

                Image img = obj.transform.GetComponent<Image>();
                if (img == null)
                {
                    Debug.Log("img is null");
                }
                Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                t.filterMode = FilterMode.Point;
                t.LoadImage(part[i].ImgBytes);
                t.Apply(false);
                Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
                img.sprite = s;
                img.SetNativeSize();
                obj.transform.localScale = scale;
                
                ResDragItem item = obj.GetComponent<ResDragItem>();
                if (item==null)
                {
                    item = obj.AddComponent<ResDragItem>();
                }
                item.partType = partType;
                item.LoadInitItem(partType, s);
            }
            else
            {
                //不管
                if (partType == PartType.Body)
                {
                    Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
                    t.filterMode = FilterMode.Point;
                    t.LoadImage(part[i].ImgBytes);
                    t.Apply(false);
                    drawTexture = t;
                }
            }
        }
        if (joinMainView.mobilePaint!=null)
        {
            //joinMainView.mobilePaint.SetPixels(whole.Pixels);
            //joinMainView.mobilePaint.SetDrawPixels(whole.DrawPixels);

            Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
            t.filterMode = FilterMode.Point;
            t.LoadImage(whole.DrawTexture);
            t.Apply(false);
            joinMainView.mobilePaint.SetPixelsTest(t,drawTexture);//zong
            //joinMainView.mobilePaint.SetDrawPixelsTest(drawTexture);//draw
        }
    }
}
