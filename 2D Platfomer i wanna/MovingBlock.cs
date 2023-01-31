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
  
  void FixedUpdate()
  {
    if(isCanMove)
    {
      float x = transform.position.x;
      float y = transform.position.y;
      bool endX = false;
      bool endY = false;
      if(isReverse)
      {
        if((perDX >= 0.0f && x <= defPos.x) || (perDX < 0.0f && x >= defPos.x)
        //이동량이 양수고 이동 위치가 초기 위치보다 작고나 같을 경우
        //이동량이 음수고 이동 위치가 초기 위치보다 크거가 같을 경우
        {
          endX = true;
        }
        if((perDY >= 0.0f && y <= defPos.y) || (perDY < 0.0f && y >= defPos.y)
        {
          endY = true;
        }
        transform.Translate(new Vector3(-perDx, -perDY, defPos.z))
      }
      else
      {
        if((perDX >= 0.0f && x >= defPos.X + moveX) || (perDX < 0.0f && x <= defPos.X + moveX))
        {
          endX = true;
        }
        if((perDY >= 0.0f && y >= defPos.y + moveY) || (perDY < 0.0f && y <= defPos.y + moveY))
        {
          endY = true;
        }
        Vector3 v= new Vector3(perDX, perDY, defPos.z);
        transform.Translate(v);
      }
      
      if(endX && endY)
      {
        if(isReverse)
        {
          transform.position = defPos;
        }
        isReverse = !isReverse;
        isCanMove = false;
        if(isMoveWhenOn == false)
        {
          Invoke("Move", weight);
        }
      }
    }
  }
  
  public void Move()
  {
    isCanMove = true;
  }
  
  public void Stop()
  {
    isCanMove = false;
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player")
    {
      collision.transform.SetParent(transform);
      if(isMoveWhenOn)
      {
        isCanMove = true;
      }
    }
  }
  
  private void OnCollisionExit2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player")
    {
      collision.transform.SetParent(nul);
  }
}
