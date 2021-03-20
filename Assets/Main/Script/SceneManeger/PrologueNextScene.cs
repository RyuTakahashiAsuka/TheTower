using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PrologueNextScene : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private CanvasGroup canvasGroupe;

    private void Start()
    {
        Panel.SetActive(true);
    }

    // Start is called before the first frame update
    public void Onclick()
    {
        
        canvasGroupe.DOFade(1, 3f).OnComplete(FadeComplete);

    }

    void FadeComplete()
    {
        Debug.Log("完了");
        SceneManager.LoadScene("FirstFloor");
    }
}
