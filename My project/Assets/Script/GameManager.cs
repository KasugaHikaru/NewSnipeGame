using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager gameManager = null;

    public float time;
    public int   wave;
    public int   money;
    public int   erement;

    private void Awake()
    {

        if (gameManager == null)
        {
            gameManager = this;
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

    public float get_time()
    {
        return time;
    }
    public int get_money()
    {
        return money;
    }
    public void set_money(int valu)
    {
        money += valu;
    }
    public int get_erement()
    {
        return erement;
    }

    public void set_erement(int valu)
    {
        erement += valu;
    }

}
