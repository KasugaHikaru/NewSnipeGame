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

    [SerializeField] private GameObject areaInfoUi;

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

    [SerializeField] private TextMeshProUGUI areaNameText;
    [SerializeField] private TextMeshProUGUI areaInfoText;

    private Camera routeMapCamera;
    private GameObject clickObj;

    private const int areaPickUpQuateX = 90;
    private Vector3    normalCameraPosi;
    private Quaternion normalCameraQuate;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        InputClickObj();
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
        CreateArea(0);
        UiText();
        routeMapCamera = GameObject.Find("Route Map Camera").GetComponent<Camera>();
        normalCameraPosi  = routeMapCamera.transform.position;
        normalCameraQuate = routeMapCamera.transform.rotation;
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
        int nextAreaNum = Random.Range(choiceAreaMin, choiceAreaMax + 1);
        int nextArea_X = -(((nextAreaNum + (nextAreaNum - 1)) * areaSize) / 2) + 1;

        Vector3 addArea;
        addArea.x = nextArea_X;
        addArea.y = 0;
        addArea.z = addArea_Z;

        for (int i = 0; i < nextAreaNum; i++)
        {
            GameObject areaObj = Instantiate(areaObjPrefub[areaType], addArea, Quaternion.identity);
            areaObj.transform.parent = areaObjParents.transform;

            addArea.x += areaSize * 2;
        }

    }


    public void UiText()
    {
        haveMoneyText.text   = " " + GameManager.instance.get_money().ToString();
        haveErementText.text = " " + GameManager.instance.get_erement().ToString();
    }

    public void AreaInfoUiText(GameObject areaObj)
    {
        AreaInfoStatus areaInfoStatus = areaObj.GetComponent<AreaInfoStatus>();
        areaNameText.text = areaInfoStatus.get_areaName().ToString() + " Area";
        areaInfoText.text = areaInfoStatus.get_areaInfo().ToString();
    }

    public void InputClickObj()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickObj = null;
            Ray ray = routeMapCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                clickObj = hit.collider.gameObject;
            }

            if (clickObj != null)
            {
                AreaInfoUiText(clickObj);
                CamAreaPickUp(clickObj);
                AreaInfoUiActiveTrue();
            } 
        }
    }

    public void CamAreaPickUp(GameObject areaObj)
    { 
        Vector3 cameraPosi;
        cameraPosi.x = areaObj.transform.position.x + 1;
        cameraPosi.y = routeMapCamera.transform.position.y;
        cameraPosi.z = areaObj.transform.position.z;

        Quaternion cameraQuat;
        Vector3 quaternion = Vector3.zero;
        quaternion.x = areaPickUpQuateX;
        cameraQuat = Quaternion.Euler(quaternion);

        routeMapCamera.transform.position = cameraPosi;
        routeMapCamera.transform.rotation = cameraQuat;
    }

    public void CamReset()
    {
        routeMapCamera.transform.position = normalCameraPosi;
        routeMapCamera.transform.rotation = normalCameraQuate;
    }

    public void NextScreen()
    {
        GameManager.instance.ChangeScreen(areaNameText.text);
    }

    public void AreaInfoUiActiveTrue()
    {
        areaInfoUi.SetActive(true);
    }
    public void AreaInfoUiActiveFalse()
    {
        areaInfoUi.SetActive(false);
    }
}
