using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public int hp = 3;                                  //적의 체력
  public float speed = 0.5f;                          //적의 속도
  public float reactionDistance = 4.0f;               //적의 반응거리
  
  public string idleAnime = "EnemyIdle";              //적 대기모션 애니메이션
  public string upAnime = "EnemyUp";                  //적 위쪽 애니메이션
  public string downAnime = "EnemyDown";
  public string leftAnime = "EnemyLeft";
  public string rightAnime = "EnemyRight";
  public string deadAnime = "EnemyDead";              //적 뒤지는 애니메이션
  
  string nowAnimation = "";                           //현재 애니메이션
  string oldAnimation = "";                           //이전 애니메이션
  
  float axisH;                                        //가로축 값
  float axisV;                                        //세로축 값
  Rigidbody2D rbody;
  
  bool isActive = false;                              //활성화 여부
  
  public int arrangeId = 0;                           //배치 식별에 사용되는 변수
  
  void Start()
  {
    rbody = GetComponent<Rigidbody2D>();              //컴포넌트 긁어오기
  }
  
  void Update()
  {
    GameObject player = GameObject.FindGameObjectWithTag("Player");   //태그 Player 게임 오브젝트 가져오기
    if (player != null)
    {
      if (isActive)
      {
        float dx = player.transform.position.x - transform.position.x;
        float dy = player.transform.position.y - transform.position.y;
        float rad = Mathf.Atan2(dy,dx);
        float angle = rad * Mathf.Rad2Deg;
        
        if(angle > -45.0f && angle <= 45.0f)
        {
          nowAnimation = rightAnime;
        }
        else if(angle > 45.0f && angle <= 135.0f)
        {
          nowAnimation = upAnime;
        }
        else if(angle >= -135.0f && angle <= -45.0f)
        {
          nowAnimation = downAnime;
        }
        else
        {
          nowAnimation = leftAnime;
        }
        axisH = Mathf.Cos(rad) * speed;
        axisV = Mathf.Sin(rad) * speed;                                 //이동할 벡터 만들기
      }
      else
      {
        float dist = Vector2Distance(transform.position, player.transform.position);    //플레이어와의 거리 확인용
        if(dist < reactionDistance)
        {
          isActive = true;
        }
      }
    }
    else if(isActive)
    {
      isActive = false;
      rbody.velocity = Vector2.zero;
    }
  }
  
  void FixedUpdate()
  {
  
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    
  }
}
