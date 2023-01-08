using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AreaObjectClick : MonoBehaviour, IPointerClickHandler
{

    private GameObject routeMapCamera;

    private Quaternion cameraQuat;



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
        routeMapCamera = GameObject.Find("Route Map Camera");
        Vector3 quaternion = Vector3.zero;
        quaternion.x = 90;
        cameraQuat = Quaternion.Euler(quaternion);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CamSet();

    }

    public void CamSet()
    {
        Vector3 cameraPosi;
        cameraPosi.x = this.transform.position.x;
        cameraPosi.y = routeMapCamera.transform.position.y;
        cameraPosi.z = this.transform.position.z;

        routeMapCamera.transform.position = cameraPosi;
        routeMapCamera.transform.rotation = cameraQuat;
    }

    public void InfoUiEnabledFalse()
    {

    }
}
