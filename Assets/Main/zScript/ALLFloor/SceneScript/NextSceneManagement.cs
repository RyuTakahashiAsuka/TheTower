using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneManagement : MonoBehaviour
{
    [Header("次シーン名")]
    [SerializeField]
    private string NextSceneName;//次のシーンの名前（Inspector上で編集可能）

    /*シーンのロード*/
    public void NextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    } 
}
