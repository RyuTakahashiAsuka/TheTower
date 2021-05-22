using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FifthTask : MonoBehaviour
{
    private Text text;

    public FirstButton OnFirstButton;
    public SecondButton OnSecondButton;
    public ThirdButton thirdButton;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "ボタンを探そう";
    }

    // Update is called once per frame
    void Update()
    {
        if(OnFirstButton.OnFirstButton == true && !OnSecondButton.OnSecondButton)
        {
            text.text = "どこかにまだボタンがあるようだ";
        }
        else if(OnFirstButton.OnFirstButton == true && OnSecondButton.OnSecondButton == true && !thirdButton.OnThirdButton)
        {
            text.text = "どこかにまだボタンがありそう";
        }
        else if(OnFirstButton.OnFirstButton == true && OnSecondButton.OnSecondButton == true && thirdButton.OnThirdButton == true)
        {
            text.text = "階段に向かおう";
        }
    }
}
