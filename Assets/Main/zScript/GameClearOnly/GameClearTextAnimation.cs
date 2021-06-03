using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameClearTextAnimation : MonoBehaviour
{
    private　TextMeshProUGUI text;   //ゲームクリアと表示するテキスト

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        DOTweenTMPAnimator Animator = new DOTweenTMPAnimator(text);
        for(int i = 0; i < Animator.textInfo.characterCount; i++)
        {
            DOTween.Sequence()//Seqence = 一回のアニメーションをまとめるもの
                .Append(Animator.DOOffsetChar(i, Vector3.up * 20, 2f) //テキストを少し上下に動かす
                .SetEase(Ease.InOutFlash, 2)) //動かす時の動き方の変化　EaseをInOutFlashに設定
                .SetLoops(-1); //-1　無限ループ
        }
    }
}
