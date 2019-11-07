using System;
using System.Collections;
using System.Collections.Generic;
using Helper;
using UnityEngine;

namespace AudioMgr {

    public enum EffectAudioType
    {
        None = 0,//未播放
        Guide = 1,//引导语音
        Reminder = 2,//提示语音
        Option = 3,//选项语音
    }

    /// <summary>
    /// 音频管理类
    /// 需要添加3个AudioSource到场景中，第一个播bgm，第二个播音效,第三个播通用按钮
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
        public AudioSource commonBtnSource;//播放通用按钮音效的AudioSource

        private AudioClip curClip;//当前的音效，除通用按钮以外
        private string defaultBgmPath = "";
        private Coroutine cor_play;
        private EffectAudioType curAudioType;
        private AudioClip commonBtnClip;//通用的按钮音效
        private IEnumerator cor_playOptionAfterBtn;

        private Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();//音频库

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
            if (bgmAudioSource != null)
            {
                bgmAudioSource.Pause();
            }
        }

        public void BgmUnPause()
        {
            if (bgmAudioSource != null)
            {
                bgmAudioSource.UnPause();
            }
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
                    if (!_effectEnable)
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
                if (effectAudioSource.isPlaying && curClip == clip)
                {
                    Debug.LogWarning("play effect:same audio clip--------");
                    return;
                }
                instance.effectAudioSource.volume = effectVolumn;
                instance.effectAudioSource.playOnAwake = false;
                instance.effectAudioSource.clip = clip;
                curClip = clip;
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
                Debug.Log("clip is null2-------------"+path);
            }
        }

        public void PlayOneShotAudio(string path)
        {
            AudioClip clip = SetAudioClip(path);
            if (clip != null)
            {
                instance.effectAudioSource.PlayOneShot(clip);
            }
        }

        public void PlayOneShotAudioCommon()
        {
            AudioClip clip = SetAudioClip("Audio/option_audio/common_option_audio|common_button");
            if (clip != null)
            {
                instance.effectAudioSource.PlayOneShot(clip);
            }
        }

        IEnumerator Cor_PlayEffect(Action cb)
        {
            yield return new WaitForSeconds(instance.effectAudioSource.clip.length);
            curAudioType = EffectAudioType.None;
            curClip = null;
            cb?.Invoke();
        }

        public void StopEffect()
        {
            curAudioType = EffectAudioType.None;
            if (effectAudioSource)
            {
                effectAudioSource.Stop();
                effectAudioSource.clip = null;
            }
            if (cor_play != null)
            {
                StopCoroutine("Cor_PlayEffect");
            }
        }

        public void StopEffectAfterCommonBtn()
        {
            curAudioType = EffectAudioType.None;
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
            /*
            if (commonBtnClip == null)
            {
                commonBtnClip = UIHelper.instance.LoadAudioClip("Audio/option_audio/common_option_audio|common_button");
            }
            effectAudioSource.PlayOneShot(commonBtnClip);
            if (path == null)
            {
                return;
            }
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
            */
            if (curAudioType == EffectAudioType.Guide && effectAudioSource.isPlaying)
            {
                return;
            }
            if (cor_playOptionAfterBtn != null)
            {
                StopCoroutine(cor_playOptionAfterBtn);
            }
            curAudioType = EffectAudioType.Option;
            PlayEffect(path, cb);
        }

        IEnumerator Cor_PlayOptionAfterButtonAudio(string path, Action cb)
        {
            yield return new WaitForSeconds(commonBtnClip.length);
            if (path != null)
            {
                PlayEffect(path, cb);
            }
        }

        /// <summary>
        /// 播放引导语音,优先级1
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="cb">Cb.</param>
        public void PlayGuideAudio(string path, Action cb = null)
        {
            //Debug.Log("PlayGuideAudio------------");
            if (cor_playOptionAfterBtn != null)
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
            //Debug.Log("PlayReminderAudio------------");
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
                if (path == null)
                {
                    PlayCommonBtnAudio();
                }
                else
                {
                    PlayOptionAudio(path, cb);
                }
            }
            else if (type == EffectAudioType.Guide)
            {
                PlayGuideAudio(path, cb);
            }
            else if (type == EffectAudioType.Reminder)
            {
                PlayReminderAudio(path, cb);
            }
        }

        private void PlayCommonBtnAudio()
        {
            commonBtnSource.Play();//在编辑器中赋值过clip，与bgm一样
        }
    }
}
