﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TitleTextAnimation : MonoBehaviour
{
    public TextMeshProUGUI TitleText;

   
    void Awake()
    {
        TitleText.DOFade(0, 0);
    }
    //Start is called before the first frame update
    void Start()
    {
        DOTweenTMPAnimator Animator = new DOTweenTMPAnimator(TitleText);
        for(int i=0; i < Animator.textInfo.characterCount; i++)
        {
            DOTween.Sequence().
                Append(Animator.DOFadeChar(i, 1, 2f))
                .Join(Animator.DOOffsetChar(i,Vector3.up*20,1f).SetEase(Ease.InOutFlash,2))
                .AppendInterval(0.4f)
                .Append(Animator.DOColorChar(i, new Color(1f, 0.5f, 1f), 0.2f).SetEase(Ease.OutFlash,2))
                .SetDelay(i * 0.1f);
        }
    }

}
