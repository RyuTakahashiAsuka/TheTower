using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcedTermination : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        /*ゲームの強制終了コマンド　エスケープキー*/
        if (Input.GetKey(KeyCode.Escape))
        {

            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit();
            #endif
        }
    }
}
