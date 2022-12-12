using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private int initWeakEnemyValu;
    [SerializeField] private int initStrongEnemyValu;
    [SerializeField] private int initSpornPosiValu;

    private int nowWeakEnemyValu;
    private int nowStrongEnemyValu;
    private int nowSpornPosiValu;

    [SerializeField] private GameObject[] allWeakEnemyList;
    [SerializeField] private GameObject[] allStrongEnemyList;

    private List<GameObject> weakEnemyList;
    private List<GameObject> strongEnemyList;

    [SerializeField] private GameObject[] allEnemySpornPosi;
    private List<GameObject> enemySpornPosi;

    [SerializeField] private float EnemySpornRate;
    private float EnemySpornRateNum;

    private int   wave;
    [SerializeField] private int fnishWave;
    private bool  waveStart;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Updata();
    }

    public void Init()
    {
        nowWeakEnemyValu   = initWeakEnemyValu;
        nowStrongEnemyValu = initStrongEnemyValu;
        nowSpornPosiValu   = initSpornPosiValu;

        weakEnemyList   = null;
        strongEnemyList = null;
        enemySpornPosi  = null;

        EnemySpornRateNum = 0;

        wave = 0;
        waveStart = true;
    }

    public void Updata()
    {
        if (waveStart)
        {
            weakEnemyList   = ListSet_(nowWeakEnemyValu, allWeakEnemyList);
            strongEnemyList = ListSet_(nowStrongEnemyValu, allStrongEnemyList);
            enemySpornPosi  = ListSet_(nowSpornPosiValu, allEnemySpornPosi);
            wave++;
            waveStart = false;
        }

        EnemySpornRateNum += Time.deltaTime;
        
        if (EnemySpornRateNum >= EnemySpornRate)
        {
            EnemySporn(weakEnemyList);
            EnemySpornRateNum = 0;
        }

    }

    public List<GameObject> ListSet_(int times, GameObject[] allLsit)
    {
        List<GameObject> list = new List<GameObject>();

        for (int i = 0; i < times; i++)
        {
            int randomValu;
            randomValu = Random.Range(0, allLsit.Length);
            if (!list.Contains(allLsit[randomValu]))
            {
                list.Add(allLsit[randomValu]);
            }
            else
            {
                i--;
            }
        }
        return list;
    }

    public void EnemySporn(List<GameObject> enemyList)
    {
        int enemyTypeValu;
        enemyTypeValu = Random.Range(0, enemyList.Count);

        int spronPosiValu;
        spronPosiValu = Random.Range(0, enemySpornPosi.Count);

        Instantiate(enemyList[enemyTypeValu], enemySpornPosi[spronPosiValu].transform);
    }
}
