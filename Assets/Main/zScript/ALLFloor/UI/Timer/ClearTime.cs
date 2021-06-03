using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using UnityEngine.UI;
using static ClearTimeText;

public class ClearTime : MonoBehaviour
{
    [Header("スクリプト類")]
    [SerializeField] private FadeOut fadestart;//フェードが開始される判定を取得
    public static int Lasttime;

    private int minute = 0;　//分
    private float seconds = 0f;//秒

    private bool CountUpFlag;//カウント用フラグ
    public static bool CountStartEndFlag;//カウントの開始と終わり

    private Text TimerText;//表示するテキスト

    // Start is called before the first frame update
    void Start()
    {
        CountStartEndFlag = true;
        CountUpFlag = false;
        minute = 0;
        seconds = 0f;
        Lasttime = 0;
        TimerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (CountStartEndFlag == true)
        {
            if (!CountUpFlag) { StartCoroutine("TimeCount"); }
        }
    }
  
    private IEnumerator TimeCount()//カウントコルーチン
    {

        CountUpFlag = true;//フラグをtrueにして次に実行されるコルーチンを止める
        yield return new WaitForSeconds(1.0f);//一秒待って
        seconds++;//カウント1追加
        if (seconds >= 60f)//60秒たったら分に直す
        {
            minute++;
            seconds = seconds - 60;
        }

        TimerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");//テキストに変更を加える
        
        Lasttime = ((int)seconds + (minute * 60));

        CountUpFlag = false;//上記で1秒待ってる状態なのでコルーチンが実行出来る様にフラグをfalseに変更

    }
}
