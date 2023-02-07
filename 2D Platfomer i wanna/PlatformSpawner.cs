using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
  public GameObject platformPrefab;     
  //platform은 왼쪽으로 움직이는 발판을 만들고 사라지는 형식으로 몇초 버티기 스테이지를 만들거임
  public int count = 5;
  
  public float timeBetSpawnMin = 1.25f;
  public float timeBetSpawnMax = 2.25f;
  float timeBetSpawn;     //다음 배치까지 시간 간격
  
  public float yMin = -3.5f;    //배치할 위치의 최소 y값
  public float yMax = 1.5f;
  float xPos = 20f;             //배치할 위치의 x 값
  
  GameObject[] platforms;     //미리 생성한 발판들
  int currentIndex = 0;       //사용할 현재 순번의 발판
  
  Vector2 poolPosition = new Vector2(0,-25);    //초반 생성한 발판의 숨겨둔 위치
  float lastSpawnTime;                          //마지막 배치 시점
  
  void Start()
  //변수를 초기화하고 사용할 발판을 미리 생성
  {
  }
  
  void Update()
  //순서를 돌아가면서 주기적으로 발판 배치
  {
  } 
  
{
