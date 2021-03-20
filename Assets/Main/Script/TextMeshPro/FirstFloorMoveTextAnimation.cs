using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FirstFloorMoveTextAnimation : MonoBehaviour
{
    TextMeshProUGUI moveText;


    void Start()
    {
        moveText = GetComponent<TextMeshProUGUI>();
        moveText.DOFade(0, 0);
        DOTweenTMPAnimator TextAnimator = new DOTweenTMPAnimator(moveText);

        for (int i = 0; i < TextAnimator.textInfo.characterCount; i++)
        {
            TextAnimator.DOFadeChar(i, 1, 2f).SetDelay(i * 0.1f);
        }
    }
}
