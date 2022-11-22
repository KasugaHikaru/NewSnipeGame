using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    enum STATE
    {
        Move,
        Attack,
    }

    STATE state;
        
    private GameObject target;
    [SerializeField] private int maxHp;
    private int hp;
    [SerializeField] private float speed;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    public void Init()
    {
        hp = maxHp;
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    public void EnemyMove()
    {
        if (state == STATE.Move)
        {

        }
        else if (state == STATE.Attack)
        {

        }
        agent.destination = target.transform.position;
        //transform.LookAt(target.transform);
        //transform.position += transform.forward * speed * Time.deltaTime;
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
    }

}
