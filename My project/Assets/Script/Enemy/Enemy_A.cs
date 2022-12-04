using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_A : MonoBehaviour
{
    enum STATE
    {
        Trail,
        Attack,
    }

    STATE state;

    private EnemyStatus enemyStatus;

    private GameObject   target;
    private NavMeshAgent agent;
    private Vector3      destination;

    private int   maxHp;
    private int   damage;
    private float knockBackPower;
    private float attackRange;
    private float speed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackTime;
    private float numAttackTime;
    private bool hitPlayer;
    private bool swithState;
    private Vector3 attackStartPosi;

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
        enemyStatus    = GetComponent<EnemyStatus>();
        maxHp          = enemyStatus.get_maxHp();
        speed          = enemyStatus.get_speed();
        damage         = enemyStatus.get_damage();
        knockBackPower = enemyStatus.get_knockBackPower();
        attackRange    = enemyStatus.get_attackRange();
   
        state = STATE.Trail;
        //aget
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        destination = target.transform.position;
        agent.SetDestination(destination);
        agent.speed = speed;
        hitPlayer = false;
        swithState = true;
}

    public void EnemyMove()
    {
        if (swithState)
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
        if (swithState)
        {
            attackStartPosi = transform.position;
            agent.ResetPath();
            numAttackTime = 0;
        }

        swithState = false;
        transform.position += (transform.forward).normalized * attackSpeed;
        numAttackTime += Time.deltaTime;

        if ((Vector3.Distance(transform.position, attackStartPosi) >= attackDistance) || numAttackTime >= attackTime)  
        {
            hitPlayer = false;
            swithState = true;
            numAttackTime = 0;
            targetSet();
        }
    }

    public void targetSet()
    {
        destination = target.transform.position;
        agent.SetDestination(destination);
    }


    private void OnCollisionEnter(Collision collision)                
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!hitPlayer)
            {
                hitPlayer = true;
                collision.gameObject.GetComponent<Player>().Damage(damage);

                Vector3 knockBackVectol = (collision.transform.position - transform.position).normalized;
                collision.rigidbody.AddForce(knockBackVectol * knockBackPower, ForceMode.VelocityChange);
            }
        }
    }

}
