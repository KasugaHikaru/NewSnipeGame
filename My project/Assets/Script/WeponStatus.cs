using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponStatus : MonoBehaviour
{
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int   damage;              //�_���[�W
    [SerializeField] private float bulletSpeed;         //�e��
    [SerializeField] private float shootRate;           //���˃��[�g   
    [SerializeField] private int   maxClipAmmo;         //�ő�̃}�K�W�����̒e�� 
    [SerializeField] private bool  shootType;           //�ˌ��^�C�v(1���P���A0���t���I�[�g)

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
