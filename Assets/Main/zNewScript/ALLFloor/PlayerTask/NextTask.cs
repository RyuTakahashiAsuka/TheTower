using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTask : MonoBehaviour
{
    
    
    [HideInInspector]public int TaskNumCount = 0;//現在のタスクナンバー

    [SerializeField] string[] TextContent; //タスクテキストの内容
    
    private Text TaskText;//変更するテキスト
    
    // Start is called before the first frame update
    void Start()
    {
        TaskText = GetComponent<Text>();
        TaskText.text = TextContent[0];//最初はTextContent[0]、最初のタスクの表示
    }

    // Update is called once per frame
    void Update()
    {
        TaskText.text = TextContent[TaskNumCount];//タスクナンバーが変わればその内容にする
        if(TaskNumCount > TextContent.Length)//タスクナンバーが最後まで行って超えないようにする
        {
            TaskNumCount = TextContent.Length;
        }
    }
}
