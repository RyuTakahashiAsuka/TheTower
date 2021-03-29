using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TrickDoor : MonoBehaviour
{
    public FirstButton OnfirstButton;
    public SecondButton OnsecondButton;
    public ThirdButton OnthirdButton;

    public FadeMoveTextAnimation MoveLaterText;
    public bool Move=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Move == true)
        {
            MoveDoor();
            Move = false;
        }
    }
    void MoveDoor()
    {
        this.transform.DOMove(new Vector3(5f, 0, 0), 3f).SetRelative(true);
        MoveLaterText.Animation = true;
    }
}
