using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{

  Rigidbody2D rbody;
  float axisH = 0.0f;
  public float speed = 3.0f;
  
  public float jump = 9.0f
  public LayerMask groundLayer;
  bool goJump = false;
  bool onGround = false;
  
  Animator animator;
  public string stopAnime = "PlayerStop";
  public string moveAnime = "PlayerMove";
  public string jumpAnime = "PlayerJump";
  public string goalAnime = "PlayerGoal";
  public string deadAnime = "PlayerDead";
  string nowAnime = "";
  string oldAnime = "";
  
  public static string gameState = "playing";
  
  bool isMoving = "false";
  
  void Start()
  {
    rbody = this.GetComponent<Rigidbody2D>(); //this는 자기자신을 나타내지만 생략 가능함
    animator = GetComponent<Animator>();
    nowAnime = stopAnime;
    oldAnime = stopAnime;
    gameState = "playing";
  }
  
  void Update() //수평 방향 입력 체크
  {
  
    if(gameState != "playing")
    {
      return;
    }
    
    if(isMoving == false)
    {
      axisH = Input.GetAxisRaw("Horizontal");
    }
    
    axisH = Input.GetAxisRaw("Horizontal"); //오른쪽 방향키를 누를시 1을 반환, 왼쪽 방향키를 누를시 -1을 반환
    
    if(axisH > 0.0f)  //오른쪽으로 이동
    {
      transform.localScale = new Vector2(1,1);
    }
    
    eles if(axisH < 0.0f) //왼쪽으로 이동
    {
      transform.localScale = new Vector2(-1,1);
    }
    
    if(Input.GetButtonDown("Jump")
    {
      Jump();
    }
    
  }
  
  void FixedUpdate()  //속도 갱신 메서드
  {
  
    if(gameState != "playing")
    {
      return;
    }
    onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
    //  착지 판정
    
    if(onGround || axisH != 0)
    {
      rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
    }
    
    if(onGround && goJump)
    {
      Vector2 jumpPw = new Vectro2(0, jump);  //점프를 위한 벡터 생성
      rbody.AddForce(jumpPw, ForceMode2D.Impulse);  // 순간적인 힘 가하기
      goJump = false;
    }
    
    if(onGround)
    {
      if(axisH == 0)  //지면 위일때
      {
        nowAnime = stopAnime; //stopanime 재생 둘중 하나
      }
      else
      {
        nowAnime = moveAnime; //moveanime 재생 둘중 하나
      }
     else
     {
        nowAnime = jumpAnime; //지면이 아닐 경우 jumpanime 실행
     }
     
     if(nowAnime != oldAnime)
     {
        oldAnime = nowAnime;
        animator.Play(nowAnime);
     }
    
  }

  public void Jump()
  {
    goJump = true;
  }
  
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag == "Goal")
    {
      Goal();
    }
    else if(collision.gameObject.tag == "Dead")
    {
      GameOver();
    }
    
    else if (collision.gameObject.tag == "ScoreItem")
    {
      ItemData item = collision.gameOject.GetComponent<ItemData>(); //ItemData 긁어오기
      score = item.value; //점수 얻기
      Destroy(collision.gameObject);  //아이템 제거
    }
  }
  
  public void Goal()
  {
    animator.Play(goalAnime);
    gameState = "gameclear";
    GameStop();
  }
  
  public void GameOver()
  {
    animator.Play(deadAnime);
    
    gameState = "gameover";
    GameStop(); //게임 오버 후 중지 연출 실행
    
    GetComponent<CapsuleCollider2D>().enabled = false;  //충돌 판정 비활성
    rbody.AddForce(new Vector2(0,5), ForceMode2D.Impulse); //캐릭터를 위로 튀어오르게 만드는 연출
  } 
  
  void GameStop()
  {
    Rigidbody2D rbody = getComponent<Rigidbody2D>();  //Rigidbody 2D 가져오기
    rbody.velocity = new Vector2(0,0);  //속도를 0으로 강제 
  }
  
  public void SetAxis(float h, float v)
  {
    axisH = h;
    if(axisH == 0)
    {
      isMoving = false;
    }
    else
    {
      isMoving = true;
    }
  }
}
