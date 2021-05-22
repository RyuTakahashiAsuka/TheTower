using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstButton : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonNearText;
    public FadeMoveTextAnimation MoveTextAnimation;

    public bool OnFirstButton = false;

    private bool NearButton = false;
    // Start is called before the first frame update
    void Start()
    {
        ButtonNearText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(NearButton == true && Input.GetKey(KeyCode.E))
        {
            if (!OnFirstButton)
            {
                OnFirstButton = true;
                this.transform.DOMove(new Vector3(0.2f, 0f, 0f), 1f)
                    .SetRelative(true)
                    .OnComplete(OnButton);
                
            }
        }
    }

    void OnButton()
    {
        MoveTextAnimation.Animation = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (OnFirstButton == false)
        {
            if (other.tag == "Player")
            {
                ButtonNearText.SetActive(true);
                NearButton = true;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ButtonNearText.SetActive(false);
            NearButton = false;
        }
    }
}
