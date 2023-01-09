using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField] private GameObject screenObjParetPrefub;
    private GameObject screenObjParet = null;

    [SerializeField] private GameObject[] secenPrefub;
    [SerializeField] private GameObject[] screenPrefub;

    public List<GameObject> haveMainWepon;
    public List<GameObject> haveSubWepon;

    private float time;
    [SerializeField] private float timeLimit;

    private int  money;
    private int  erement;

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
       // CreateSecen();
        time = 0;
        money = 0;
        erement = 0;
    }


    public void ChangeScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
        //nowScene = nextSceneName;
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
        if (screenObjParet == null) 
        {
            screenObjParet = Instantiate(screenObjParetPrefub);
        }
        foreach (GameObject screenObj in screenPrefub)
        {
            if (screenObj.name == nowScreen)
            {
                GameObject obj = Instantiate(screenObj);
                obj.transform.parent = screenObjParet.transform;
                return;
            }
           
        }
        Debug.Log("ScreenObjct not found");   
    }

    public void SetMainWepon(GameObject wepon)
    {
        haveMainWepon.Add(wepon);
    }
    public void SetSubWepon(GameObject wepon)
    {
        haveSubWepon.Add(wepon);
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