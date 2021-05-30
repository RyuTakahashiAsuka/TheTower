using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*追加*/
using DG.Tweening;
using TMPro;


public class TrickButton : MonoBehaviour
{
    [Header("数値類")]
    [SerializeField] private int Trick_Num = 1;//仕掛けの順番番号
    [Tooltip("1=Z方向、2=-Z方向、3=X方向、4=-X方向")]
    [SerializeField] private int MoveDirectionNum = 1;//本がアニメーションする方向を4までの数字で決定
    [Header("UI類")]
    [SerializeField] private GameObject NearText;//プレイヤーが当たり判定に当たった時に表示するテキスト
    [SerializeField] private TextMeshProUGUI MoveText;//仕掛けを動かした時にフェードさせるテキスト
    [Header("オブジェクト類")]
    [SerializeField] private GameObject DoorBookCase;//仕掛けクリア後に動かす扉
    [Header("スクリプト類")]
    [SerializeField] private TrickManager trickManager;//マネージャー参照
    [SerializeField] private NextTask nextTask;//現在のタスクのナンバーを取り、変更
    [SerializeField] private FadeMoveTextAnimation AnimationTextScript;//MoveTextについているスクリプト（アニメーション開始の判定用）
    

    private string[] TaskText = { "まだ他に仕掛けがあるようだ", "扉が開いたようだ" };//仕掛けを動かした時のテキスト
    private bool Ontrigger = false;//当たり判定

    private Vector3 ButtonMoveDistance;
    private BoxCollider boxcollider;//仕掛けの本の当たり判定
    // Start is called before the first frame update
    void Start()
    {
        NearText.SetActive(false);
        boxcollider = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (MoveDirectionNum) //ボタンのアニメーションの方向をinspector上で数値で変更しボタンの向きを変えた時に楽に
        {
            case 1:
                ButtonMoveDistance = new Vector3(0, 0, 0.2f);
                break;
            case 2:
                ButtonMoveDistance = new Vector3(0, 0, -0.2f);
                break;
            case 3:
                ButtonMoveDistance = new Vector3(0.2f, 0, 0);
                break;
            case 4:
                ButtonMoveDistance = new Vector3(-0.2f, 0, 0);
                break;
            default:
                Debug.LogError("1～4の数字を入れていください");
                break;
        }
        TextUpdate();
        if (Trick_Num == trickManager.nowTrick_Num)//今現在の仕掛けクリア数と現在動かす仕掛けの番号が一緒なら動かせる
        {
            if (Ontrigger == true && Input.GetKey(KeyCode.E))//当たり判定に入ってる状態でEキーを押す
            {
                NearText.SetActive(false);
                ButtonAnimation();
                ClearTrick();
                boxcollider.enabled = false;//一度クリアした仕掛けは再び触れない様にする
                if (trickManager.nowTrick_Num == trickManager.Trick_MaxNum + 1)//全仕掛けを解いた時は扉が開くテキストを
                {
                    DoorAnimation();
                }
            }
        }
    }
        void TextUpdate()//テキストの更新
        {
            if (trickManager.nowTrick_Num == trickManager.Trick_MaxNum + 1)//全仕掛けを解いた時は扉が開くテキストを
            {
                MoveText.text = TaskText[1];
            }
            else//まだ仕掛けがある場合はそのテキストを
            {
                MoveText.text = TaskText[0];
            }
        }

        void ButtonAnimation()//ボタンのアニメーション
        {
            this.transform.DOMove(ButtonMoveDistance, 1).SetRelative(true);
        }
        void DoorAnimation()
        {
            DoorBookCase.transform.DOMove(new Vector3(5f, 0, 0), 3f).SetRelative(true);
           //現在位置から3秒間でX方向に５動かす
        }


        void ClearTrick()//仕掛けクリアしたよの判定
        {
            trickManager.nowTrick_Num = trickManager.nowTrick_Num + 1;//現在のクリア数に＋１する
            nextTask.TaskNumCount = nextTask.TaskNumCount + 1;//現在のタスクに＋１する
            AnimationTextScript.AnimationStart = true;//仕掛けを解いた時のテキストアニメーションをスタートさせる
        }
        private void OnTriggerEnter(Collider other)//当たり判定に入ったとき
        {
            if (other.tag == "Player")
            {
                Ontrigger = true;
                NearText.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)//当たり判定を抜けた時
        {
            if (other.tag == "Player")
            {
                Ontrigger = false;
                NearText.SetActive(false);
            }
        }
    
}
