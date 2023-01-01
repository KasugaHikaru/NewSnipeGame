using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    GameObject enemyCtrlObj;
    [SerializeField] private GameObject[] enemySpornPosi; 

    // Start is called before the first frame update
    void Start()
    {
        enemyCtrlObj = GameObject.Find("EnemyCtrl").gameObject;
        enemyCtrlObj.GetComponent<EnemyCtrl>().set_allEnemySpornPosi(enemySpornPosi);
    }

}
