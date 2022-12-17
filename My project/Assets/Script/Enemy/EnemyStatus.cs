using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    [SerializeField] private int maxHp;
    private int hp;
    [SerializeField] private int   damage;
    [SerializeField] private float knockBackPower;
    [SerializeField] private float attackRange;
    [SerializeField] private float speed;
    [SerializeField] private int   dropMoney;
    [SerializeField] private int   dropErement;


    void Start()
    {
        hp = maxHp;
    }
    public int get_maxHp()
    {
        return maxHp;
    }
    public int get_damage()
    {
        return damage;
    }
    public float get_knockBackPower()
    {
        return knockBackPower;
    }
    public float get_attackRange()
    {
        return attackRange;
    }
    public float get_speed()
    {
        return speed;
    }

    public void Damage(int value)
    {

        if (value <= 0)
        {
            return;
        }

        hp -= value;

        if (hp <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(this.gameObject);
        GameManager.instance.set_money(dropMoney);
        GameManager.instance.set_erement(dropErement);
    }

}
