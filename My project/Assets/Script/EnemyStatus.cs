using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    [SerializeField] private int   maxHp;
    [SerializeField] private int   damage;
    [SerializeField] private float knockBackPower;
    [SerializeField] private float attackRange;
    [SerializeField] private float speed;

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
}
