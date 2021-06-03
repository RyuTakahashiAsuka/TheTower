using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerPanelOpen : MonoBehaviour
{
    [Header("UI類")]
    [SerializeField] private GameObject ViewPanel;//表示するパネル
    [SerializeField] private GameObject NearText;//プレイヤーが当たり判定に当たった時に表示するテキスト

    [Header("Script類")]
    //パネル表示時にプレイヤーの動きを制限する為にPlayerController取得
    [SerializeField] private PlayerController playerController;
    //ゲーム中はカーソル非表示にパネル表示時は表示にする為MouseCursorShowHide取得
    [SerializeField] private MouseCursorShowHide Cursorshowhide;

    private bool Trigger = false; //プレイヤーがClider内に入っているかの判定

    // Start is called before the first frame update
    void Start()
    {
        ViewPanel.transform.localScale = Vector3.zero;//パネルの初期Scale値は0
        NearText.SetActive(false);//テキストの表示をなくす
    }

    // Update is called once per frame
    void Update()
    {
        if(Trigger == true && Input.GetKeyUp(KeyCode.E))//プレイヤーが当たり判定内にいる状態でキーボードのEキーを押す
        {
            ViewPanel.transform.DOScale(0.8f, 1f);//パネルの表示
            NearText.SetActive(false);//テキストの表示をなくす
            playerController.PlayerOperation = false;//プレイヤーの動きを制限
            Cursorshowhide.CursorShow = true;//マウスカーソルを表示
        }
    }

    public void OnclickBackButton()　//パネルの閉じるボタンを押した場合
    {
        ViewPanel.transform.DOScale(0f, 0.7f);　//パネルを閉じる（開くときよりも速く）
        Trigger = false;　//トリガーをfalseに
        playerController.PlayerOperation = true;　//プレイヤーの動きを可能に
        Cursorshowhide.CursorShow = false;　//マウスカーソルを非表示に
    }

    void OnTriggerEnter(Collider other)//プレイヤーが当たっている場合
    {
        if(other.tag == "Player")
        {
            Trigger = true;　//当たっている判定に
            NearText.SetActive(true);　//当たっているテキストを表示
        }
    }

    void OnTriggerExit(Collider other)　//プレイヤーが当たっていないとき
    {
        if(other.tag == "Player")
        {
            Trigger = false;　//当たっていない判定に
            NearText.SetActive(false);　//当たっているテキストを非表示
        }
    }
}
