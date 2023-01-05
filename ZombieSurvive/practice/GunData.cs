using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunData : MonoBehaviour
{
  public AudioClip shotClip;                //발사 소리
  public AudioClip reloadClip;              //재장전 소리
  
  public float damage = 25;                 //총 공격력
  
  public int startAmmoRemain = 100;         //첫 시작시 주어지는 탄알수
  public int magCapacity = 25;              //탄창 용량
  
  public float timeBetFire = 0.12f;         //탄알 발사 간격
  public float reloadTime = 1.8f;           //재장전에 걸리는 시간
}
