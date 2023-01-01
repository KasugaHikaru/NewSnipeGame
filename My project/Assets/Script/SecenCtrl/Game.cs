using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    
    enum SCREEN_NAME
    {
        ChoiceWepon,
        GameSetting,
        Map,
        Battle,
        Shop,
        Strengthen,
    }

    SCREEN_NAME nowScreen;

    [SerializeField] private GameObject[] allWeponList;

    // Start is called before the first frame update
    void Start()
    {
        nowScreen = SCREEN_NAME.ChoiceWepon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScreen()
    {



    }
}
