using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pouse : MonoBehaviour
{
    [SerializeField]
    public GameObject PousePanel;

    void Start()
    {
        PousePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PousePanel.SetActive(true);
            Time.timeScale = 0f;
            Screen.lockCursor = false;
        }
    }

    public void ReStartButton()
    {
        PousePanel.SetActive(false);
        Time.timeScale = 1f;
        Screen.lockCursor = true;
    }
}
