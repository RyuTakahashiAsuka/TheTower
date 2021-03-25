using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TextManager : MonoBehaviour
{
    //文字、テキスト参照、ボタン参照
    public string[] story;
    public TextMeshProUGUI UIText;
    public GameObject Button;

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
        if(LineNumber==story.Length && Input.GetMouseButtonUp(0))
        {
            Button.SetActive(true);
        }
        //時間と想定時間から文字数出し
        int Count = (int)(Mathf.Clamp01((Time.time - StartTime) / CurrentTime)* textNum.Length);
        //現在の文字数が前と異なるならテキストを更新する。
        if (Count != CurrentText)
        {
            UIText.text = textNum.Substring(0, Count);
            CurrentText = Count;
        }
    }

    void StoryUpdate()
    {
        textNum = story[LineNumber];
        LineNumber ++;

        CurrentTime = textNum.Length * DisplayTime;
        StartTime = Time.time;

        CurrentText = -1;
    }
}
