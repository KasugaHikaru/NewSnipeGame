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
    NavMeshAgent agent;

    [SerializeField] private int maxHp;
    private int hp;
    [SerializeField] private float speed;
    [SerializeField] private float attckRange;

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
        state = STATE.Move;
        //aget
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        agent.SetDestination(target.transform.position);
        agent.speed = speed;

    }

    public void EnemyMove()
    {
        StateSwith();
        if (state == STATE.Move)
        {
            agent.SetDestination(target.transform.position);

        }
        else if (state == STATE.Attack)
        {
            agent.Stop();
        }
        
    }

    public void StateSwith()
    {
        float dis = Vector3.Distance(target.transform.position, transform.position);
        if (dis > attckRange)
        {
            state = STATE.Move;
        }
        else if (dis <= attckRange)
        {
            state = STATE.Attack;
        }
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
