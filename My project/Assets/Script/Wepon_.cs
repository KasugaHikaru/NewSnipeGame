using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon_ : MonoBehaviour
{
    [SerializeField] private GameObject[] wepon;
    [SerializeField] private Transform equipTransform;

    private WeponStatus weponStatus;

    private float  shootRateNum = 0.0f;                      //���˃��[�g�m�F�p�̕ϐ�   
    private int[]  clipAmmo= { -1,-1,-1};                    //�}�K�W�����̒e��
    private bool   canShoot;

    private GameObject muzzle;
    GameObject NowWepon;
    private int weponNumber;
    private int nowWeponNumber;

    private GameObject bulletPrefab;
    private int   damage;
    private float bulletSpeed;
    private float shootRate;
    private int   maxClipAmmo;
    private bool  shootType;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        WeponCtlr();
    }

    public void Init()
    {
        weponNumber = 1;
        nowWeponNumber = 0;
        canShoot = true;
        ChangeWepon(weponNumber);
    }


    public void WeponCtlr()
    {
        //�ˌ�
        if(!shootType)                   //�P��
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                Shoot();
            }
        }
        else if (shootType)              //�A��
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                Shoot();
            }
        }

        //�����[�h
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        //����`�F��
        if (Input.GetKeyDown("1"))
        {
            weponNumber = 1;
            ChangeWepon(weponNumber);
        }
        if (Input.GetKeyDown("2"))
        {
            weponNumber = 2;
            ChangeWepon(weponNumber);
        }

        //�t���O�Ǘ�
        CanShoot();
    }

    public void Shoot()
    {
        //�e�̐���
        GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);


        //�e�̕����A�x�N�g��
        Vector3 force;
        force = NowWepon.transform.forward * bulletSpeed;
        bullet.GetComponent<Rigidbody>().AddForce(force);

        //�e�A�t���O�Ȃǂ̌㏈��
        Destroy(bullet, 3.0f);
        canShoot = false;
        shootRateNum = 0;
        clipAmmo[weponNumber]--;
    }

    public void Reload()
    {
        clipAmmo[nowWeponNumber] = maxClipAmmo;
    }

    public void ChangeWepon(int valu)
    {
        //���ɂ��镐�������
        if (nowWeponNumber != 0)
        {
            Destroy(equipTransform.GetChild(0).gameObject);
        }

        //����̐���
        NowWepon = Instantiate(wepon[valu], equipTransform.transform.position, equipTransform.transform.rotation, equipTransform);
        nowWeponNumber = valu;
        weponStatus = wepon[valu].GetComponent<WeponStatus>();      //WeponStatus�N���X���畐��X�e�[�^�X�̏����擾

        ChangeWeponInit();


    }

    public void ChangeWeponInit()
    {
        bulletPrefab = weponStatus.get_bulletPrefab();
        damage       = weponStatus.get_damage();
        bulletSpeed  = weponStatus.get_bulletSpeed();
        shootRate    = weponStatus.get_shootRate();
        maxClipAmmo  = weponStatus.get_maxClipAmmo();
        shootType    = weponStatus.get_shootType();

        muzzle = NowWepon.transform.Find("MuzzlePosi").gameObject;
        shootRateNum = shootRate;

        if (clipAmmo[nowWeponNumber] == -1)
        {
            clipAmmo[nowWeponNumber] = maxClipAmmo;
        }

    }

    public void CanShoot()
    {
        //�ˌ����[�g,canShot�Ǘ�
        if (shootRateNum < shootRate)
        {
            shootRateNum++;
        }

        if (shootRateNum == shootRate && clipAmmo[nowWeponNumber] > 0)
        {    
             canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }

    public int get_damage()
    {
        return damage;
    }

}
