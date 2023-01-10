using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] Camera cam;
    private float defaultFOV;
    private float[] zoomFOV;

    [SerializeField] private GameObject[] weponPrehub = new GameObject[sub + 1];
    [SerializeField] private GameObject[] wepon = new GameObject[sub + 1];
    [SerializeField] private Transform equipTransform;

    private WeponStatus[] weponStatus;

    private float  shootRateNum = 0.0f;                      //���˃��[�g�m�F�p�̕ϐ�   
    private int[]  clipAmmo;                                 //�}�K�W�����̒e��
    private bool   canShoot;

    private GameObject[] muzzle;
    private int weponNumber;

    private GameObject[] bulletPrefab;
    private float[]      bulletSpeed;
    private float[]      rate;
    private int[]        magazineSize;
    private bool[]       shootType;
    private float        zoomSpeed;

    private const int main = 0;
    private const int sub  = 1;

    // Start is called before the first frame update
    //void Start()
    //{
    //    Init();
    //}

    private void Update()
    {
        WeponCtlr();
    }

    public void Init()
    {
        zoomSpeed = 0.1f;
        weponNumber = main;
        canShoot = true;
        defaultFOV = cam.fieldOfView;
        InstantiateWepon();
        WeponInit(main);
        WeponInit(sub);
    }


    public void WeponCtlr()
    {
        //�ˌ�
        if(!shootType[weponNumber])                   //�P��
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        else if (shootType[weponNumber])              //�A��
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }

        //ADS
        ADS();
        

        //�����[�h
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        //����`�F��
        if (Input.GetKeyDown("1"))
        {
            weponNumber = main;
            ChangeWepon(weponNumber);
        }
        if (Input.GetKeyDown("2"))
        {
            weponNumber = sub;
            ChangeWepon(weponNumber);
        }

        //�t���O�Ǘ�
        CanShoot();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            //�e�̐���
            GameObject bullet = Instantiate(bulletPrefab[weponNumber], muzzle[weponNumber].transform.position, muzzle[weponNumber].transform.rotation);

            //�e�̕����A�x�N�g��
            Vector3 force;
            force = wepon[weponNumber].transform.forward * bulletSpeed[weponNumber];
            bullet.GetComponent<Rigidbody>().AddForce(force);

            //�e�A�t���O�Ȃǂ̌㏈��
            Destroy(bullet, 3.0f);
            canShoot = false;
            shootRateNum = 0;
            clipAmmo[weponNumber]--;
        }
    }

    public void ADS()
    {
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomFOV[weponNumber], Time.deltaTime / zoomSpeed);
        }
        if (!Input.GetMouseButton(1))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultFOV, Time.deltaTime / zoomSpeed);
        }
    }

    public void Reload()
    {
        clipAmmo[weponNumber] = magazineSize[weponNumber];
    }

    public void ChangeWepon(int value)
    {
        if (value == main)
        {
            wepon[main].SetActive(true);
            wepon[sub].SetActive(false);
        }
        if (value == sub)
        {
            wepon[main].SetActive(false);
            wepon[sub].SetActive(true);
        }
    }

    public void WeponInit(int value)
    {
        weponStatus[value]          = wepon[value].GetComponent<WeponStatus>();
        bulletPrefab[value]   = weponStatus[value].get_bulletPrefab();
        bulletSpeed[value]    = weponStatus[value].get_bulletSpeed();
        rate[value]           = weponStatus[value].get_shootRate();
        magazineSize[value]   = weponStatus[value].get_maxClipAmmo();
        clipAmmo[value]       = weponStatus[value].get_maxClipAmmo();
        shootType[value]      = weponStatus[value].get_shootType();
        zoomFOV[value]        = weponStatus[value].get_zoomFVO();

        muzzle[value]         = wepon[value].transform.Find("MuzzlePosi").gameObject;
        shootRateNum          = rate[value];
    }

    public void InstantiateWepon()
    {
        wepon[main] = Instantiate(weponPrehub[main], equipTransform);
        wepon[main].SetActive(true);

        wepon[sub]  = Instantiate(weponPrehub[sub], equipTransform);
        wepon[sub].SetActive(false);

        //WeponInit(main);
        //WeponInit(sub);
    }

    public void CanShoot()
    {
        //�ˌ����[�g,canShot�Ǘ�
        if (shootRateNum < rate[weponNumber])
        {
            shootRateNum++;
        }

        if (shootRateNum == rate[weponNumber] && clipAmmo[weponNumber] > 0)
        {    
             canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }

    public void set_wepon(GameObject mainWepon, GameObject subWepon)
    {
        weponPrehub[main] = mainWepon;
        weponPrehub[sub] = subWepon;
    }
}
