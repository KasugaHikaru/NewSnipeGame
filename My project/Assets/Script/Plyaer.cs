using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof())]                      //����ɓ���Ă����z�@�R���|�[�l���g���Y�ꂪ�Ȃ��Ȃ�

public class Plyaer : MonoBehaviour
{

    //�v���C���[
    [SerializeField] private float acceleration = 100.0f;       //�v���C���[�̉����x
    [SerializeField] private float maxSpeed     =  10.0f;        //�v���C���[�ő呬�x
    [SerializeField] private float runMaxSpeed  =  10.0f;        //���莞�̍ő呬�x   
    [SerializeField] private float walkMaxSpeed =   5.0f;        //�������̍ő呬�x
    private float moveX = 0.0f;                                 //�v���C���[��X���̑��x
    private float moveZ = 0.0f;                                 //�v���C���[��Y���̑��x
    [SerializeField] private float jumpPower = 5.0f;           //�W�����v��
    private bool isGround = false;                             //�n�ʂƐڒn���Ă��邩
    Rigidbody rb;


    //�J����
    [SerializeField] private GameObject cam;                    //�J����
    Quaternion camRot;                                          //�J�����̉�]��
    Quaternion charaRot;                                        //�L�����N�^�[�̉�]��
    [SerializeField] private float sensityvity = 1.0f;          //���x
    private float angleMinX = -90.0f;
    private float angleMaxX = 90.0f;

    private bool cursorLock = true;


    //�A�j���[�V����
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();                         //rb��Rigidbody�̏����i�[
        camRot = cam.transform.localRotation;                 //camRot��cam(�J����)�̉�p�x���i�[
        charaRot = transform.localRotation;                     //charaRot�ɃR���|�[�l���g��(�v���C���[)�̉�p�x���i�[
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

    private void PlayerMove()                                         //�v���C���[�̓���
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

    private void OnCollisionEnter(Collision collision)                //�n�ʂƂ̓����蔻��
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void DragSwitch()                                         //drag�̐��l��ς���
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

    private void CameraControl()                                      //�J��������
    {
        float rotX = Input.GetAxis("Mouse Y") * sensityvity;          //rotX��Y�����S(���E�ړ�)�̃}�E�X�̈ړ��ʂ��i�[
        float rotY = Input.GetAxis("Mouse X") * sensityvity;          //rotX��X�����S(�㉺�ړ�)�̃}�E�X�̈ړ��ʂ��i�[

        camRot *= Quaternion.Euler(-rotX, 0, 0);      //�J�����̈ړ�������߂�
        charaRot *= Quaternion.Euler(0, rotY, 0);      //�L�����N�^�[�̈ړ�������߂�(�J�������L�����N�^�[�̎P���ɓ���Ă��邽�߃L�����N�^�[�̌�����ς���΃J�����̌������ς��)

        camRot = ClampRotation(camRot);

        cam.transform.localRotation = camRot;           //���߂��ړ���Ɏ��ۂɓ�����
        transform.localRotation = charaRot;         //���߂��ړ���Ɏ��ۂɓ�����
    }

    private void UpdataCursorLock()                                   //�}�E�X�J�[�\�����������������
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

    private Quaternion ClampRotation(Quaternion q)                    //�J�����ړ�����
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
        
        //����
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
        
        //����
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

