using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private GameObject wepon;
   private int damage;

    // Start is called before the first frame update
    void Start()
    {
        wepon  = GameObject.Find("PlayerCtrl");
        damage = wepon.GetComponent<Wepon>().get_damage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<EnemyStatus>().Damage(damage);
        }
    }

}
