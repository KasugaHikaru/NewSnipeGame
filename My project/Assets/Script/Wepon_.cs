using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon_ : MonoBehaviour
{

    [SerializeField] private float shootRateNum = 0.0f;         //­Λ[gmFpΜΟ   
    [SerializeField] private int   clipAmmo;                    //}KWΰΜeς
    private bool canShoot=true;
    [SerializeField] private GameObject muzlle;

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
        ChangeWepon(weponNumber);
    }

    public WeponStatus GetWeaponStatus()
    {
        return weponStatus;
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
        muzlle = weponStatus.get_muzzle();
    }

    public void WeponCtlr()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {

            GameObject bullet = Instantiate(weponStatus.get_bulletPrefab(), muzlle.transform.position, muzlle.transform.rotation);

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
        //Λ[g,canShotΗ
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
