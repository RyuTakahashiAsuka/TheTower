using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AnswerTextAnimation : MonoBehaviour
{
    [Header("スクリプト類")]
    [SerializeField] private AnswerManager answer; //正解不正解の判定を確認する用

    [Header("テキスト")]
    [SerializeField] private TextMeshProUGUI AnswerText;//正解不正解を表示するテキスト

    private string[] CorrectAnswer = {"正解！","不正解！","再回答可能"};

    // Start is called before the first frame update
    void Start()
    {
        AnswerText.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();
    }

    void TextUpdate()//正解不正解によって文字を変える
    {
        if (answer.Correctanswer == true)
        {
            AnswerText.text = CorrectAnswer[0];
        }
        else 
        {
            if (answer.answer == false)
            {
                AnswerText.text = CorrectAnswer[1];
            }
            else
            {
                AnswerText.text = CorrectAnswer[2];
            }
        }
    }
    public void CorrectButtonClick()//正解(UIボタンに渡す)
    {
        AnswerText.transform.DOScale(1f, 0.7f).OnComplete(OutTextAnimation);
    }
    public void InCorrectButtonClick()//不正解(UIボタンに渡す)
    {
        AnswerText.transform.DOScale(1f, 0.7f).OnComplete(OutTextAnimation);
    }
    public void ReAnswerText()//再回答可能時の案内テキストの表示
    {
        
        AnswerText.transform.DOScale(1f, 0.7f).OnComplete(OutTextAnimation);
    }
    void OutTextAnimation()//テキストを消す
    {
        AnswerText.transform.DOScale(0f, 0.5f);
    }
}
