using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ThirdButton : MonoBehaviour
{
    [SerializeField]
    private GameObject NearButtonText;

    public FadeMoveTextAnimation ErrorMoveTextAnimation;
   

    public FirstButton OnFirstButton;
    public SecondButton OnSecondButton;
    public TrickDoor Move;

    public bool OnThirdButton = false;

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
            if (OnFirstButton.OnFirstButton == true&& OnSecondButton.OnSecondButton == true)
            {
                this.transform.DOMove(new Vector3(0f, 0f, 0.2f), 1f)
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
        OnThirdButton = true;
        Move.Move = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            NearButtonText.SetActive(true);
            NearButton = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            NearButtonText.SetActive(false);
            NearButton = false;
        }
    }
}
