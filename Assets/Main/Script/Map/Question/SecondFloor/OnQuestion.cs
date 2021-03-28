using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class OnQuestion : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject Text;
    public PlayerController controller;
    public Choices Active;

    public TextMeshProUGUI AnswerText;
    public TextMeshProUGUI RetryText;
    public string[] answer = new string[2];

    bool Trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        Panel.transform.localScale = Vector3.zero;
        AnswerText.transform.localScale = Vector3.zero;
        RetryText.transform.localScale = Vector3.zero;
        Text.SetActive(false);
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger == true && Input.GetKeyUp(KeyCode.E))
        {
            Panel.transform.DOScale(0.8f, 0.5f);
            Text.SetActive(false);
            controller.PlayerOperation = false;
            Screen.lockCursor = false;
        }
        if (Active.Answer == false)
        {
            Panel.transform.DOScale(0f, 0.5f).OnComplete(Correct);
        }
        if (Active.CorrectAnswer == true)
        {
            AnswerText.text = answer[0];
        }else if(Active.CorrectAnswer == false)
        {
            AnswerText.text = answer[1];
        }
    }

    void Correct()
    {
        AnswerText.transform.DOScale(1f, 0.5f).OnComplete(Correctdelete);
        Active.Answer = true;

        if (Active.CorrectAnswer == false)
        {
            Invoke("ReTryTime", 4f);
        }
    }
    void Correctdelete()
    {
        if (Active.CorrectAnswer == true)
        {
            AnswerText.transform.DOScale(0f, 0.5f).SetDelay(1f);
        }
    }
    void ReTryTime()
    {
        AnswerText.transform.DOScale(0f, 0.5f);
        RetryText.transform.DOScale(1f, 0.5f).OnComplete(RetryDelete);
    }
    void RetryDelete()
    {
        RetryText.transform.DOScale(0f, 0.5f).SetDelay(1f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger = true;
            Text.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger = false;
            Text.SetActive(false);
        }
    }
}
