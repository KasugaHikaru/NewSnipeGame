using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPosi;
    [SerializeField] private float bulletSpeed = 10.0f;         //弾速
    [SerializeField] private float shootRate = 1000.0f;         //発射レート  
    [SerializeField] private float shootRateNum = 0.0f;         //発射レート確認用の変数   
    [SerializeField] private int haveAmmo = 120;                //持ってる弾薬数
    [SerializeField] private int clipAmmo = 25;                 //マガジン内の弾薬数
    [SerializeField] private int maxClipAmmo = 25;              //最大のマガジン内の弾薬数

    //フラグ
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
        //RayJudge();
    }

    public void weponCntoroll()
    {

        //射撃
        if (Input.GetMouseButton(0) && canShoot) 
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletPosi.transform.position, bulletPosi.transform.rotation);

            Vector3 force;
            force = cam.gameObject.transform.forward * bulletSpeed;
            bullet.GetComponent<Rigidbody>().AddForce(force);

            Destroy(bullet, 3.0f);
            canShoot = false;
            shootRateNum = 0;
            clipAmmo--;
            animator.SetTrigger("Fire");
        }


        //射撃レート,canShot管理
        if (shootRateNum < shootRate)
        {
            shootRateNum++;
        }

        if (shootRateNum == shootRate && clipAmmo > 0)
        {
            canShoot = true;
        }


        //リロード
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            int reloadAmo = maxClipAmmo - clipAmmo;
            reloadAmo = reloadAmo < haveAmmo ? reloadAmo : haveAmmo;

            if (clipAmmo != maxClipAmmo && reloadAmo != 0)
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
