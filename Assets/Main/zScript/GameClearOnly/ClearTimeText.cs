using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using UnityEngine.UI;
using static ClearTime;

public class ClearTimeText : MonoBehaviour
{
    private Text Timetext;//クリア時間を表示する為のテキスト

    /*各階層のクリア時間用変数*/
    private int ClearTimeFinal;
    

    // Start is called before the first frame update
    void Start()
    {
        Timetext = GetComponent<Text>();//テキストコンポーネント取得
        ClearTimeFinal = ClearTimeAll/1000;//ミリ秒を秒に直す
    }

    // Update is called once per frame
    void Update()
    {
        /*それぞれの時間を表示*/
        Timetext.text = $"Score\n{ClearTimeFinal.ToString()}秒";
    }
}
