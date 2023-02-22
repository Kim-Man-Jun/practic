using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJump : MonoBehaviour
{
  public GameObject Player;
  
  void Start()
  {
  }
  
  void Update()
  {
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player")
    {
      if(Player.jumpCount >= 1)
      {
        Player.jumpCount--;
        Destroy(this.gameObject);
      }
      
      else if(Player.jumpCount ==0)
      {
        Destroy(this.gameObject);
      }
    }
  }
  //circle collider 추가 - is trigger 체크
  //prefab 처리
  //02.22 할일 morejump 체크 후 invokerepeating을 이용한 재생성 처리까지 
}
