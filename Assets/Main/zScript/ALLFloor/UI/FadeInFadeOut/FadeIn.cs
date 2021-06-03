using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*追加*/
using DG.Tweening;

public class FadeIn : MonoBehaviour
{
    [Header("数値類")]
    [SerializeField]
    private float FadeTime = 2.0f;//フェードする時間
    private CanvasGroup canvasGroup; //パネルのキャンバスグループ
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();//キャンバスグループコンポーネント取得
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.DOFade(0, FadeTime);//FadeTime秒掛けてフェードし、フェードごFadeCompleteを呼び出す
    }
}
