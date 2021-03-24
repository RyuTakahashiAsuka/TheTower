using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class FirstFloorNextFloor : MonoBehaviour
{
    [SerializeField]
    public GameObject FadePanel;
    public PlayerController controller;
    public FadeOut fade;
    private void Start()
    {
        FadePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("接触");
            FadePanel.SetActive(true);
            controller.PlayerOperation = false;
            fade.fadeStart = true;
            StartCoroutine(waitTime(4.0f, () =>
            {
                Debug.Log("次のシーンへ");
                GoNextScene();
            }));
        }
    }

    void GoNextScene()
    {
        SceneManager.LoadScene("SecondFloor");
    }

    private IEnumerator waitTime(float WaitTime, Action action)
    {
        yield return new WaitForSeconds(WaitTime);
        action();
    }

}
