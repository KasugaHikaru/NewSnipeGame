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
        wepon= GameObject.Find("WeponCtrl");
        damage = wepon.GetComponent<Wepon_>().get_damage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Damage(damage);
        }
    }

}
