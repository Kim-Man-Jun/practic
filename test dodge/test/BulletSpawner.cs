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
    
  }
}
