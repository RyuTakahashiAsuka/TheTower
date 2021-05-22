using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Choices;

public class SecondTask : MonoBehaviour
{
    [SerializeField]
    private Choices choices;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "問題が書かれた本を見つけよう";
    }

    // Update is called once per frame
    void Update()
    {
        if(choices.CorrectAnswer == true)
        {
            text.text = "階段に向かおう";
        }
    }
}
