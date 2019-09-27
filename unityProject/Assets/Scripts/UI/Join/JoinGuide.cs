using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using GameMgr;
using UnityEngine;
using DG.Tweening;

public class JoinGuide : MonoBehaviour
{
    public Transform DrawReminder;
    public Transform DragReminder;
    private JoinMainView joinMainView;
    private Coroutine cor_Reminder;
    //操作定义：上一步/下一步/主页按钮/蜡笔/橡皮/颜色/素材分类按钮/大小调节按钮/拖动素材（耗时）/涂色（耗时）/橡皮擦除（耗时）
    private int noOperatipnTimeLimit = 5;
    public bool isOperating;//是否正在操作；
    private float operationStartTime;//用于判断无操作的时间
    //private Coroutine cor_Reminder;
    private int reminderCount;//有多少个无操作的时间段
    private AniEvent drawAniEvent;
    private AniEvent dragAniEvent;

    private Transform curAniTrans;
    private Sequence sequence;

    void Start()
    {
        joinMainView = GetComponent<JoinMainView>();
        cor_Reminder = StartCoroutine("CorReminder");
        DragReminder.gameObject.SetActive(false);
        DrawReminder.gameObject.SetActive(false);
        drawAniEvent = DrawReminder.GetComponent<AniEvent>();
        drawAniEvent.animationEndDelegate += OperationEnd;
        dragAniEvent = DragReminder.GetComponent<AniEvent>();
        dragAniEvent.animationEndDelegate += OperationEnd;
    }

    //外部调用的JoinMainView
    public void AddMobileDrawDelagate()
    {
        if (joinMainView==null)
        {
            joinMainView = GetComponent<JoinMainView>();
        }
        joinMainView.mobilePaint.drawStart += OperationStart;
        joinMainView.mobilePaint.drawEnd += OperationEnd;
    }

