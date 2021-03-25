using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    public GameObject FadePanel;
    [SerializeField]
    public CanvasGroup canvasGroup;
    void Start()
    {
        FadePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.DOFade(0, 2f).OnComplete(FadeComplete);
    }

    void FadeComplete()
    {
        FadePanel.SetActive(false);
    }
}
