using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUiText : MonoBehaviour
{
    [SerializeField] private GameObject moneyObj;
    [SerializeField] private GameObject erementObj;
    //[SerializeField] private GameObject timeObj;

    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI erementText;
    private TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText   = moneyObj.GetComponent<TextMeshProUGUI>();
        erementText = erementObj.GetComponent<TextMeshProUGUI>();
        //timeText = timeObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text   = " " + GameManager.instance.get_money().ToString();
        erementText.text = " " + GameManager.instance.get_erement().ToString();
    }
}
