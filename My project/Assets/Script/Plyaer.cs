using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof())]                      //勝手に入れてくれる奴　コンポーネントし忘れがなくなる

public class Plyaer : MonoBehaviour
{

    //プレイヤー
    [SerializeField] private float acceleration = 100.0f;       //プレイヤーの加速度
    [SerializeField] private float maxSpeed     =  10.0f;        //プレイヤー最大速度
    [SerializeField] private float runMaxSpeed  =  10.0f;        //走り時の最大速度   
    [SerializeField] private float walkMaxSpeed =   5.0f;        //歩き時の最大速度
    private float moveX = 0.0f;                                 //プレイヤーのX軸の速度
    private float moveZ = 0.0f;                                 //プレイヤーのY軸の速度
    [SerializeField] private float jumpPower = 5.0f;           //ジャンプ力
    private bool isGround = false;                             //地面と接地しているか
    Rigidbody rb;


    //カメラ
    [SerializeField] private GameObject cam;                    //カメラ
    Quaternion camRot;                                          //カメラの回転量
    Quaternion charaRot;                                        //キャラクターの回転量
    [SerializeField] private float sensityvity = 1.0f;          //感度
    private float angleMinX = -90.0f;
    private float angleMaxX = 90.0f;

    private bool cursorLock = true;


    //アニメーション
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();                         //rbにRigidbodyの情報を格納
        camRot = cam.transform.localRotation;                 //camRotにcam(カメラ)の回角度を格納
        charaRot = transform.localRotation;                     //charaRotにコンポーネント先(プレイヤー)の回角度を格納
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        DragSwitch();
        CameraControl();
        UpdataCursorLock();
        PlayerAnimation();
    }
    void FixedUpdate()
    {
        if ((rb.velocity.x <= maxSpeed && rb.velocity.x >= -maxSpeed) &&
            (rb.velocity.z <= maxSpeed && rb.velocity.z >= -maxSpeed))
        {
            rb.AddForce(transform.forward * moveZ + transform.right * moveX);
        }
    }

    private void PlayerMove()                                         //プレイヤーの動き
    {
        float x = 0.0f;
        float z = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            z = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.velocity = Vector3.up * jumpPower;
        }

        moveX = x * acceleration;
        moveZ = z * acceleration;
    }

    private void OnCollisionEnter(Collision collision)                //地面との当たり判定
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void DragSwitch()                                         //dragの数値を変える
    {
        if (isGround)
        {
            rb.drag = 10;
        }
        if (!isGround)
        {
            rb.drag = 0.5f;
        }
    }

    private void CameraControl()                                      //カメラ制御
    {
        float rotX = Input.GetAxis("Mouse Y") * sensityvity;          //rotXにY軸中心(左右移動)のマウスの移動量を格納
        float rotY = Input.GetAxis("Mouse X") * sensityvity;          //rotXにX軸中心(上下移動)のマウスの移動量を格納

        camRot *= Quaternion.Euler(-rotX, 0, 0);      //カメラの移動先を決める
        charaRot *= Quaternion.Euler(0, rotY, 0);      //キャラクターの移動先を決める(カメラをキャラクターの傘下に入れているためキャラクターの向きを変えればカメラの向きも変わる)

        camRot = ClampRotation(camRot);

        cam.transform.localRotation = camRot;           //決めた移動先に実際に動かす
        transform.localRotation = charaRot;         //決めた移動先に実際に動かす
    }

    private void UpdataCursorLock()                                   //マウスカーソルを消したりつけたり
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private Quaternion ClampRotation(Quaternion q)                    //カメラ移動制限
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX, angleMinX, angleMaxX);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }                

    private void PlayerAnimation()
    {
        
        //歩き
        if (moveX != 0 || moveZ != 0)
        {
            if (!animator.GetBool("Walk"))
            {
                animator.SetBool("Walk", true);
                maxSpeed = walkMaxSpeed;
            }
        }
        else if (animator.GetBool("Walk"))
        {
            animator.SetBool("Walk", false);
        }
        
        //走り
        if (moveZ > 0 && Input.GetKey(KeyCode.LeftShift)) 
        {
            if (!animator.GetBool("Run"))
            {
                animator.SetBool("Run", true);
                maxSpeed = runMaxSpeed;
            }
        }
        else if (animator.GetBool("Run"))
        {
            animator.SetBool("Run", false);
            maxSpeed = walkMaxSpeed;
        }

    }
}

