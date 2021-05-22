using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FirstTask;

public class fireballtwo : MonoBehaviour
{
    private bool Trigger = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger == true && Input.GetKeyUp(KeyCode.E))
        {
            fireballTwo = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger = false;
        }
    }
}
