using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class TitleNextScene : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private CanvasGroup canvasGroupe;
    
    private void Start()
    {
        Panel.SetActive(false);
    }

    // Start is called before the first frame update
    public void Onclick()
    {
        Panel.SetActive(true);
        canvasGroupe.DOFade(1,3f).SetDelay(1.0f).OnComplete(FadeComplete);

    }

   void FadeComplete()
    {
        Debug.Log("完了");
        SceneManager.LoadScene("PrologueScene");
    }
}
