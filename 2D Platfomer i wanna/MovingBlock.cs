using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
  public float moveX = 0.0f;
  public float moveY = 0.0f;
  public float times = 0.0f;                //시간
  public float weight = 0.0f;               //정지 시간
  public bool isMoveWhenOn = false;         //올라갔을 때 움직이기
  
  public bool isCanMove = true;             //움직임 온오프
  float perDx;                              //1프레임 당 X 이동 값
  float perDy;
  Vector3 defPos;                           //초기 위치
  bool isReverse = false;                   //반전 온오프
  
  void Start()
  {
    defPos = transform.position;                    //초기 위치
    float timestep = Time.fixedDeltaTime;           //1프레임에 움직이는 시간 계산
    perDx = moveX / (1.0f / timestep * times);      //1프레임의 X 이동 값 계산
    perDY = moveY / (1.0f / timestep * times);
    
    if(isMoveWhenOn)                                //처음에는 움직이지 않고 올라가면 움직임
    {
      isCanMove = false;
    }
  }
  
  void Update()
  {
    
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
  }
  
  private void OnCollisionExit2D(Collision2D collision)
  {
  }
}
