using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneManagement : MonoBehaviour
{
    [SerializeField]
    //次のシーンの名前（Inspector上で編集可能）
    private string NextSceneName;

    /*シーンのロード*/
    public void NextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    } 
}
