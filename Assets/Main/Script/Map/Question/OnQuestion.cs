using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuestion : MonoBehaviour
{
    [SerializeField]
    private GameObject QuestionPanel;
    [SerializeField]
    private GameObject OnQuestionText;
    public PlayerController controller;
    public Choices choices;


    private bool ON;

    // Start is called before the first frame update
    void Start()
    {
        ON = false;
        QuestionPanel.SetActive(false);
        OnQuestionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (choices.Active == false)
        {
            QuestionPanel.SetActive(false);
        }
        if (ON == true && choices.Answer == true && Input.GetKey(KeyCode.E)) 
        {
            QuestionPanel.SetActive(true);
            controller.PlayerOperation = false;
            choices.Active = true;
        }
        if (choices.Active == true || choices.CorrectAnswer == true)
        {
            OnQuestionText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("接触");
        if (other.tag == "Player")
        {
            ON = true;
            OnQuestionText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            OnQuestionText.SetActive(false);
        }
    }
}
