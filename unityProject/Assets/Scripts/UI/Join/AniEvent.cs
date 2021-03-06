﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent : MonoBehaviour
{
    public delegate void AnimationEndDelegate();
    public AnimationEndDelegate animationEndDelegate;
    public void AnimationEnd()
    {
        if (animationEndDelegate!=null)
        {
            animationEndDelegate();
        }
    }
}
