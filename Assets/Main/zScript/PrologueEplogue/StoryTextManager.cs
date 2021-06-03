using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*追加*/
using TMPro;
using DG.Tweening;

public class StoryTextManager : MonoBehaviour
{
    //文字、テキスト参照、ボタン参照
    [Header("テキスト")]
    [Tooltip("Size＝行数")]
    [SerializeField] private string[] story; //行数と内容　inspector上で変更可能
    [Header("UI類")]
    [SerializeField] private TextMeshProUGUI UIText; //実際書き換えるテキスト
    [SerializeField] private GameObject Button; //シーン切り替え用のボタン

    //行の表示
    private int LineNumber = 0;//現在の行数
    //文字の順番表示
    [SerializeField] [Range(0.001f, 0.3f)]
    private float DisplayTime = 0.05f;//一文字表示までの想定時間

    private string textNum = string.Empty;//現在の文字列
    private float CurrentTime = 0;//表示までの時間
    private float StartTime = 1;//表示開始時間
    private int CurrentText = -1;//表示中の文字数

    //表示時間スキップ
    public bool CompleteDisplay
    {
        get { return Time.time > StartTime + CurrentTime; }
    }

    // Start is called before the first frame update
    void Start()
    {
        StoryUpdate();
        Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //文字の表示が完了しているかどうか
        if (CompleteDisplay)
        {
            //行数がラストまで行っていなかったら更新
            if (LineNumber < story.Length && Input.GetMouseButtonUp(0))
            {
                StoryUpdate();
            }
        }
        else
        {   //文字の表示が完了していない場合全て表示
            if (Input.GetMouseButtonUp(0))
            {
                CurrentTime = 0;
            }
        }
        if(LineNumber==story.Length && Input.GetMouseButtonUp(0))//最後の行まで、行ったらシーン切り替え用のボタンをアクティブに
        {
            Button.SetActive(true);
        }
        
        int Count = (int)(Mathf.Clamp01((Time.time - StartTime) / CurrentTime)* textNum.Length);//時間と想定時間から文字数出し
        
        if (Count != CurrentText)//現在の文字数が前と異なるならテキストを更新する。
        {
            UIText.text = textNum.Substring(0, Count);
            CurrentText = Count;
        }
    }

    /*文字送り*/
    void StoryUpdate()
    {
        textNum = story[LineNumber];
        LineNumber ++;

        CurrentTime = textNum.Length * DisplayTime;
        StartTime = Time.time;

        CurrentText = -1;
    }
}
