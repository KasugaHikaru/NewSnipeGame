using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolStatus : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10.0f;         //�e��
    [SerializeField] private float shootRate = 1000.0f;         //���˃��[�g  
    [SerializeField] private float shootRateNum = 0.0f;         //���˃��[�g�m�F�p�̕ϐ�   
    [SerializeField] private int clipAmmo = 25;                 //�}�K�W�����̒e��
    [SerializeField] private int maxClipAmmo = 25;              //�ő�̃}�K�W�����̒e�� 
}
