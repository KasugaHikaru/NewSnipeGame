using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponStatus : MonoBehaviour
{
    [SerializeField] private string weponName;
    [SerializeField] private Sprite weponImg;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int   damage;              //�_���[�W
    [SerializeField] private float bulletSpeed;         //�e��
    [SerializeField] private float rate;                //���˃��[�g   
    [SerializeField] private int   magazineSize;        //�ő�̃}�K�W�����̒e�� 
    [SerializeField] private bool  shootType;           //�ˌ��^�C�v(0���P���A1���t���I�[�g)
    [SerializeField] private float zoomFVO;
    [SerializeField] private bool  weponType;           //0�T�u���킩1���C�����킩

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
