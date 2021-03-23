using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class FadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public bool fadeStart = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0);
       
    }
    // Update is called once per frame
    void Update()
    {
        if (fadeStart == true)
        {
            fadeOut();
        }
    }
    void fadeOut()
    {
        canvasGroup.DOFade(1, 3f);
    }
}
