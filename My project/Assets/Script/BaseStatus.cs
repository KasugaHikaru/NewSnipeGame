using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatus : MonoBehaviour
{
    [SerializeField] private int   maxHp;
                     private int   hp;
    [SerializeField] private int   damage;
    [SerializeField] private float speed;

    void Start()
    {
        hp = maxHp;
    }

    public int get_hp()
    {
        return hp;
    }
    public int get_damage()
    {
        return damage;
    }
    public float get_speed()
    {
        return speed;
    }
}
