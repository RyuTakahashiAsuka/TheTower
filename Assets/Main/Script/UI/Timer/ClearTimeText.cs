using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ClearTime;

public class ClearTimeText : MonoBehaviour
{
    private Text Timetext;

    public static int first;
    public static int second;
    public static int third;
    public static int fourth;

    private string firstTime;
    private string secondTime;
    private string thirdTime;
    private string fourthTime;

    // Start is called before the first frame update
    void Start()
    {
        Timetext = GetComponent<Text>();
        firstTime = first.ToString();
        secondTime = second.ToString();
        thirdTime = third.ToString();
        fourthTime = fourth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timetext.text = ($"1階層：{firstTime}秒\n2階層：{secondTime}秒\n3階層：{thirdTime}秒\n4階層：{fourthTime}秒");
    }
}
