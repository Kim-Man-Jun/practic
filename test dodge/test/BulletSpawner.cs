using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
  public GameObject BulletPrefab; //생성할 bullet prefab
  public float SpawnRateMin = 0.5f;
  public float SpawnRateMax = 3.0f;
  
  private Transform target; //발사할 대상
  private float spawnRate;  //생성주기
  private float timeAfterSpawn; //스폰 후 지난 시간
  
  void Start()
  {
    timeAfterSpawn = 0.0f;  //스폰 후 지난 시간을 계속 0으로 초기화 
    spawnRate = Random.Range(spawnRateMin, SpawnRateMax); //spawnrate를 최소, 최대값 사이 랜덤값으로 
    target = FindObjectOfType<PlayerController>().transform;  //playercontroller을 조준 대상으로
  }
  
  void Update()
  {
    timeAfterSpawn += Time.deltaTime;
    
    if(timeAfterSpawn >= spawnRate)
    {
      timeAfterSpawn = 0.0f;
      
      GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
      bullet.transform.LookAt(target);
      spawnRate = Random.Range(spawnRateMin, spwanRateMax);
    }
  }
}
