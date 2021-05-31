using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FadeMoveTextAnimation : MonoBehaviour
{
    private TextMeshProUGUI moveText;//実際のテキスト（テキスト自体につけるため参照は無し）
    private DOTweenTMPAnimator TextAnimator;//テキストアニメーター

    public bool AnimationStart=false;//アニメーションのスタート管理用（ボタンを押した時などに呼ぶためpublicで作成）
    void Start()
    {
        moveText = GetComponent<TextMeshProUGUI>();
        moveText.DOFade(0, 0);//初期は０で表示無し
        TextAnimator = new DOTweenTMPAnimator(moveText);//実際のテキストの新しいアニメータの作成
        AnimationStart = false;
    }
    void Update()
    {
        if(AnimationStart == true)//アニメーションスタート
        {
            FadeIn();
            AnimationStart = false;
        }
    }
    public void FadeIn()//テキストのフェードイン
    {
        for (int i = 0; i < TextAnimator.textInfo.characterCount; i++)
        {
            //テキストを2秒かけてフェードし、その後少しおいてフェードアウトをスタートする
            TextAnimator.DOFadeChar(i, 1, 2f).SetDelay(i * 0.1f).OnComplete(TextFadeOut);
        }
    }
    public void TextFadeOut()//フェードアウト
    {
        for(int i = 0; i < TextAnimator.textInfo.characterCount; i++)
        {
            //2秒かけてフェードアウトする
            TextAnimator.DOFadeChar(i, 0, 2f).SetDelay(i * 0.1f);
        }
    }
}
