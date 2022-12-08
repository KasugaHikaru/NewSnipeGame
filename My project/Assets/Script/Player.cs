using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    Quaternion charaRot;
    Rigidbody rb;

    [SerializeField] private int   maxHp;
                     private int   hp;
    [SerializeField] private float speed;
    [SerializeField] private float sensityvity;
    [SerializeField] private float jumpPower;
    private bool isGround;
    private bool isDead;

    [SerializeField] private GameObject cam;
    Quaternion camRot;
    private float angleMinX = -90.0f;
    private float angleMaxX =  70.0f;
    private bool cursorLock = false;

    private Wepon wepon;


    void Start()
    {
        Init();
    }

    void Update()
    {
        Debug.Log(hp);
        if (!isDead)
        {
            PlayerCtrl();
            CamCtrl();
            UpdataCursorLock();
        }
    }

    public void Init()
    {
        hp = maxHp;
        rb = GetComponent<Rigidbody>();
        wepon= GetComponent<Wepon>();
        camRot = cam.transform.localRotation;
        charaRot = transform.localRotation;
        isGround = false;
        isDead   = false;
    }

    public void PlayerCtrl()
    {
        //移動
        Vector3 move = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            move.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += 1;
        }

        transform.position += ((transform.forward * move.z) + (transform.right * move.x)) * speed * Time.deltaTime;

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.velocity = Vector3.up * jumpPower;
        }

        //射撃


        wepon.WeponCtlr(); 
    }


    public void CamCtrl()
    {
        float rotX = Input.GetAxis("Mouse X") * sensityvity;
        float rotY = Input.GetAxis("Mouse Y") * sensityvity;

        camRot *= Quaternion.Euler(-rotY, 0, 0);
        charaRot *= Quaternion.Euler(0, rotX, 0);

        camRot = ClampRotation(camRot);

        cam.transform.localRotation = camRot;
        transform.localRotation = charaRot;
    }


    private void OnCollisionEnter(Collision collision)                //地面との当たり判定
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
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

    public void Damage(int value)
    {

        if (value <= 0)
        {
            return;
        }

        hp -= value;

        if (hp <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        isDead = true;
        GetComponent<CapsuleCollider>().enabled = false;
        //Destroy(this.gameObject);
    }


}
