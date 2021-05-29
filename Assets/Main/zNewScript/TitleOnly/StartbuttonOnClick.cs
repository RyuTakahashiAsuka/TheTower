using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*追加*/
using DG.Tweening;

public class StartbuttonOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject FadeOutPanel;//フェードアウトパネル取得用

    private void Start()
    {
        FadeOutPanel.SetActive(false);//フェードアウトパネルのActiveは最初はfalse
    }
    public void OnclickAnimation()
    {
        //ボタンのScale値を初期値から一秒で1.1にして、Ease.OutFlashで繰り返し元のScaleにもどる
        this.transform.DOScale(1.1f, 1.0f).SetEase(Ease.OutFlash,2);
        FadeOutPanel.SetActive(true);//ボタンを押したと同時にフェードパネルをtrueにしてフェード開始
    }
}
