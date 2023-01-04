using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5.0f;        //플레이어 움직임 속도
  public float rotateSpeed = 180f;      //플레리어 좌우 회전 속도
  
  private PlayerInput playerInput;      //플레이어 입력을 알려주는 컴포넌트
  
  private Rigidbody playerRigidbody;    //플레이어 rigidbody
  private Animator playerAnimator;      //플레이어 animator
  
  private void Start()        //사용할 컴포넌트 긁어오기
  {
  }
  
  private void FixedUpdate()  //물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
  {
  }
  
  private void Move()         //입력값에 따라 캐릭을 앞뒤로 움직임
  {
  }
  
  private void Rotate()       //입력값에 따라 캐릭을 좌우로 회전
  {
  }
}
