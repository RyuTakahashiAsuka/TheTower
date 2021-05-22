using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ClearTime;
using static ClearTimeText;


public class forthFloorNextScene : MonoBehaviour
{
    [SerializeField]
    public GameObject FadePanel;
    public PlayerController controller;
    public FadeOut fade;
    public Choices Answer;
    private void Start()
    {
        FadePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Answer.CorrectAnswer == true)
        {
            Debug.Log("接触");
            FadePanel.SetActive(true);
            StartCount = false;
            third = (int)oldSeconds;
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
        SceneManager.LoadScene("FifthFloor");
    }

    private IEnumerator waitTime(float WaitTime, Action action)
    {
        yield return new WaitForSeconds(WaitTime);
        action();
    }

}
