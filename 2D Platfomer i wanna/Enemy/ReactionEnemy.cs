using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionEnemy : MonoBehaviour
{
  public float moveSpeed = 1.0f;
  
  Animator animator;
  Vector3 movement;
  int movementSet = 0;   //0 : Idle, 1 : Left, 2 : Right 
  
  GameObject traceTarget;
  
  bool isTracing = false;
  
  string dist = "";
    
  void Start()
  {
    animator = gameObject.GetComponentInChildren<animator>();
    
    StartCoroutine("ChangeMovement");
  }
  
  void FixedUpdate()
  {
    Move();
  }
  
  void Move()
  {
    Vetor3 moveVelocity = Vector3.zero;
    
    if(movementSet == 1)
    {
      moveVelocity = Vector3.left;
      transform.localScale = new Vectro3(1, 1, 1);
    }
    
    if(movementSet == 2)
    {
      moveVelocity = Vector3.Right;
      transform.localScale = new Vectro3(-1, 1, 1);
    }
    
    transform.position += moveVelocity * moveSpeed * Time.deltaTime;
  }
  
  IEnumerator ChangeMovement()
  {
    movementSet = Random.Range(0, 3);   //이럴 경우 랜덤 숫자는 0에서 3 미만까지, 즉 0, 1, 2가 나온다. 한도에서 +1 하는거 잊지말것
    
    if(movementSet == 0)
    {
      animator.SetBool("isMoving", false);
    }
    else
    {
      animator.SetBool("isMoving", true);
    }
    
    yield return new WaitForSeconds(2.0f);
    
    StartCoroutine("ChangeMovement");
  }
  //코루틴 설명 : yield는 반복 함수의 탈출 시점. new WaitForSeconds를 통해 딜레이 시간을 정해줌.
  //2초 동안 랜덤으로 설정된 movement에서 나온 값을 기반으로 행동하게 됨
  //그 후 yield 밑에 코루틴을 재시작 함으로써  계속 반복하게 만든다.
  
  private void OnTriggerEnter2D(collider2D other)   //일단 리액션용 몹을 만들고 서클 콜라이더를 범위만큼 설정한 다음 
  {
    if(other.gameObject.tag == "Player")
    {
      traceTarget = other.gameObject;
      StopCoroutine ("ChangeMovemnet");
    }
  }
  
  private void OnTriggerStay2D (Collider2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      isTracing = true;
      animator.SetBool ("isMoving", true);
    }
  }
  
  private void OnTriggerEXit2D(collider2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      isTracing = false;
      StartCoroutine("ChangeMovement");   //플레이어가 나갔을 경우 일반 코루틴을 실행하도록 메서드 설정
    }
  }
  
  void isTracing()
  {
    Vectro3 playerPos = traceTarget.transform.position;
    
    if(playerPos.x < transform.position.x)
    {
      dist = "Left";
    }
    else if(playerPos.x > transform.position.x)
    {
      dist = "Right";
    }
    
    else
    {
      if(movementSet == 1)
      {
        dist = "Left";
      }
      else if(movementSet == 2)
      {
        dist = "Right";
      }
    }
    
    if(dist == "Left")
    {
      moveVelocity = Vector3.left;
      trnaform.localScale = new Vector3(1, 1, 1);
    }
    else if(dist == "Right")
    {
      moveVelocity = Vector3.right;
      trnaform.localScale = new Vector3(-1, 1, 1);
    }
  }
}
