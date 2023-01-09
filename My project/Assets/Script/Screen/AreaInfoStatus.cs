using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInfoStatus : MonoBehaviour
{

    [SerializeField] private string areaName;
    [SerializeField] private string areaInfo;

    public string get_areaName()
    {
        return areaName;
    }

    public string get_areaInfo()
    {
        return areaInfo;
    }
}
