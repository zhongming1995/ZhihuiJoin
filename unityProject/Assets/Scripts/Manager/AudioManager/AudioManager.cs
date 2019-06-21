using System;
using System.Collections;
using System.Collections.Generic;
using Helper;
using UnityEngine;

namespace AudioMgr {

    public enum EffectAudioType
    {
        Guide = 0,//引导语音
        Reminder = 1,//提示语音
        Option = 2,//选项语音
        None = 3,//未播放
    }

    /// <summary>
    /// 音频管理类
    /// 需要添加两个AudioSource到场景中，第一个播bgm，第二个播音效
    /// </summary>
    public class AudioManager : SingletonMono<AudioManager>
    {
        void Awake()
        {
            instance = this;
        }

        //索引赋值
        public AudioSource bgmAudioSource;//播BGM的AudioSource
        public AudioSource effectAudioSource;//播音效的AudioSource

        private string defaultBgmPath = "";
        private Coroutine cor_play;
        private EffectAudioType curAudioType;
        private AudioClip commonBtnClip;//通用的按钮音效
        private IEnumerator cor_playOptionAfterBtn;

        private Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();//音频库
        private AudioSource[] audioSourceArr; //音频源数（一个播bgm,一个播音效)

        private bool _bgmEnable = true;        //是否允许播放bgm
        public bool BgmEnable
        {
            get { return _bgmEnable; }
            set
            {
                if (_bgmEnable != value)
                {
                    _bgmEnable = value;
                    instance.bgmAudioSource.enabled = _bgmEnable;
                    if (_bgmEnable)
                    {
                        instance.bgmAudioSource.UnPause();
                    }
                    else
                    {
                        instance.bgmAudioSource.Pause();
                    }
                }
            }
        }

        public void BgmPause()
        {
            bgmAudioSource.Pause();
        }

        public void BgmUnPause()
        {
            bgmAudioSource.UnPause();
        }
        private bool _effectEnable = true;    //是允许播放音效
        public bool EffectEnable
        {
            get { return _effectEnable; }
            set
            {
                if (_effectEnable != value)
                {
                    _effectEnable = value;
                    instance.effectAudioSource.enabled = _effectEnable;
                    if (_effectEnable)
                    {
                        instance.effectAudioSource.Play();
                    }
                    else
                    {
                        instance.effectAudioSource.Stop();
                    }
                }
            }
        }

        private float _bgmVolumn = 1.0f;       //bgm音量
        public float BgmVolumn
        {
            get { return _bgmVolumn; }
            set
            {
                if (_bgmVolumn != value)
                {
                    _bgmVolumn = value;
                    instance.bgmAudioSource.volume = _bgmVolumn;
                }
            }
        }

        private float effectVolumn = 1.0f;    //音效音量
        public float EffectVolumn
        {
            get { return effectVolumn; }
            set
            {
                if (effectVolumn != value)
                {
                    effectVolumn = value;
                    instance.effectAudioSource.volume = effectVolumn;
                }
            }
        }

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="isLoop">If set to <c>true</c> is loop.</param>
        public void PlayBGM(string path, bool isLoop = true)
        {
            if (string.IsNullOrEmpty(path))
            {
                instance.bgmAudioSource.Stop();
                instance.bgmAudioSource.clip = null;
            }
            AudioClip clip;
            if (audioDic.ContainsKey(defaultBgmPath))
            {
                clip = audioDic[defaultBgmPath];
            }
            else
            {
                clip = UIHelper.instance.LoadAudioClip(defaultBgmPath);
                audioDic.Add(path, clip);
            }
            if (null == clip)
            {
                instance.bgmAudioSource.Stop();
                instance.bgmAudioSource.clip = null;
                return;
            }
            instance.bgmAudioSource.clip = clip;
            instance.bgmAudioSource.loop = isLoop;
            if (_bgmEnable)
            {
                instance.bgmAudioSource.Play();
            }
        }

        /// <summary>
        /// 播放默认的BGM
        /// </summary>
        /// <param name="isLoop">If set to <c>true</c> is loop.</param>
        public void PlayDefaultBGM(bool isLoop = true)
        {
            if (!_bgmEnable)
            {
                return;
            }
            if (string.IsNullOrEmpty(defaultBgmPath))
            {
                instance.bgmAudioSource.Stop();
                instance.bgmAudioSource.clip = null;
            }
            PlayBGM(defaultBgmPath, isLoop);
        }

