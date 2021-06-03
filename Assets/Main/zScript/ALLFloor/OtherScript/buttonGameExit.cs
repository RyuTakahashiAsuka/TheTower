using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonGameExit : MonoBehaviour
{
    public void GameExitButton()/*UIのボタンでの　ゲームの終了*/
    {
        #if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

        
    }
}
