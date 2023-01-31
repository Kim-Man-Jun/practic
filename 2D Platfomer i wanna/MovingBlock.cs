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
    if(isCanMove)                   //이동중일때
    {
      float x = transform.position.x;
      float y = transform.position.y;
      bool endX = false;
      bool endY = false;
      if(isReverse)
      {
        if((perDX >= 0.0f && x <= defPos.x) || (perDX < 0.0f && x >= defPos.x)
        //반대 방향으로 이동
        //이동량이 양수고 이동 위치가 초기 위치보다 작고나 같을 경우
        //이동량이 음수고 이동 위치가 초기 위치보다 크거가 같을 경우
        {
          endX = true;        //X방향 이동 종료
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
        //정방향 이동
        //이동량이 양수고 이동 위치가 초기 위치보다 크거나
        //이동량이 음수고 이동 위치가 초기 + 이동거리 보다 작은 경우
        {
          endX = true;        //X 방향 이동 종료
        }
        if((perDY >= 0.0f && y >= defPos.y + moveY) || (perDY < 0.0f && y <= defPos.y + moveY))
        {
          endY = true;
        }
        Vector3 v= new Vector3(perDX, perDY, defPos.z);
        transform.Translate(v);
      }
      
      if(endX && endY)          //이동 종료
      {
        if(isReverse)
        //위치가 어긋나는 것을 방지하고자 정면 방향 이동으로 돌아가기 전에 초기위치로 돌리는 메서드
        {
          transform.position = defPos;
        }
        isReverse = !isReverse;
        isCanMove = false;
        if(isMoveWhenOn == false)
        {
          Invoke("Move", weight);                   //weight만큼 지연 후 move 시작
        }
      }
    }
  }
  
  //발판 이동부분은 여러번 봐야할듯 vector고 invoke고 난리났네 이거
  
  public void Move()
  {
    isCanMove = true;                               //이동 가능하게 만들기
  }
  
  public void Stop()
  {
    isCanMove = false;                               //이동 불가능하게 만들기
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player")          // 접촉한 것이 플레이어라면 
    {
      collision.transform.SetParent(transform);       //이동 블록의 자식으로 만들어버림
      
      if(isMoveWhenOn)                                //올라갔을 때 움직일 수 있으면
      {
        isCanMove = true;                             //이동하게 만들어버림
      }
    }
  }
  
  private void OnCollisionExit2D(Collision2D collision)        //접촉 종료 했을 때
  {
    if(collision.gameObject.tag == "Player")
    {
      collision.transform.SetParent(null);                     //플레이어일 경우 이동 블록의 자식에서 아웃
  }
}
