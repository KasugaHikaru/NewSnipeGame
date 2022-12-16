using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] Camera cam;
    private float defaultFOV;
    private float zoomFOV;

    [SerializeField] private GameObject[] wepon;
    [SerializeField] private Transform equipTransform;

    private WeponStatus weponStatus;

    private float  shootRateNum = 0.0f;                      //発射レート確認用の変数   
    private int[]  clipAmmo= { -1,-1,-1};                    //マガジン内の弾薬数
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
    private float zoomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        zoomSpeed = 0.1f;
        weponNumber = 1;
        nowWeponNumber = 0;
        canShoot = true;
        defaultFOV = cam.fieldOfView;
        ChangeWepon(weponNumber);
    }


    public void WeponCtlr()
    {
        //射撃
        if(!shootType)                   //単発
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        else if (shootType)              //連射
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }

        //ADS
        
        ADS();
        

        //リロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        //武器チェン
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

        //フラグ管理
        CanShoot();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            //弾の生成
            GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);

            //弾の方向、ベクトル
            Vector3 force;
            force = NowWepon.transform.forward * bulletSpeed;
            bullet.GetComponent<Rigidbody>().AddForce(force);

            //弾、フラグなどの後処理
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
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomFOV, Time.deltaTime / zoomSpeed);
        }
        if (!Input.GetMouseButton(1))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultFOV, Time.deltaTime / zoomSpeed);
        }
    }

    public void Reload()
    {
        clipAmmo[nowWeponNumber] = maxClipAmmo;
    }

    public void ChangeWepon(int valu)
    {
        //既にある武器を消す
        if (nowWeponNumber != 0)
        {
            Destroy(equipTransform.GetChild(0).gameObject);
        }

        //武器の生成
        NowWepon = Instantiate(wepon[valu], equipTransform.transform.position, equipTransform.transform.rotation, equipTransform);
        nowWeponNumber = valu;
        weponStatus = wepon[valu].GetComponent<WeponStatus>();      //WeponStatusクラスから武器ステータスの情報を取得

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
        zoomFOV      = weponStatus.get_zoomFVO();

        muzzle = NowWepon.transform.Find("MuzzlePosi").gameObject;
        shootRateNum = shootRate;

        if (clipAmmo[nowWeponNumber] == -1)
        {
            clipAmmo[nowWeponNumber] = maxClipAmmo;
        }

    }

    public void CanShoot()
    {
        //射撃レート,canShot管理
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
}
