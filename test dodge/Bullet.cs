using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 8.0f;
  private Rigidbody bulletRigidbody;
  
  void Statr()
  {
    bulletRigidbody = GetComponent<Rigidbody>();
    bulletRigidbody.velocity = transform.forward * speed;
    
    Destroy(this.gameObject, 5.0f);
  }
  
  void OnTriggerEnter(Collider other)
  {
    if(other.tag == "Player")
    {
      PlayerController playerController = other.GetComponent<PlayerController>();
      
      if(playerController != null)  //PlayerController이 컴포넌트를 가져오는데 성공했으면
      {
        playerController.Die(); //PlayerController 컴포넌트의 die메서드 실행
      }      
    }
  }
}
