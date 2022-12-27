using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public string nowScene;


    [SerializeField] private GameObject[] secenPrefub;

    public  float time;
    [SerializeField] private float timeLimit;
    public bool startArea;
    public bool fnishArea;
    public int beforeMoney;
    public int beforeErement; 
    public int money;
    public int erement;
    public int areaNum;

    bool a=false;

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
        CreateSecen();
        nowScene = SceneManager.GetActiveScene().name;
        areaNum = 0;
        time    = 0;
        money   = 0;
        erement = 0;
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        nowScene = sceneName;
        CreateSecen();
    }

    public void CreateSecen()
    {
        foreach (GameObject num in secenPrefub)
        {
            if (num.name == nowScene)
            {
                Instantiate(num);
            }
        }
    }

    public void StartArea()
    {
        startArea = true;
        time = 0;
        beforeMoney = money;
        beforeErement = erement;
    }

    public void FnishArea()
    {

    }


    public void BattleArea()
    {


        TimeUpdate();
        if (time >= timeLimit)
        {
            FnishArea();
        }
    }

    public void ShopArea()
    {

    }

    public void StrengthenArea()
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