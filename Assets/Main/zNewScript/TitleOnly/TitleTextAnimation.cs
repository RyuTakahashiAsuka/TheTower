using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*↓追加↓*/
using TMPro;//TextMeshPro
using DG.Tweening;//Dotweenライブラリ

public class TitleTextAnimation : MonoBehaviour
{
    
    private TextMeshProUGUI TitleText;//動かすテキストの変数

   
    void Awake()
    {
        TitleText = GetComponent<TextMeshProUGUI>();//TextMeshProコンポーネント取得
        TitleText.DOFade(0, 0);//初期値0で表示を消す
        //※DoFadeは透明度
    }
    //Start is called before the first frame update
    void Start()
    {
        DOTweenTMPAnimator Animator = new DOTweenTMPAnimator(TitleText);

        for(int i=0; i < Animator.textInfo.characterCount; i++)//for分で透明度の値を変える(Fade)
        {
            DOTween.Sequence().//Seqence = 一回のアニメーションをまとめるもの
                Append(Animator.DOFadeChar(i, 1, 2f))//テキストの透明度をだんだん上げていく
                .Join(Animator.DOOffsetChar(i,Vector3.up*20,1f).SetEase(Ease.InOutFlash,2))//文字を個別に少し跳ねさせる
                .AppendInterval(0.4f)
                .Append(Animator.DOColorChar(i, new Color(1f, 0.5f, 1f), 0.2f).SetEase(Ease.OutFlash,2))//DoColorCharとEase.OutFlashで光が走る様にする
                .SetDelay(i * 0.1f);
        }
    }

}
