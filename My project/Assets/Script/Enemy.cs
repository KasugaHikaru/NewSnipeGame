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

    private EnemyStatus enemyStatus;
    [SerializeField] private Player player;

    private GameObject   target;
    private NavMeshAgent agent;
    private Vector3      destination;

    private int   hp;
    private int   maxHp;
    private int   damage;
    private float knockBackPower;
    private float attackRange;
    private float speed;
    // [SerializeField] private float attackRate;
    //                  private float attackRateNum;
    [SerializeField] private float attackSpeed;
    private bool hitPlayer;


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

        hp = maxHp;
        state = STATE.Trail;
        //aget
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        destination = target.transform.position;
        agent.SetDestination(destination);
        agent.speed = speed;
        hitPlayer = false;

    }

    public void EnemyMove()
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
        agent.speed = attackSpeed;
        //agent.ResetPath();
        if (hitPlayer)
        {
            player.Damage(damage);
        }
        targetSet();
    }

    public void targetSet()
    {
        destination = target.transform.position;
        agent.SetDestination(destination);
    }


    private void OnCollisionEnter(Collision collision)                //’n–Ê‚Æ‚Ì“–‚½‚è”»’è
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitPlayer = true;
            //collision.gameObject.GetComponent<Player>().Damage(damage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitPlayer = false;
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
