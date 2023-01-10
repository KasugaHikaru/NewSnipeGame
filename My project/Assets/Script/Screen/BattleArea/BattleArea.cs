using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleArea : MonoBehaviour
{
    [SerializeField] private GameObject enemyCtrl;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject playerCtrl;

    [SerializeField] private GameObject[] allMapPrehub;
    [SerializeField] private GameObject[] allWeakEnemyPrehub;
    [SerializeField] private GameObject[] allStorngEnemyPrehub;

    [SerializeField] private GameObject   playerPrehub;
    private GameObject   playerObj;
    private GameObject   mapPrehub;
    private GameObject   mapObj;
    private GameObject[] weakEnemyPrehub;
    private GameObject[] strongEnemyPrehub;

    [SerializeField] private int spornWeakEnemyValue;
    [SerializeField] private int spornStrongEnemyValue;

    //UI
    [SerializeField] private Image[]           weakEnemyImg;
    [SerializeField] private TextMeshProUGUI[] weakEnemyNameText;

    [SerializeField] private Image[]           strongEnemyImg;
    [SerializeField] private TextMeshProUGUI[] strongEnemyNameText;

    [SerializeField] private Image           mapImg;
    [SerializeField] private TextMeshProUGUI mapNameText;

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
        weakEnemyPrehub   = EnemySet(spornWeakEnemyValue  , allWeakEnemyPrehub).ToArray();
        strongEnemyPrehub = EnemySet(spornStrongEnemyValue, allStorngEnemyPrehub).ToArray();

        enemyCtrl.GetComponent<EnemyCtrl>().set_spornWeakEnemy(weakEnemyPrehub);
        enemyCtrl.GetComponent<EnemyCtrl>().set_spornStrongEnemy(strongEnemyPrehub);

        mapPrehub = MapSet();

        SetEnemyUi();
    }

    public List<GameObject> EnemySet(int spornEnemyValue, GameObject[] allLsit)
    {

        List<GameObject> list = new List<GameObject>();

        for (int i = 0; i < spornEnemyValue; i++)
        {
            int randomNum = Random.Range(0, allLsit.Length);

            if (!list.Contains(allLsit[randomNum]))
            {
                list.Add(allLsit[randomNum]);
            }
            else
            {
                i--;
            }
        }
        return list;
    }

    public GameObject MapSet()
    {
        int randomNum = Random.Range(0, allMapPrehub.Length);
        return allMapPrehub[randomNum];
    }

    public void SetEnemyUi()
    {
        for (int i=0;i< spornWeakEnemyValue; i++) 
        {
            EnemyStatus enemyStatus = weakEnemyPrehub[i].GetComponent<EnemyStatus>();

            weakEnemyNameText[i].text = weakEnemyPrehub[i].name.ToString();
            weakEnemyImg[i].sprite = enemyStatus.get_img();

        }
        for (int i = 0; i < spornStrongEnemyValue; i++)
        {
            EnemyStatus enemyStatus = strongEnemyPrehub[i].GetComponent<EnemyStatus>();

            strongEnemyNameText[i].text = strongEnemyPrehub[i].name.ToString();
            strongEnemyImg[i].sprite = enemyStatus.get_img();
        }
    }

    public void StartBattle()
    {
        mapObj = Instantiate(mapPrehub, Vector3.zero, Quaternion.identity, map.transform);
        mapObj.SetActive(true);

        //playerObj = Instantiate(playerPrehub, new Vector3(0, 5, 0), Quaternion.identity, playerCtrl.transform);
        //playerObj.SetActive(true);
        playerCtrl.SetActive(true);
        playerCtrl.GetComponent<Wepon>().Init();

        enemyCtrl.GetComponent<EnemyCtrl>().startFlag();
    }
}
