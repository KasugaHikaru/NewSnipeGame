using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUiText : MonoBehaviour
{
    [SerializeField] private GameObject moneyObj;
    [SerializeField] private GameObject erementObj;
    //[SerializeField] private GameObject timeObj;

    private Text moneyText;
    private Text erementText;
    private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = moneyObj.GetComponent<Text>();
        erementText = erementObj.GetComponent<Text>();
        //timeText = timeObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        moneyText.text = "" + GameManager.instance.get_money();
        erementText.text = "" + GameManager.instance.get_erement();
    }
}
