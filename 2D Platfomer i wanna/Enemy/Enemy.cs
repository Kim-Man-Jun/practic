using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float moveSpeed = 1.0f;
  
  Animator animator;
  Vector3 movement;
  int movementSet = 0;   //0 : Idle, 1 : Left, 2 : Right 
  
  void Start()
  {
    animator = gameObject.GetComponentInChildren<animator>();
    
    StartCoroutine("ChangeMovement");
  }
  
  void FixedUpdate()
  {
    Move;
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
  
}
