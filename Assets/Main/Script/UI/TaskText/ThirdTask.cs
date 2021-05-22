using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdTask : MonoBehaviour
{
    [SerializeField]
    private BookButton Onbutton;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "ボタンを探そう";
    }

    // Update is called once per frame
    void Update()
    {
        if (Onbutton.ButtonOnOff == true)
        {
            text.text = "階段に向かおう";
        }
    }
}
