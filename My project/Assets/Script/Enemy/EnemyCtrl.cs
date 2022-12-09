using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private int weakEnemyValue;
    [SerializeField] private int strongEnemyValue;

    [SerializeField] private GameObject[] allWeakEnemyList;
    [SerializeField] private GameObject[] allStrongEnemyList;

    private List<GameObject> weakenemyList;
    private List<GameObject> strongenemyList;

    [SerializeField] private GameObject[] allEnemySpornPosi;
    private List<GameObject> enemySpornPosi;

    [SerializeField] private float EnemySpornRate;
    private float EnemySpornRateNum;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    public void EnemySporn()
    {

    }
}
