using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pouse : MonoBehaviour
{
    [Header("UI類")]
    [SerializeField]
    private GameObject PousePanel;//ポーズした際に表示するパネル

    [Header("スクリプト類")]
    //パネル表示時にプレイヤーの動きを制限する為にPlayerController取得
    [SerializeField] private PlayerController playerController;
    //ゲーム中はカーソル非表示にパネル表示時は表示にする為MouseCursorShowHide取得
    [SerializeField]private MouseCursorShowHide Cursorshowhide;
    
    void Start()
    {
        PousePanel.SetActive(false);//パネルを非表示に
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))//Qキーで
        {
            PousePanel.SetActive(true);//パネルを表示
            Time.timeScale = 0f;//タイムスケールを0に
            Cursorshowhide.CursorShow = true;//マウスカーソルを表示に
            playerController.PlayerOperation = false;//プレイヤーの動きを制限
        }
    }

    public void ReStartButton()//再スタートボタン
    {
        PousePanel.SetActive(false);//パネル非表示
        Time.timeScale = 1f;//タイムスケールを1に
        Cursorshowhide.CursorShow = false;//カーソルを非表示に
        playerController.PlayerOperation = true;//プレイヤーが動けるように
    }
}
