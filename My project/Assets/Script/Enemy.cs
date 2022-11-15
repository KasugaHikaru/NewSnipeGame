using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int maxHp;
    private int hp;
    [SerializeField] private float deadWaitTime = 3;
    private bool isDead;

    CapsuleCollider capsuleCollider;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

    }

    public void Init()
    {
        hp = maxHp;
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
        isDead = true;
        capsuleCollider.enabled = false;
    }

}