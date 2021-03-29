using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SecondButton : MonoBehaviour
{
    [SerializeField]
    private GameObject NearButtonText;
    public FadeMoveTextAnimation ErrorMoveTextAnimation;
    public FadeMoveTextAnimation SuccessMoveTextAnimation;
    public FirstButton OnFirstButton;
    public bool OnSecondButton = false;


    private bool NearButton = false;


    // Start is called before the first frame update
    void Start()
    {
        NearButtonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(NearButton == true && Input.GetKey(KeyCode.E))
        {
            if(OnFirstButton.OnFirstButton == true)
            {
                this.transform.DOMove(new Vector3(0.2f, 0f, 0f), 1f)
                    .SetRelative(true)
                    .OnComplete(OnButton);
            }
            else
            {
                ErrorMoveTextAnimation.Animation = true;
            }
        }
    }
    void OnButton()
    {
        OnSecondButton = true;
        SuccessMoveTextAnimation.Animation = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            NearButton = true;
            NearButtonText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            NearButton = false;
            NearButtonText.SetActive(false);
        }
    }
}
