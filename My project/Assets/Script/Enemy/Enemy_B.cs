using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_B : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    private EnemyStatus enemyStatus;
    [SerializeField] private GameObject bomPrefab;


    private float attackRange;
    [SerializeField] private float explosionTime; 
    private bool isAttack;

    enum STATE
    {
        Trail,
        Attack,
    }

    STATE state;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttack)
        {
            Move();
        }
    }

    public void Init()
    {
        enemyStatus = GetComponent<EnemyStatus>();
        agent       = GetComponent<NavMeshAgent>();
        target      = GameObject.Find("Player");
        agent.speed = enemyStatus.get_speed();
        attackRange = enemyStatus.get_attackRange();
        isAttack    = false;
    } 

    public void Move()
    {
        SwithState();
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
        float dis = Vector3.Distance(transform.position, target.transform.position);

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
        agent.SetDestination(target.transform.position);
    }
    
    public void Attack()
    {
        agent.speed = 0.0f;
        isAttack = true;
        Invoke("Explosion", explosionTime);
    }

    public void Explosion()
    {
        GameObject bom = Instantiate(bomPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
