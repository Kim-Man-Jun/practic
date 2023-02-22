using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJump : MonoBehaviour
{
  GameObject Player;
  
  void Start()
  {
  }
  
  void Update()
  {
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player"
    {
      if(Player.jumpCount >= 1)
      {
        Player.jumpCount--;
        Destroy(this.gameObject);
      }
      
      else if(Player.jumpCount ==0)
      {
        Player.Destroy(this.gameObject);
      }
    }
  }
  //circle collider 추가 - is trigger 체크
  //prefab 처리
}
