using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceWepon : MonoBehaviour
{
    
    private WeponStatus mainStatusScrpt;
    [SerializeField] private Image           mainImg;
    [SerializeField] private TextMeshProUGUI mainNameText;
    [SerializeField] private TextMeshProUGUI mainDamageText;
    [SerializeField] private Slider          mainDamageSlider;
    [SerializeField] private TextMeshProUGUI mainRateText;
    [SerializeField] private Slider          mainRateSlider;
    [SerializeField] private TextMeshProUGUI mainMagazinSizeText;
    [SerializeField] private Slider          mainMagazinSizeSlider;
    [SerializeField] private TextMeshProUGUI mainTypeOfFireText;

    [Header("")]

    private WeponStatus subStatusScrpt;
    [SerializeField] private Image           subImg;
    [SerializeField] private TextMeshProUGUI subNameText;
    [SerializeField] private TextMeshProUGUI subDamageText;
    [SerializeField] private Slider          subDamageSlider;
    [SerializeField] private TextMeshProUGUI subRateText;
    [SerializeField] private Slider          subRateSlider;
    [SerializeField] private TextMeshProUGUI subMagazinSizeText;
    [SerializeField] private Slider          subMagazinSizeSlider;
    [SerializeField] private TextMeshProUGUI subTypeOfFireText;

    [SerializeField] private GameObject[] allMainWepon;
    [SerializeField] private GameObject[] allSubWepon;

    private int choiceMainNumver;
    private int choiceSubNumver;

    private const int MaxDamage      = 10;
    private const int MaxRate        = 50;
    private const int MaxMagazinSize = 50;

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
        choiceMainNumver = 0;
        choiceSubNumver  = 0;

        MainStatusSet();
        SubStatusSet();
    }

    public void UpChoiceMain()
    {
        choiceMainNumver++;
        MainStatusSet();
    }
    public void DownChoiceMain()
    {
        choiceMainNumver--;
        MainStatusSet();
    }

    public void UpChoiceSub()
    {
        choiceSubNumver++;
        SubStatusSet();
    }
    public void DownChoiceSub()
    {
        choiceSubNumver--;
        SubStatusSet();
    }

    public void SetWepon()
    {
        GameManager.instance.haveMainWepon.Add(allMainWepon[choiceMainNumver]);
        GameManager.instance.haveSubWepon.Add(allSubWepon[choiceSubNumver]);
        
        //GameManager.instance.SetMainWepon(allMainWepon[choiceMainNumver]);
        //GameManager.instance.SetSubWepon (allSubWepon[choiceSubNumver]);
    }

    public void MainStatusSet()
    {
        choiceMainNumver = Mathf.Clamp(choiceMainNumver, 0, allMainWepon.Length - 1);
    
        //スクリプト
        mainStatusScrpt = allMainWepon[choiceMainNumver].GetComponent<WeponStatus>();
        
        //イメージ
        mainImg.sprite           = mainStatusScrpt.get_weponImg();
        //テキスト
        mainNameText.text        = mainStatusScrpt.get_weponName();
        mainDamageText.text      = mainStatusScrpt.get_damage().ToString();
        mainRateText.text        = mainStatusScrpt.get_shootRate().ToString();
        mainMagazinSizeText.text = mainStatusScrpt.get_maxClipAmmo().ToString();
        //スライダー
        mainDamageSlider.value      = (float)mainStatusScrpt.get_damage()      / MaxDamage;
        mainRateSlider.value        = (float)mainStatusScrpt.get_shootRate()   / MaxRate;
        mainMagazinSizeSlider.value = (float)mainStatusScrpt.get_maxClipAmmo() / MaxMagazinSize;

        if (mainStatusScrpt.get_shootType())
        {
            mainTypeOfFireText.text = "Full Auto";
        }
        else
        {
            mainTypeOfFireText.text = "Semi Auto";
        }

    }
    public void SubStatusSet()
    {
    
        choiceSubNumver = Mathf.Clamp(choiceSubNumver, 0, allSubWepon.Length - 1);
        
        //スクリプト
        subStatusScrpt = allSubWepon[choiceSubNumver].GetComponent<WeponStatus>();
    
        //イメージ
        subImg.sprite           = subStatusScrpt.get_weponImg();
        //テキスト
        subNameText.text        = subStatusScrpt.get_weponName();
        subDamageText.text      = subStatusScrpt.get_damage().ToString();
        subRateText.text        = subStatusScrpt.get_shootRate().ToString();
        subMagazinSizeText.text = subStatusScrpt.get_maxClipAmmo().ToString();
        //スライダー
        subDamageSlider.value      = (float)subStatusScrpt.get_damage()      / MaxDamage;
        subRateSlider.value        = (float)subStatusScrpt.get_shootRate()   / MaxRate;
        subMagazinSizeSlider.value = (float)subStatusScrpt.get_maxClipAmmo() / MaxMagazinSize;

        if (subStatusScrpt.get_shootType())
        {
            subTypeOfFireText.text = "Full Auto";
        }
        else
        {
            subTypeOfFireText.text = "Semi Auto";
        }
    
    }

    public void ActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
    public void ActiveTrue()
    {
        this.gameObject.SetActive(true);
    }
}
