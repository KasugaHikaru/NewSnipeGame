using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    private string nowScene;
    [SerializeField] private GameObject[] secenPrefub;
    [SerializeField] private GameObject[] screenPrefub;

    [SerializeField] private List<GameObject> haveMainWepon;
    [SerializeField] private List<GameObject> haveSubWepon;

    private float time;
    [SerializeField] private float timeLimit;
    private bool startArea;
    private bool fnishArea;
    private int  beforeMoney;
    private int  beforeErement;
    private int  money;
    private int  erement;
    private int  areaNum;

    private string nowScreen;

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
        nowScene = SceneManager.GetActiveScene().name;
       // CreateSecen();
        areaNum = 0;
        time = 0;
        money = 0;
        erement = 0;
    }


    public void ChangeScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
        nowScene = nextSceneName;
        //CreateSecen();
    }

    //public void CreateSecen()
    //{
    //    foreach (GameObject screnObj in secenPrefub)
    //    {
    //        if (screnObj.name == nowScene)
    //        {
    //            Instantiate(screnObj);
    //            return;
    //        }                   
    //    }
    //    Debug.Log("SecenObjct not found");
    //}


    //public void AddSecenComponent(string componentName)
    //{
    //    Type componentNameNum = Type.GetType(componentName);
    //    if (componentNameNum != null)
    //    {
    //        gameObject.AddComponent(componentNameNum);
    //    }
    //    else
    //    {
    //        Debug.LogFormat("{0} not found", componentNameNum);
    //    }
    //
    //}


    public void ChangeScreen(string nextScreenName)
    {
        nowScreen = nextScreenName;
        CreateScreen();
    }

    public void CreateScreen()
    {
        foreach (GameObject screenObj in screenPrefub)
        {
            if (screenObj.name == nowScreen)
            {
                Instantiate(screenObj);
                return;
            }
           
        }
        Debug.Log("ScreenObjct not found");   
    }

    public void SetWepon(GameObject wepon,bool type)
    {
        if (type)
        {
            haveMainWepon.Add(wepon);
        }
        else if (!type)
        {
            haveSubWepon.Add(wepon);
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