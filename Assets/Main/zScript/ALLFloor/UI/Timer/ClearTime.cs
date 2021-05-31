using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    [Header("スクリプト類")]
    [SerializeField] private FadeOut fadeStartbool;//フェード開始を確認する為
    public static int ClearTimeAll = 0;//クリアタイムを保持しておく


    private int minute;　//分
    private float seconds;//秒
    [SerializeField]private float oldSeconds;//経過時間

    private Text TimerText;//表示するテキスト

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        TimerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            TimerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        if(fadeStartbool.fadeStart == true)
        {
            ClearTimeAll =ClearTimeAll + (int)oldSeconds;
        }
    }
}
