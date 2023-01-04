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
    playInput = GetComponent<PlayerInput>();
    playerRigidbody = GetComponent<Rigidbody>();
    playerAnimator = GetComponent<Animator>();
  }
  
  private void FixedUpdate()  //물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
  {
    Move();
    Rotate();
    
    playerAnimator.SetFloat("Move", plaerInput.move);   //입력값에 따라 애니메이터의 Move 값 변경
  }
  
  private void Move()         //입력값에 따라 캐릭을 앞뒤로 움직임
  {
    Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;   //상대적으로 이동할 거리 계산
    playerRigidbody.MovePosition(playerRigidbody.position + moveDistranc);    //rigidbody를 이용해 게임 오브젝트 위치 변경
  }
  
  private void Rotate()       //입력값에 따라 캐릭을 좌우로 회전
  {
  }
}
