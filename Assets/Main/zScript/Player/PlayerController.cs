using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動
    private float Mainspeed = 10.0f;//現在のスピード

    private float dashSpeed = 1.5f;//ダッシュ時のスピード
    private float walkSpeed = 10.0f;//歩き時（普通）のスピード
    private float gravity = 15.0f;//重力


    private CharacterController controller;//CharacterController
    private Vector3 vector = Vector3.zero;//プレイヤーの位置

    private float horizontal;//横入力
    private float vertical;//縦入力

    public static bool dash = false; //ダッシュ

    //カメラ
    [Header("カメラ")]
    [SerializeField]
    private GameObject Camera;//カメラオブジェクト取得
    private Transform transform;//カメラの座標（方向を知りたい）

    private float CameraX;//カメラX方向
    private float CameraY;//カメラY方向

    private float cameraRange;//カメラの向きの限界などの管理
    //操作
    [HideInInspector]public bool PlayerOperation = false; //プレイヤーの操作が出来るかどうか（移動関連）

    void Start()
    {
        PlayerOperation = true;　//プレイヤー行動可能に
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        
       
    }
    // Update is called once per frame
    void Update()
    {
        dash = false;//通常は歩きなので
        
        if (PlayerOperation == true) //プレイヤー行動可能状態ならば
        {
            
            /*InputのAxisの前後左右を取る*/
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            /*InputのAxsisのマウスのXYを取る*/
            CameraX = Input.GetAxis("Mouse X");
            CameraY = Input.GetAxis("Mouse Y");

            if (controller.isGrounded)//地面についている時
            {
                Move();//移動
                if (Input.GetKey(KeyCode.LeftShift))//ダッシュ開始boolをtrueに
                {
                    dash = true;
                }
                Dash();//ダッシュ
            }
            vector.y -= gravity * Time.deltaTime;　//重力を掛ける
            controller.Move(vector * Time.deltaTime);//動き
            cameraMove();//カメラの動き
        }
    }
    void Move()//移動
    {
        vector = new Vector3(horizontal, 0, vertical);//座標のXとZにInputのAxisで取った入力情報を入れる
        vector = transform.TransformDirection(vector);//ローカルからワールド座標に変換
        vector *= Mainspeed;//移動スピードを掛ける
    }
    
    void Dash()//ダッシュ
    {
        if (dash == true)
        {
            Mainspeed = walkSpeed * dashSpeed;//移動速度の歩く速度にダッシュ時の変化を加える
        }
        else
        {
            Mainspeed = walkSpeed;//移動速度を普通の移動速度に
        }
    }
    void cameraMove()//カメラ移動
    {
    
        transform.transform.Rotate(0, CameraX, 0);//カメラの向きに入力情報を与える

        /*カメラの向きの限界*/
        cameraRange = Camera.transform.localEulerAngles.x;
        if (cameraRange > 334 && cameraRange < 360 || cameraRange > 0 && cameraRange < 79)
        {
            Camera.transform.Rotate(-CameraY, 0, 0);//カメラの縦向きの動き
            float ca = CameraY;
        }
        else
        {
            if (cameraRange > 300)
            {
                if (CameraY < 0)
                {
                    Camera.transform.Rotate(-CameraY, 0, 0);
                }
            }
            else
            {
                if (CameraY > 0)
                {
                    Camera.transform.Rotate(-CameraY, 0, 0);
                }
            }
        }
    }
}
