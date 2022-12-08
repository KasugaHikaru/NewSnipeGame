using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform wepon;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        wepon  = GameObject.Find("Equip").transform.GetChild(0);
        damage = wepon.GetComponent<WeponStatus>().get_damage();
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
