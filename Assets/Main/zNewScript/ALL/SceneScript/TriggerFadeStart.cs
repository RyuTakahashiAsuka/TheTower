using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFadeStart : MonoBehaviour
{
    [SerializeField] private FadeOut FadeStart;//フェードアウト開始Bool判定呼び出し用
    [SerializeField] private PlayerController operation;//プレイヤーの動き制限用

    private bool FadeNext = false;//当たり判定用
    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)//プレイヤーが当たったら
    {
        if (other.tag == "Player")
        {
            FadeStart.fadeStart = true;//次シーンへのフェードアウト開始
            operation.PlayerOperation = false;//プレイヤーの動きを止める
        }
    }
}
