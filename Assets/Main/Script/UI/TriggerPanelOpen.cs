using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerPanelOpen : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject Text;
    public PlayerController controller;


    bool Trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        Panel.transform.localScale = Vector3.zero;
        Text.SetActive(false);
        Screen.lockCursor=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Trigger == true && Input.GetKeyUp(KeyCode.E))
        {
            Panel.transform.DOScale(0.8f, 1f);
            Text.SetActive(false);
            controller.PlayerOperation = false;
            Screen.lockCursor=false;
        }
    }

    public void OnclickBackButton()
    {
        Panel.transform.DOScale(0f, 1f);
        Trigger = false;
        controller.PlayerOperation = true;
        Screen.lockCursor = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Trigger = true;
            Text.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Trigger = false;
            Text.SetActive(false);
        }
    }
}
