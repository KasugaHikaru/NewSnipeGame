using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon_ : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float bulletSpeed = 10.0f;         //e¬
    [SerializeField] private float shootRate = 1000.0f;         //­Λ[g  
    [SerializeField] private float shootRateNum = 0.0f;         //­Λ[gmFpΜΟ   
    [SerializeField] private int clipAmmo = 25;                 //}KWΰΜeς
    [SerializeField] private int maxClipAmmo = 25;              //ΕεΜ}KWΰΜeς
    private bool canShoot=true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        WeponCtlr();
    }


    public void WeponCtlr()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);

            Vector3 force;
            force = gameObject.transform.forward * bulletSpeed;
            bullet.GetComponent<Rigidbody>().AddForce(force);

            Destroy(bullet, 3.0f);
            canShoot = false;
            shootRateNum = 0;
            clipAmmo--;
        }

        CanShoot();
    }

    public void CanShoot()
    {
        //Λ[g,canShotΗ
        if (shootRateNum < shootRate)
        {
            shootRateNum++;
        }

        if (shootRateNum == shootRate && clipAmmo > 0)
        {
            canShoot = true;
        }
    }

}
