using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTask : MonoBehaviour
{
    public static bool fireballOne = false;
    public static bool fireballTwo = false;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "火の玉の近くに行って確認してみよう";
    }

    // Update is called once per frame
    void Update()
    {
        if(fireballOne == true && fireballTwo == true)
        {
            text.text = "階段を探して上へのぼろう";
        }
    }
}
