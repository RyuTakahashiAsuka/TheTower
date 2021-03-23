using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : MonoBehaviour
{
    public bool CorrectAnswer;

    public bool Answer;
    public bool Active;

    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        Answer = true;
        Active = false;
        CorrectAnswer = false;
    }

    public void OnclickCorrectAnswer()
    {
        if (Answer == true)
        {
            Active = false;
            CorrectAnswer = true;
            Answer = false;
            controller.PlayerOperation = true;
            Debug.Log("正解！");
        }
    }
    public void OnClickInCorrectAnswer()
    {
        if (Answer == true) 
        {
            Active = false;
            CorrectAnswer = false;
            Answer = false;
            controller.PlayerOperation = true;
            StartCoroutine(WaitTime(3.0f, () =>
            {
                Answer = true;
                Debug.Log("再回答可能");
            }));
            Debug.Log("不正解...");
        }
    }

    private IEnumerator WaitTime(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
