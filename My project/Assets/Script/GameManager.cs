using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public  float time;
    private float timeLimit;
    public  bool startArea;
    public  bool fnishArea;
    public  int beforeMoney;
    public  int beforeErement; 
    public  int money;
    public  int erement;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        time    = 0;
        wave    = 0;
        money   = 0;
        erement = 0;
    }

    public void StartArea()
    {
        beforeMoney = money;
        beforeErement = erement;
    }

    public void FnishArea()
    {

    }

    public void TimeUpdate()
    {
        time += Time.deltaTime;
    }

    public float get_time()
    {
        return time;
    }
    public int get_money()
    {
        return money;
    }
    public void set_money(int value)
    {
        money += value;
    }
    public int get_erement()
    {
        return erement;
    }

    public void set_erement(int value)
    {
        erement += value;
    }

}