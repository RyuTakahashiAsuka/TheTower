using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAnswer : MonoBehaviour
{
    [Header("オブジェクト類")]
    [SerializeField] private GameObject QuestionBook;//一時的に Triggerを無効にする用にTriggerPanelOpenのついている問題の本取得

    [Header("スクリプト類")]
    [SerializeField] private AnswerManager answerBool;// bool answer取得用

    // Update is called once per frame
    void Update()
    {
        if(answerBool.answer == false)//正解した場合、もしくは不正解の再回答までの時間、回答不可状態にする
        {
            QuestionBook.GetComponent<TriggerPanelOpen>().enabled = false;
        }
        else
        {
            QuestionBook.GetComponent<TriggerPanelOpen>().enabled = true;
        }
    }
}
