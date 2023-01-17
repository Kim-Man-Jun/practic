using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public float speed = 3.0f;                  //이동 속도
  public string direction = "left";           //향하는 방향
  public float range = 0.0f;                  //움직이는 범위
  Vector3 defPos;                             //시작 위치
  
  void Start()
  {
    if(direction == "right")
    {
      transform.loclaScale = new Vector2(-1, 1);  //방향이 오른쪽일때 왼쪽으로 변경
    }
    defPos = transform.position;                  //시작 위치
  }
  
  void Update()
  {
  }
  
}
