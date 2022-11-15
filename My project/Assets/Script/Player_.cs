using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ : MonoBehaviour
{ 
    Quaternion charaRot;
    Rigidbody rb;
    [SerializeField] private float speed=2f;
    [SerializeField] private float sensityvity = 1.0f;
    [SerializeField] private float jumpPower = 1.0f;
    private bool isGround;
 

   //[SerializeField] private GameObject[] wepon;
   //private int weponNumber;
   //private int nowWeponNumber;
   //[SerializeField] private Transform equipTransform;
    


    [SerializeField] private GameObject cam;
    Quaternion camRot;
    private float angleMinX = -90.0f;
    private float angleMaxX =  70.0f;


    private bool cursorLock = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        PlayerCtrl();
        CamCtrl();
        UpdataCursorLock();
    }

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        camRot = cam.transform.localRotation;
        charaRot = transform.localRotation;
        isGround = false;
       // weponNumber = 1;
       // nowWeponNumber = 0;
       // ChangeWepon(weponNumber);
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

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.velocity = Vector3.up * jumpPower;
        }

        transform.position += ((transform.forward * move.z) + (transform.right * move.x)) * speed * Time.deltaTime;


        //武器チェン
       // if (Input.GetKeyDown("1"))
       // {
       //     weponNumber = 1;
       //     ChangeWepon(weponNumber);
       // }
       // if (Input.GetKeyDown("2"))
       // {
       //     weponNumber = 2;
       //     ChangeWepon(weponNumber);
       // }
    }


  // public void ChangeWepon(int valu)
  // {
  //     if (nowWeponNumber!=0)
  //     {
  //         Destroy(equipTransform.GetChild(0).gameObject);
  //     }
  //
  //     GameObject NowWepon;
  //     NowWepon = Instantiate(wepon[valu], equipTransform.transform.position, equipTransform.transform.rotation, equipTransform);
  //     nowWeponNumber = valu;
  //     
  // }

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
}
