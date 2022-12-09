using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;
    [SerializeField] private int EnemyDamage;
    [SerializeField] private float knockBackPower;
    [SerializeField] private float duration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Vector3 knockBackVectol = (other.transform.position - transform.position).normalized;

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyStatus>().Damage(EnemyDamage);
            other.gameObject.GetComponent<Rigidbody>().AddForce(knockBackVectol * knockBackPower, ForceMode.VelocityChange);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Damage(PlayerDamage);      
            other.gameObject.GetComponent<Rigidbody>().AddForce(knockBackVectol * knockBackPower, ForceMode.VelocityChange);
        }


        Invoke("Finish", duration);
    }

    public void Finish()
    {
        Destroy(this.gameObject);
    }
}
