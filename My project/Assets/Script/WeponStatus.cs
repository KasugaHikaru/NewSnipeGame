using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponStatus : MonoBehaviour
{
    [SerializeField] private string weponName;
    [SerializeField] private Sprite weponImg;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int   damage;              //ダメージ
    [SerializeField] private float bulletSpeed;         //弾速
    [SerializeField] private float rate;                //発射レート   
    [SerializeField] private int   magazineSize;        //最大のマガジン内の弾薬数 
    [SerializeField] private bool  shootType;           //射撃タイプ(0が単発、1がフルオート)
    [SerializeField] private float zoomFVO;
    [SerializeField] private bool  weponType;           //0サブ武器か1メイン武器か

    public string get_weponName()
    {
        return weponName;
    }
    public Sprite get_weponImg()
    {
        return weponImg;
    }
    public float get_bulletSpeed()
    {
        return bulletSpeed;
    }
    public float get_shootRate()
    {
        return rate;
    }
    public int get_maxClipAmmo()
    {
        return magazineSize;
    }
    public bool get_shootType()
    {
        return shootType;
    }
    public int get_damage()
    {
        return damage;
    }
    public float get_zoomFVO()
    {
        return zoomFVO;
    }
    public GameObject get_bulletPrefab()
    {
        return bulletPrefab;
    }
    public bool get_weponType()
    {
        return weponType;
    }
}
