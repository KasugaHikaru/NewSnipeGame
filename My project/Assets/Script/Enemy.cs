using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    enum STATE
    {
        Trail,
        Attack,
    }

    STATE state;

    private GameObject   target;
    private NavMeshAgent agent;
    private Vector3      destination;

    [SerializeField] private int   maxHp;
                     private int   hp;
    [SerializeField] private int   damage;
    [SerializeField] private float knockBackPower;
   // [SerializeField] private float attackRate;
   //                  private float attackRateNum;
    [SerializeField] private float speed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDistance;
    [SerializeField] private int   startAttackGapTime;
    [SerializeField] private int   finishAttackGapTime;

    private bool isSwithState;
    private Vector3 numPosi;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        Debug.Log("敵位置："+transform.position);
        Debug.Log("ゴール位置：" + agent.destination);
    }

    public void Init()
    {
        hp = maxHp;
        state = STATE.Trail;
        //aget
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        destination = target.transform.position;
        agent.SetDestination(destination);
        agent.speed = speed;
        isSwithState = true;

    }

    public void EnemyMove()
    {

        if (isSwithState)
        {
            SwithState();
        }

        if (state == STATE.Trail)
        {
            Trail();
        }
        else if (state == STATE.Attack)
        {
            Attack();   
        }

    }

    public void SwithState()
    {
        float dis = Vector3.Distance(transform.position, destination);

        if (dis > attackRange)
        {
            state = STATE.Trail;
        }
        else if (dis <= attackRange) 
        {
            state = STATE.Attack;
        }
    }

    public void Trail()
    {
        agent.speed = speed;
        targetSet();
    }

    public void Attack()
    {
        if (isSwithState)
        {
            numPosi = transform.position;
        }

        isSwithState = false;
        agent.speed = attackSpeed;

        Vector3 a;
        a.x = attackDistance * Mathf.Sin(transform.rotation.y) - transform.position.x;
        a.z = attackDistance * Mathf.Cos(transform.rotation.y) - transform.position.z;
        a.y = 0.0f;

        agent.destination = a;

        if (transform.position == agent.destination)
        {
            isSwithState = true;
            targetSet();
        }

        //if (Vector3.Distance(numPosi, transform.position) > attackDistance)
        //{
        //    isSwithState = true;
        //    targetSet();
        //}
    }

    public void targetSet()
    {
        destination = target.transform.position;
        agent.SetDestination(destination);
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
