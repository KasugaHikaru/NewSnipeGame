using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPosi;
    [SerializeField] private float bulletSpeed = 10.0f;         //e¬
    [SerializeField] private float shootRate = 1000.0f;         //­Λ[g  
    [SerializeField] private float shootRateNum = 0.0f;         //­Λ[gmFpΜΟ   
    [SerializeField] private int haveAmmo = 120;                //ΑΔιeς
    [SerializeField] private int maxHaveAmmo = 120;             //ΔιΕεΜeς
    [SerializeField] private int clipAmmo = 25;                 //}KWΰΜeς
    [SerializeField] private int maxClipAmmo = 25;              //ΕεΜ}KWΰΜeς

    //tO
    private bool canShoot = false;


    public float get_bulletSpeed() { return bulletSpeed; }

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject cam ;

    // Start is called before the first frame update
    void Start()
    {
       // shootRateNum = shootRate;
    }

    // Update is called once per frame
    void Update()
    { 
        weponCntoroll();
        RayJudge();
    }

    public void weponCntoroll()
    {

        //Λ
        if (Input.GetMouseButton(0) && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletPosi.transform.position, bulletPosi.transform.rotation);

            Vector3 force;
            force = cam.gameObject.transform.forward * bulletSpeed;
            bullet.GetComponent<Rigidbody>().AddForce(force);

            canShoot = false;
            shootRateNum = 0;
            clipAmmo--;
            animator.SetTrigger("Fire");
        }


        //Λ[g,canShotΗ
        if (shootRateNum < shootRate)
        {
            shootRateNum++;
        }

        if (shootRateNum == shootRate && clipAmmo > 0)
        {
            canShoot = true;
        }


        //[h
        if (Input.GetKeyDown(KeyCode.R))
        {
            int reloadAmo = maxClipAmmo - clipAmmo;
            reloadAmo = reloadAmo < haveAmmo ? reloadAmo : haveAmmo;

            if (clipAmmo != maxClipAmmo || reloadAmo != 0)
            {
                clipAmmo += reloadAmo;
                haveAmmo -= reloadAmo;
                animator.SetTrigger("Reload");
            }
        }

    }

    public void RayJudge()
    {
        Ray ray = new Ray(bulletPosi.transform.position,bulletPosi.transform.forward);
    }
}
