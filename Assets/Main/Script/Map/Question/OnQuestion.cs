using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuestion : MonoBehaviour
{
    [SerializeField]
    private GameObject QuestionPanel;

    public PlayerController controller;

    public Choices choices;

    private bool ON;

    // Start is called before the first frame update
    void Start()
    {
        ON = false;
        QuestionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (choices.Active == false)
        {
            QuestionPanel.SetActive(false);
        }
        if (ON == true&&Input.GetKey(KeyCode.E))
        {
            QuestionPanel.SetActive(true);
            controller.PlayerOperation = false;
            choices.Active = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("接触");
        if (other.tag == "Player")
        {
            ON = true;
        }
    }
}
