using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TitleTextAnimation : MonoBehaviour
{
    TextMeshProUGUI TitleText;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        TitleText = GetComponent<TextMeshProUGUI>();
        TitleText.DOFade(0, 0);
        DOTweenTMPAnimator Animator = new DOTweenTMPAnimator(TitleText);
        for(i=0; i < Animator.textInfo.characterCount; i++)
        {
            DOTween.Sequence().
                Append(Animator.DOFadeChar(i, 1, 2f))
                .AppendInterval(0.3f)
                .Append(Animator.DOColorChar(i, new Color(1f, 1f, 0.8f), 0.2f).SetLoops(2, LoopType.Yoyo))
                .SetDelay(i * 0.1f);
        }
       

    }

}
