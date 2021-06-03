using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using UnityEngine.UI;

public class AnswerManager: MonoBehaviour
{
    [Header("スクリプト類(Bool)")]
    [SerializeField] private MouseCursorShowHide MouseCursorShow;//マウスカーソルの表示非表示用スクリプト呼び出し
    [SerializeField] private PlayerController PlayerController;//プレイヤー動き制限用
    [SerializeField] private TriggerFadeStart NextFloorStairs;//シーン移動を可能にする
    [Header("スクリプト類(UIボタン用)")]
    [SerializeField] private TriggerPanelOpen QuestionBook;//UIパネルを閉じる時の動き用スクリプト
    [SerializeField] private AnswerTextAnimation AnsTextAnimation; //AnswerButtonを押した際のテキストアニメーション用
    [Header("スクリプト類(タスクテキスト)")]
    [SerializeField] private NextTask taskNumPlus;//現在のタスクを更新する為の参照

    [HideInInspector] public bool answer;//回答可能かどうかの判定

    [HideInInspector] public bool Correctanswer;//正解不正解
    
    // Start is called before the first frame update
    void Start()
    {
        answer = true;
        Correctanswer = false;
        NextFloorStairs.CanNextScene = false;
    }

    private void Update()
    {
        if(Correctanswer == true)//正解し、階層をクリアした時、次のシーンの移動を可能に
        {
            NextFloorStairs.CanNextScene = true;
        }
    }

    public void OnclickCorrectAnswer()//正解
    {
   
        Correctanswer = true;//正解判定をtrueに
        answer = false;//正解なので回答可能を不可に
        PlayerController.PlayerOperation = true;//プレイヤーの行動を可能に
        MouseCursorShow.CursorShow = false;//カーソルを非表示に    

        taskNumPlus.TaskNumCount = taskNumPlus.TaskNumCount + 1;//タスクの終了次のタスクへ

        QuestionBook.OnclickBackButton();//UIパネルを閉じる
        AnsTextAnimation.CorrectButtonClick();//正解のテキストアニメーション
        Debug.Log("正解！");    
    }

    public void OnClickInCorrectAnswer()//不正解
    {
        Correctanswer = false;//不正解
        answer = false;//不正解なので一時回答不可
        PlayerController.PlayerOperation = true;//プレイヤーの行動を可能に
        MouseCursorShow.CursorShow = false;//カーソルを非表示に  
        
        QuestionBook.OnclickBackButton();//UIパネルを閉じる
       AnsTextAnimation.InCorrectButtonClick();//不正解のテキストアニメーション

        StartCoroutine(WaitTime(3.0f, () =>//3秒待ってから回答可能に
            {
                answer = true;//回答可能
                AnsTextAnimation.ReAnswerText();//再回答可能のテキストアニメーション
                Debug.Log("再回答可能");
            }));
            Debug.Log("不正解...");
        
    }

    private IEnumerator WaitTime(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
