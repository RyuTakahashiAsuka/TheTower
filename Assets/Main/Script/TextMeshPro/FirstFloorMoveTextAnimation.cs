using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FirstFloorMoveTextAnimation : MonoBehaviour
{
    TextMeshProUGUI moveText;
    DOTweenTMPAnimator TextAnimator;

    public bool Animation=false;
    void Start()
    {
        moveText = GetComponent<TextMeshProUGUI>();
        moveText.DOFade(0, 0);
        TextAnimator = new DOTweenTMPAnimator(moveText);
        FadeIn();
    }
    
    public void FadeIn()
    {
        for (int i = 0; i < TextAnimator.textInfo.characterCount; i++)
        {
            TextAnimator.DOFadeChar(i, 1, 2f).SetDelay(i * 0.1f).OnComplete(TextFadeOut);
        }
    }
    public void TextFadeOut()
    {
        for(int i = 0; i < TextAnimator.textInfo.characterCount; i++)
        {
            TextAnimator.DOFadeChar(i, 0, 2f).SetDelay(i * 0.1f);
        }
    }
}
