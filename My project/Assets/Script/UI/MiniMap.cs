using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCtrl");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posi = this.transform.position;

        posi.x = player.transform.position.x;
        posi.z = player.transform.position.z;

        this.transform.position = posi;
    }
}