    IEnumerator CorReminder()
    {
        operationStartTime = 0;
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            if (AudioManager.instance.effectAudioSource.isPlaying == false && isOperating == false)
            {
                operationStartTime += 0.1f;
                if (operationStartTime > noOperatipnTimeLimit)
                {
                    reminderCount++;
                    //Debug.Log("做一次提示11111-----------"+ reminderCount);
                    DoReminder(reminderCount);
                    operationStartTime = 0;
                }
            }
            yield return delay;
        }
    }

    public void DoOperation()
    {
        if (cor_Reminder != null)
        {
            StopCoroutine("CorReminder");
            cor_Reminder = StartCoroutine("CorReminder");
        }
        reminderCount = 0;
        isOperating = false;
        BreakReminder();
    }

    public void OperationStart()
    {
        isOperating = true;
        if (cor_Reminder != null)
        {
            StopCoroutine("CorReminder");
        }
        BreakReminder();
    }

    public void OperationEnd()
    {
        DoOperation();
    }

    private void DoReminder(int rCount)
    {
        if (GameManager.instance.curSelectResType==TemplateResType.Body)//第一步
        {
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                DoDrawNextStepReminder();
            }
            else
            {
                //是否画过一笔
                if (joinMainView.hasPainted)
                {
                    DoDrawNextStepReminder();
                }
                else
                {
                    OperationStart();
                    DrawReminder.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            //是否拖拽过物体
            if (joinMainView.hasDraged==false)
            {
                //Debug.Log("提示动画：拖动");
                OperationStart();
                DragReminder.gameObject.SetActive(true);
            }
            else
            {
                DoCircleReminder(rCount);
            }
        }
    }

    private void DoCircleReminder(int rCount)
    {
        if (GameManager.instance.curSelectResType==TemplateResType.Head)
        {
            DoNextStepReminder();
        }
        if (GameManager.instance.curSelectResType == TemplateResType.Eye)
        {
            if (rCount % 2 == 1)
            {
                DoMouthReminder();
            }
            else if (rCount % 2 == 0)
            {
                DoNextStepReminder();
            }
        }
        else if (GameManager.instance.curSelectResType == TemplateResType.Mouth)
        {
            if (rCount % 2 == 1)
            {
                DoEyeReminder();
            }
            else if (rCount % 2 == 0)
            {
                DoNextStepReminder();
            }
        }
        else if (GameManager.instance.curSelectResType == TemplateResType.Hair)
        {
            //没有头发了现在
        }
        else if (GameManager.instance.curSelectResType == TemplateResType.Hat)
        {
            if (rCount % 2 == 1)
            {
                DoHeadWearReminder();
            }
            else if (rCount % 2 == 0)
            {
                DoCompleteReminder();
            }
        }
        else if (GameManager.instance.curSelectResType == TemplateResType.HeadWear)
        {

            if (rCount % 2 == 1)
            {
                DoHatReminder();
            }
            else if (rCount % 2 == 0)
            {
                DoCompleteReminder();
            }
        }
        else if (GameManager.instance.curSelectResType == TemplateResType.Hand)
        {
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                if (rCount % 4 == 1)
                {
                    DoLegReminder();
                }
                else if (rCount % 4 == 2)
                {
                    DoNextStepReminder();
                }
                else if (rCount % 4 == 3)
                {
                    DoTrueBodyReminder();
                }
                else if (rCount % 4 == 0)
                {
                    DoNextStepReminder();
                }
            }
            else
            {
                if (rCount % 2 == 1)
                {
                    DoLegReminder();
                }
                else if (rCount % 2 == 0)
                {
                    DoNextStepReminder();
                }
            }
        }
        else if (GameManager.instance.curSelectResType == TemplateResType.Leg)
        {
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                if (rCount % 4 == 1)
                {
                    DoTrueBodyReminder();
                }
                else if (rCount % 4 == 2)
                {
                    DoNextStepReminder();
                }
                else if (rCount % 4 == 3)
                {
                    DoHandReminder();
                }
                else if (rCount % 4 == 0)
                {
                    DoNextStepReminder();
                }
            }
            else
            {
                if (rCount % 2 == 1)
                {
                    DoHandReminder();
                }
                else if (rCount % 2 == 0)
                {
                    DoNextStepReminder();
                }
            }
        }
        else if (GameManager.instance.curSelectResType == TemplateResType.TrueBody)
        {
            if (rCount % 4 == 1)
            {
                DoHandReminder();
            }
            else if (rCount % 4 == 2)
            {
                DoNextStepReminder();
            }
            else if (rCount % 4 == 3)
            {
                DoLegReminder();
            }
            else if (rCount % 4 == 0)
            {
                DoNextStepReminder();
            }
        }
    }

    private void DoEyeReminder()
    {
        string path = string.Empty;
        if (GameManager.instance.curJoinType == JoinType.Letter)
        {
            path = "Audio/reminder/letter|guide_letter_01";
        }
        else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            path = "Audio/reminder/num|guide_num_01";
        }
        else
        {
            int offsetIndex = GameManager.instance.homeSelectIndex - 26 - 10 + 1;
            string formatString = "Audio/reminder/animal|guide_animal_{0}_01";
            path = string.Format(formatString, offsetIndex);
        }
        DoScaleAni(joinMainView.typeTransList[1].transform);
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
    }

    private void DoMouthReminder()
    {
        string path = string.Empty;
        if (GameManager.instance.curJoinType == JoinType.Letter)
        {
            path = "Audio/reminder/letter|guide_letter_02";
        }
        else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            path = "Audio/reminder/num|guide_num_02";
        }
        else
        {
            int offsetIndex = GameManager.instance.homeSelectIndex - 26 - 10 + 1;
            string formatString = "Audio/reminder/animal|guide_animal_{0}_02";
            path = string.Format(formatString, offsetIndex);
        }
        DoScaleAni(joinMainView.typeTransList[2].transform);
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
    }

    private void DoHairReminder()
    {
        Debug.Log("没头发");
    }

    private void DoHatReminder()
    {
        string path = string.Empty;
        if (GameManager.instance.curJoinType == JoinType.Letter)
        {
            path = "Audio/reminder/letter|guide_letter_05";
        }
        else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            path = "Audio/reminder/num|guide_num_05";
        }
        else
        {
            int offsetIndex = GameManager.instance.homeSelectIndex - 26 - 10 + 1;
            string formatString = "Audio/reminder/animal|guide_animal_{0}_05";
            path = string.Format(formatString, offsetIndex);
        }
        DoScaleAni(joinMainView.typeTransList[4].transform);
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
    }

    private void DoHeadWearReminder()
    {
        string path = string.Empty;
        if (GameManager.instance.curJoinType == JoinType.Letter)
        {
            path = "Audio/reminder/letter|guide_letter_06";
        }
        else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            path = "Audio/reminder/num|guide_num_06";
        }
        else
        {
            int offsetIndex = GameManager.instance.homeSelectIndex - 26 - 10 + 1;
            string formatString = "Audio/reminder/animal|guide_animal_{0}_06";
            path = string.Format(formatString, offsetIndex);
        }
        DoScaleAni(joinMainView.typeTransList[5].transform);
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
    }

    private void DoHandReminder()
    {
        string path = string.Empty;
        if (GameManager.instance.curJoinType == JoinType.Letter)
        {
            path = "Audio/reminder/letter|guide_letter_03";
        }
        else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            path = "Audio/reminder/num|guide_num_03";
        }
        else
        {
            int offsetIndex = GameManager.instance.homeSelectIndex - 26 - 10 + 1;
            string formatString = "Audio/reminder/animal|guide_animal_{0}_03";
            path = string.Format(formatString, offsetIndex);
        }
        DoScaleAni(joinMainView.typeTransList[6].transform);
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
    }

    private void DoLegReminder()
    {
        string path = string.Empty;
        if (GameManager.instance.curJoinType == JoinType.Letter)
        {
            path = "Audio/reminder/letter|guide_letter_04";
        }
        else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            path = "Audio/reminder/num|guide_num_04";
        }
        else
        {
            int offsetIndex = GameManager.instance.homeSelectIndex - 26 - 10 + 1;
            string formatString = "Audio/reminder/animal|guide_animal_{0}_04";
            path = string.Format(formatString, offsetIndex);
        }
        DoScaleAni(joinMainView.typeTransList[7].transform);
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
    }

    private void DoTrueBodyReminder()
    {
        string path = string.Empty;
        DoScaleAni(joinMainView.typeTransList[9].transform);
    }

    private void DoScaleAni(Transform trans)
    {
        curAniTrans = trans;
        Sequence s = DOTween.Sequence();
        s.Append(trans.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.25f));
        s.Append(trans.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
        s.SetLoops(4);

        sequence = DOTween.Sequence();
        sequence.Append(s);
        sequence.AppendInterval(1);

        sequence.SetLoops(2);
    }

    private void DoDrawNextStepReminder()
    {
        if (joinMainView.step==4)
        {
            string path = "Audio/reminder/common_reminder_audio|guide_universal_02";
            DoScaleAni(joinMainView.BtnOk.transform);
            AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
        }
        else
        {
            string path = "Audio/reminder/common_reminder_audio|guide_universal_01";
            DoScaleAni(joinMainView.BtnNext.transform);
            AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
        }
    }

    private void DoNextStepReminder()
    {
        string path = "Audio/reminder/common_reminder_audio|guide_universal_02";
        DoScaleAni(joinMainView.BtnNext.transform);
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
    }

    private void DoCompleteReminder()
    {
        string path = "Audio/reminder/common_reminder_audio|guide_universal_02";
        AudioManager.instance.PlayAudio(EffectAudioType.Reminder, path);
        DoScaleAni(joinMainView.BtnOk.transform);
    }

    private void BreakReminder()
    {
        DrawReminder.gameObject.SetActive(false);
        DragReminder.gameObject.SetActive(false);
        //停止提示动画
        if (sequence!=null)
        {
            //Debug.Log("kill reminder ani===");
            sequence.Kill();
            sequence = null;

            //停止提示语音
            AudioManager.instance.StopEffect();
        }
        if (curAniTrans!=null)
        {
            curAniTrans.localScale = Vector3.one;
        }
    }

    private void OnEnable()
    {
        cor_Reminder = StartCoroutine("CorReminder");
    }

    private void OnDisable()
    {
        if (cor_Reminder != null)
        {
            StopCoroutine("CorReminder");
        }
    }



}
