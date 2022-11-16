using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon_ : MonoBehaviour
{

    [SerializeField] private float shootRateNum = 0.0f;         //発射レート確認用の変数   
    [SerializeField] private int   clipAmmo;                    //マガジン内の弾薬数
    private bool canShoot;
    [SerializeField] private GameObject muzzle;

    [SerializeField] private GameObject[] wepon;
    private int weponNumber;
    private int nowWeponNumber;
    [SerializeField] private Transform equipTransform;


    private WeponStatus weponStatus;

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

    public void ChangeWepon(int valu)
    {
        if (nowWeponNumber != 0)
        {
            Destroy(equipTransform.GetChild(0).gameObject);
        }

        GameObject NowWepon;
        NowWepon = Instantiate(wepon[valu], equipTransform.transform.position, equipTransform.transform.rotation, equipTransform);
        nowWeponNumber = valu;
        weponStatus = wepon[valu].GetComponent<WeponStatus>();
        clipAmmo = weponStatus.get_maxClipAmmo();
        
    }

    public void WeponCtlr()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            //muzzle = weponStatus.get_muzzle();
            muzzle = wepon[weponNumber].transform.Find("MuzzlePosi").gameObject;

            GameObject bullet = Instantiate(weponStatus.get_bulletPrefab(), muzzle.transform.position, muzzle.transform.rotation);

            Vector3 force;
            force = gameObject.transform.forward * weponStatus.get_bulletSpeed();
            bullet.GetComponent<Rigidbody>().AddForce(force);

            Destroy(bullet, 3.0f);
            canShoot = false;
            shootRateNum = 0;
            clipAmmo--;
            
        }

        CanShoot();

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
    }

    public void CanShoot()
    {
        //射撃レート,canShot管理
        if (shootRateNum < weponStatus.get_shootRate())
        {
            shootRateNum++;
        }

        if (shootRateNum == weponStatus.get_shootRate() && clipAmmo > 0)
        {
            canShoot = true;
        }
    }


}
