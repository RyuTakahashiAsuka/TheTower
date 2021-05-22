using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    public static float FirstTime;
    public static float SecondTime;
    public static float ThirdTime;
    public static float FourthTime;

    public static bool StartCount = false;
    
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    public static float oldSeconds;
    private Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        TimerText = GetComponentInChildren<Text>();
        StartCount = true;
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
    }
}
