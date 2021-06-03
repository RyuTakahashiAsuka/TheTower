using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using UnityEngine.UI;

public class ClearTimeText : MonoBehaviour
{

    private Text Timetext;//クリア時間を表示する為のテキスト
    public static int ClearTImeFainal;//最終的なスコア

    // Start is called before the first frame update
    void Start()
    {
        
        Timetext = GetComponent<Text>();//テキストコンポーネント取得
    }

    // Update is called once per frame
    void Update()
    {
       //ミリ秒を秒に直す
        /*それぞれの時間を表示*/
        Timetext.text = $"Score\n{ClearTImeFainal.ToString()}秒\n";
    }
}
