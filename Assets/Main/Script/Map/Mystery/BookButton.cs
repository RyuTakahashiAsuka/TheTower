using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class BookButton : MonoBehaviour
{
    [SerializeField]
    public GameObject ButtonNeartext;
    public GameObject BookCase;
    public GameObject TextMove;
    

    private bool NearBookBuuton = false;
    private bool ButtonOnOff = false;

    // Start is called before the first frame update
    void Start()
    {
        NearBookBuuton = false;
        ButtonOnOff = false;
        TextMove.SetActive(false);
        ButtonNeartext.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ButtonMain();
    }

    void ButtonMain()
    {
        if(NearBookBuuton == true && Input.GetKey(KeyCode.E))
        {
            if (!ButtonOnOff) 
            {
                this.transform.DOMove(new Vector3(0, 0, 0.2f), 1).SetRelative(true).OnComplete(BookCaseMove);
                Debug.Log("Open the door");
                ButtonOnOff = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ButtonNeartext.SetActive(true);
            NearBookBuuton = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ButtonNeartext.SetActive(false);
            NearBookBuuton = false;
        }
    }

    void BookCaseMove()
    {
        BookCase.transform.DOMove(new Vector3(5f, 0, 0), 3f).SetRelative(true).OnComplete(StartAnimation);
    }
    void StartAnimation(){
        TextMove.SetActive(true);
    }
    private IEnumerator waitTime(float WaitTime,Action action)
    {
        yield return new WaitForSeconds(WaitTime);
        action();
    }
    
}
