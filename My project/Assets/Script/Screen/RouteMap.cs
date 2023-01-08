using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RouteMap : MonoBehaviour
{
    [SerializeField] private GameObject areaObjParentsPrefub;
    [SerializeField] private GameObject playerObjPrefub;
    private GameObject playerObj = null;
    private GameObject areaObjParents = null;

    [SerializeField] private GameObject[] areaObjPrefub;
    [SerializeField] private int areaMax = 10;
    [SerializeField] private int choiceAreaMax = 3;
    [SerializeField] private int choiceAreaMin = 1;

    private const int areaSize = 2;
    private const int addArea_Z = 5;

    private int nowArea;
    private int nowChoiceArea;

    [SerializeField] private TextMeshProUGUI haveMoneyText;
    [SerializeField] private TextMeshProUGUI haveErementText;

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
        if (areaObjParents == null)
        {
            areaObjParents = Instantiate(areaObjParentsPrefub, Vector3.zero, Quaternion.identity);
            areaObjParents.transform.parent = GameObject.Find("RouteMap" + "(Clone)").transform;
        }
        if (playerObj == null)
        {
            playerObj = Instantiate(playerObjPrefub, Vector3.zero, Quaternion.identity);
            playerObj.transform.parent = areaObjParents.transform;
        }
        CreateArea();
        UiText();
    }

    public void CreateArea()
    {
        int nextAreaNum = Random.Range(choiceAreaMin, choiceAreaMax + 1);
        int nextArea_X = -(((nextAreaNum + (nextAreaNum - 1)) * areaSize) / 2) + 1;

        Vector3 addArea;
        addArea.x = nextArea_X;
        addArea.y = 0;
        addArea.z = addArea_Z;

        for (int i = 0; i < nextAreaNum; i++)
        {
            int areaType = Random.Range(0, areaObjPrefub.Length);

            GameObject areaObj = Instantiate(areaObjPrefub[areaType], addArea, Quaternion.identity);
            areaObj.transform.parent = areaObjParents.transform;

            addArea.x += areaSize * 2;
        }

    }

    public void CreateArea(int areaType)
    {

    }

    public void UiText()
    {
        haveMoneyText.text = " " + GameManager.instance.get_money().ToString();
        haveErementText.text = " " + GameManager.instance.get_erement().ToString();
    }



}
