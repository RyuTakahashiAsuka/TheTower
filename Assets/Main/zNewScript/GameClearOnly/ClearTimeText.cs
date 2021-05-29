using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTimeText : MonoBehaviour
{
    private Text Timetext;//クリア時間を表示する為のテキスト

    /*各階層のクリア時間用変数*/
    /*今は4つしか無いので各変数を用意、もっと増やす場合は配列に格納も視野に*/
    public static int first;
    public static int second;
    public static int third;
    public static int fourth;
    /*クリア時間をstring型で保存する変数*/
    /*今は4つしか無いので各変数を用意、もっと増やす場合は配列に格納も視野に*/
    private string firstTime;
    private string secondTime;
    private string thirdTime;
    private string fourthTime;

    // Start is called before the first frame update
    void Start()
    {
        Timetext = GetComponent<Text>();//テキストコンポーネント取得
        /*時間をStringに変換*/
        firstTime = first.ToString();
        secondTime = second.ToString();
        thirdTime = third.ToString();
        fourthTime = fourth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*それぞれの時間を表示*/
        Timetext.text = ($"1階層：{firstTime}秒\n2階層：{secondTime}秒\n3階層：{thirdTime}秒\n4階層：{fourthTime}秒");
    }
}
