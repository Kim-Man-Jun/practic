using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody playerRigidbody;
  public float speed = 8.0f;
  
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody>();  //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
  }
  
  void Update()
  {
    float xInput = Input.GetAxis("Horizontal"); //수평축 입력값을 xInput에 저장
    float xSpeed = xInput * speed;  //수평축 속도를 구함
    
    Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);  //Vector3 속도를 뒤의 값으로 생성
    playerRigidbody.velocity = newVelocity; //playerRigidbody.velocity 속도는 newVelocity의 값으로
  }
  
  public void Die() //자산의 게임 오브젝트를 비활성화 하는 메서드
  {
    this.gameObject.SetActive(false);
  }
}
