using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class OnQuestion : MonoBehaviour
{
    [SerializeField]
    private GameObject QuestionPanel;
    [SerializeField]
    private GameObject OnQuestionTrigger;
    public PlayerController PlayerController;
    public Choices Choice;

    public TextMeshProUGUI AnswerText;
    public TextMeshProUGUI RetryText;
    public string[] answer = new string[2];

    bool Trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        QuestionPanel.transform.localScale = Vector3.zero;
        AnswerText.transform.localScale = Vector3.zero;
        RetryText.transform.localScale = Vector3.zero;
        OnQuestionTrigger.SetActive(false);
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger == true && Input.GetKeyUp(KeyCode.E))
        {
            QuestionPanel.transform.DOScale(0.8f, 0.5f);
            OnQuestionTrigger.SetActive(false);
            PlayerController.PlayerOperation = false;
            Screen.lockCursor = false;
        }
        if (Choice.Answer == false)
        {
            QuestionPanel.transform.DOScale(0f, 0.5f).OnComplete(Correct);
        }
        if (Choice.CorrectAnswer == true)
        {
            AnswerText.text = answer[0];
        }else if(Choice.CorrectAnswer == false)
        {
            AnswerText.text = answer[1];
        }
    }

    void Correct()
    {
        AnswerText.transform.DOScale(1f, 0.5f).OnComplete(Correctdelete);
        Choice.Answer = true;

        if (Choice.CorrectAnswer == false)
        {
            Invoke("ReTryTime", 4f);
        }
    }
    void Correctdelete()
    {
        if (Choice.CorrectAnswer == true)
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
            OnQuestionTrigger.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger = false;
            OnQuestionTrigger.SetActive(false);
        }
    }
}
