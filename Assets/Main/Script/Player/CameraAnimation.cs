using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static PlayerController;


public class CameraAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveOn == true)
        {
            
            if(dash == true)
            {
                Camera.transform.DOMoveY(1.5f, 0.5f).Loops();
            }
            else
            {
                Camera.transform.DOMoveY(1.5f, 1).Loops();   
            }
        }
    }
}
