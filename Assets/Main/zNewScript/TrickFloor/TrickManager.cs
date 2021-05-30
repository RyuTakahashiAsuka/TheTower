using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using DG.Tweening;

public class TrickManager : MonoBehaviour
{
    [Header("数値類")]
    [SerializeField]
    public int Trick_MaxNum;//仕掛けの数
   
    [Header("スクリプト類")]
    [SerializeField]
    private TriggerFadeStart CannextScene;//クリアしたかしてないか（シーン移動が可能かどうか）
    


    [HideInInspector]public int nowTrick_Num = 1;//今現在の解いた仕掛けの数

    // Start is called before the first frame update
    void Start()
    {
        CannextScene.CanNextScene = false;//次シーンへの移動が出来ない状態
    }

    // Update is called once per frame
    void Update()
    {
        if(Trick_MaxNum+1 == nowTrick_Num)//現在の仕掛けクリア数が仕掛け数＋１（仕掛けを初期値１から始める為）と同じになったら部屋クリア
        {
            CannextScene.CanNextScene = true;//次のシーンへ飛べる様に
        }
       
    }

}
