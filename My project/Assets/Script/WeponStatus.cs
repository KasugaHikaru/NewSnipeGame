using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponStatus : MonoBehaviour
{
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int   damage;              //ダメージ
    [SerializeField] private float bulletSpeed;         //弾速
    [SerializeField] private float shootRate;           //発射レート   
    [SerializeField] private int   maxClipAmmo;         //最大のマガジン内の弾薬数 
    [SerializeField] private bool  shootType;           //射撃タイプ(1が単発、0がフルオート)

    public float get_bulletSpeed()
    {
        return bulletSpeed;
    }
    public float get_shootRate()
    {
        return shootRate;
    }
    public int get_maxClipAmmo()
    {
        return maxClipAmmo;
    }
    public bool get_shootType()
    {
        return shootType;
    }
    public int get_damage()
    {
        return damage;
    }
    public GameObject get_bulletPrefab()
    {
        return bulletPrefab;
    }
}
