using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{ 
    private GameObject[] spornWeakEnemy;
    private GameObject[] spornStrongEnemy;

    private GameObject[] enemySpornPosi;

    [SerializeField] private float weakEnemySpornRate;
    private float weakEnemySpornRateNum;

    [SerializeField] private float strongEnemySpornRate;
    private float strongEnemySpornRateNum;

    private bool start;

    //Start is called before the first frame update
    void Start()
    {
        Init();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Updata();
        }
    }
    
    public void Init()
    {
        start = false;
        weakEnemySpornRateNum = 0;
        strongEnemySpornRateNum = 0;
    }
    
    public void Updata()
    {
        weakEnemySpornRateNum += Time.deltaTime;
        strongEnemySpornRateNum += Time.deltaTime;

        if (weakEnemySpornRateNum >= weakEnemySpornRate)
        {
            EnemySporn(spornWeakEnemy);
            weakEnemySpornRateNum = 0;
        }
        
        if (strongEnemySpornRateNum >= strongEnemySpornRate)
        {
            EnemySporn(spornStrongEnemy);
            strongEnemySpornRateNum = 0;
        }
    }
    
    public void EnemySporn(GameObject[] enemy)
    {
        int enemyTypeValu;
        enemyTypeValu = Random.Range(0, enemy.Length + 1);
    
        int spronPosiValu;
        spronPosiValu = Random.Range(0, enemySpornPosi.Length + 1);

        if (enemy[enemyTypeValu] != null)
        {
            GameObject obj = Instantiate(enemy[enemyTypeValu], enemySpornPosi[spronPosiValu].transform.position,Quaternion.identity,this.transform);
        }
        else
        {

        }
    }
    
    public void set_enemySpornPosi(GameObject[] enemySpornPosiOnMap)
    {
        enemySpornPosi = enemySpornPosiOnMap;
    }
    
    public void set_spornWeakEnemy(GameObject[] weakEnemy)
    {
        spornWeakEnemy = weakEnemy;
    }

    public void set_spornStrongEnemy(GameObject[] strongEnemy)
    {
        spornStrongEnemy = strongEnemy;
    }

    public void startFlag()
    {
        start = true;
    }
}
