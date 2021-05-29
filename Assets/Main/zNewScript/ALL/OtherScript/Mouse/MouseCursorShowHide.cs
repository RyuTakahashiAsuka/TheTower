using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorShowHide : MonoBehaviour
{
    [SerializeField]
    public bool CursorShow;//マウスの表示非表示用判定   クイズの回答時など条件でOnにする場合があるのでPublicで作成

    // Update is called once per frame
    void Update()
    {
        if (CursorShow == true)
        {
            Cursor.visible = true;//マウスカーソルを表示設定にする
        }
        else
        {
            Cursor.visible = false;//マウスカーソルを非表示設定にする
        }
    }
}
