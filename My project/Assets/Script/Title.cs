using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{

    [SerializeField] private GameObject secenPrefub;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(secenPrefub);
    }
}
