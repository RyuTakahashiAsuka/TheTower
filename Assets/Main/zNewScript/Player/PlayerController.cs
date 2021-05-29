using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動
    [SerializeField]
    private float Mainspeed = 10.0f;//現在のスピード
    private float dashSpeed = 1.5f;//ダッシュ時のスピード
    private float walkSpeed = 10.0f;//歩き時（普通）のスピード
    private float gravity = 15.0f;//重力


    private CharacterController controller;//CharacterController
    private Vector3 vector = Vector3.zero;//プレイヤーの位置

    private float horizontal;//横入力
    private float vertical;//縦入力

    
    public static bool MoveOn = false;
    public static bool dash = false; //ダッシュ

    //カメラ
    [SerializeField]
    public GameObject Camera;//カメラオブジェクト取得
    private Transform transform;

    private float CameraX;
    private float CameraY;

    private float cameraRange;
    //操作
    public bool PlayerOperation = false; //プレイヤーの操作が出来るかどうか（移動関連）

    void Start()
    {
        PlayerOperation = true;
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        
       
    }
    // Update is called once per frame
    void Update()
    {
        dash = false;
        
        if (PlayerOperation == true) {
            
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            CameraX = Input.GetAxis("Mouse X");
            CameraY = Input.GetAxis("Mouse Y");
            if (controller.isGrounded)
            {
                Move();
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    dash = true;
                }
                
                Dash();
            }
            vector.y -= gravity * Time.deltaTime;
            controller.Move(vector * Time.deltaTime);
            cameraMove();
        }
    }
    void Move()
    {
        vector = new Vector3(horizontal, 0, vertical);
        vector = transform.TransformDirection(vector);
        vector *= Mainspeed;
    }
    
    void Dash()//ダッシュ
    {
        if (dash == true)
        {
            Mainspeed = walkSpeed * dashSpeed;
        }
        else
        {
            Mainspeed = walkSpeed;
        }
    }
    void cameraMove()//カメラ移動
    {
    
        transform.transform.Rotate(0, CameraX, 0);

        cameraRange = Camera.transform.localEulerAngles.x;
        if (cameraRange > 334 && cameraRange < 360 || cameraRange > 0 && cameraRange < 79)
        {
        Camera.transform.Rotate(-CameraY, 0, 0);
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
