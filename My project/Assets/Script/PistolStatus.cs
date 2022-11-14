using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolStatus : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10.0f;         //弾速
    [SerializeField] private float shootRate = 1000.0f;         //発射レート  
    [SerializeField] private float shootRateNum = 0.0f;         //発射レート確認用の変数   
    [SerializeField] private int clipAmmo = 25;                 //マガジン内の弾薬数
    [SerializeField] private int maxClipAmmo = 25;              //最大のマガジン内の弾薬数 
}