        /// <summary>
        /// 设置音频资源
        /// </summary>
        /// <param name="path">Path.</param>
        private AudioClip SetAudioClip(string path)
        {
            if (!_effectEnable)
            {
                return null;
            }

            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            AudioClip clip;
            if (audioDic.ContainsKey(path))
            {
                clip = audioDic[path];
            }
            else
            {
                clip = UIHelper.instance.LoadAudioClip(path);
                audioDic.Add(path, clip);
            }
            if (clip == null)
            {
                Debug.LogWarning("play effect:audio clip is null-----");
                return null;
            }

            return clip;
        }

        /// <summary>
        /// 播放音效（选项语音+引导语音+提示语音）
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="cb">Cb.</param>
        public void PlayEffect(string path, Action cb = null)
        {
            AudioClip clip = SetAudioClip(path);
            if (clip != null)
            {
                if (effectAudioSource.isPlaying && effectAudioSource.clip == clip)
                {
                    Debug.LogWarning("play effect:same audio clip--------");
                    return;
                }
                instance.effectAudioSource.volume = effectVolumn;
                instance.effectAudioSource.playOnAwake = false;
                instance.effectAudioSource.clip = clip;
                instance.effectAudioSource.rolloffMode = AudioRolloffMode.Linear;
                instance.effectAudioSource.enabled = true;
                instance.effectAudioSource.spatialBlend = 0f;
                instance.effectAudioSource.Play();
                if (cb != null)
                {
                    cor_play = StartCoroutine("Cor_PlayEffect", cb);
                }
            }
            else
            {
                Debug.Log("clip is null2-------------");
            }
        }

        public void PlayPiano(string path)
        {
            AudioClip clip = SetAudioClip(path);
            if (clip!=null)
            {
                instance.effectAudioSource.PlayOneShot(clip);
            }
        }

        IEnumerator Cor_PlayEffect(Action cb)
        {
            yield return new WaitForSeconds(instance.effectAudioSource.clip.length);
            curAudioType = EffectAudioType.None;
            cb?.Invoke();
        }

        public void StopEffect()
        {
            if (effectAudioSource)
            {
                effectAudioSource.Stop();
                effectAudioSource.clip = null;
            }
            if (cor_play!=null)
            {
                StopCoroutine(cor_play);
            }
        }

        public void StopEffectAfterCommonBtn()
        {
            StartCoroutine("Cor_StopEffectAfterCommonBtn");
        }

        IEnumerator Cor_StopEffectAfterCommonBtn()
        {
            yield return new WaitForSeconds(commonBtnClip.length);
            StopEffect();
        }

        /// <summary>
        /// 播放选项语音
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="cb">Cb.</param>
        public void PlayOptionAudio(string path, Action cb = null)
        {
            if (commonBtnClip == null)
            {
                commonBtnClip = UIHelper.instance.LoadAudioClip("Audio/button_effect|common_button");
            }
            //effectAudioSource.clip = commonBtnClip;
            effectAudioSource.PlayOneShot(commonBtnClip);
            Debug.Log("playOneShot--------");
            if (curAudioType == EffectAudioType.Guide&&effectAudioSource.isPlaying)
            {
                return;
            }
            curAudioType = EffectAudioType.Option;
           
            if (cor_playOptionAfterBtn != null)
            {
                StopCoroutine(cor_playOptionAfterBtn);
            }
            cor_playOptionAfterBtn = Cor_PlayOptionAfterButtonAudio(path, cb);
            StartCoroutine(cor_playOptionAfterBtn);

        }

        IEnumerator Cor_PlayOptionAfterButtonAudio(string path,Action cb)
        {
            yield return new WaitForSeconds(commonBtnClip.length);
            if (path!=null)
            {
                PlayEffect(path, cb);
            }
        }

        /// <summary>
        /// 播放引导语音,优先级1
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="cb">Cb.</param>
        public void PlayGuideAudio(string path,Action cb = null)
        {
            if (cor_playOptionAfterBtn!=null)
            {
                StopCoroutine(cor_playOptionAfterBtn);
            }
            curAudioType = EffectAudioType.Guide;
            PlayEffect(path, cb);
        }

        /// <summary>
        /// 播放提示语音
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="cb">Cb.</param>
        public void PlayReminderAudio(string path, Action cb = null)
        {
            if (cor_playOptionAfterBtn != null)
            {
                StopCoroutine(cor_playOptionAfterBtn);
            }
            curAudioType = EffectAudioType.Reminder;
            PlayEffect(path, cb);
        }

        public void PlayAudio(EffectAudioType type, string path, Action cb = null)
        {
            if (type == EffectAudioType.Option)
            {
                PlayOptionAudio(path, cb);
            }else if (type == EffectAudioType.Guide)
            {
                PlayGuideAudio(path, cb);
            }else if (type == EffectAudioType.Reminder)
            {
                PlayReminderAudio(path, cb);
            }
        }
    }
}
