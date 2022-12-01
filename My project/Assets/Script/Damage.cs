using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField] private GameObject me;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageCalc(int value)
    {

        if (value <= 0)
        {
            return;
        }

      //  hp -= value;

     //  if (hp <= 0)
     //  {
     //      Dead();
     //  }
    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
