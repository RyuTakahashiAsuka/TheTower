using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameClearTextAnimation : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        DOTweenTMPAnimator Animator = new DOTweenTMPAnimator(text);
        for(int i = 0; i < Animator.textInfo.characterCount; i++)
        {
            DOTween.Sequence()
                .Append(Animator.DOOffsetChar(i, Vector3.up * 20, 2f)
                .SetEase(Ease.InOutFlash, 2))
                .SetLoops(-1);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
