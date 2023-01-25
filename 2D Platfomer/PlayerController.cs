using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  
  private Rigidbody2D playerRigidbody;
  private float axisH = 0.0f;
  public float speed = 4.0f;
  
  public float jump = 9.0f;
  public LayerMask groundLayer;
  private bool onGround = false;  
  private bool goJump = false;
  
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody2D>();
  }
  
  void Update()
  {
    axisH = Input.GetAxisRaw("Horizontal");
    if(axisH > 0.0f)
    {
      transform.localScale = new Vector2(1,1);
    }
    else if(axisH < 0.0f)
    {
      transform.localScale = new Vector2(-1,1);
    }
    
    if(Input.GetButtonDwon("Jump"))
    {
      Jump();
    }
  }
  
  public Jump();
  {
    goJump = true;
  }
  
  void FixedUpdate()
  {
    onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
    if(onGround || axisH != 0)  //지면 위 또는 속도가 0이 아닐때
    {
      playerRigidbody.velocity = new Vector2(axisH * speed, playerRigidbody.velocity.y);
    }
    if(onGround && goJump)
    {
      Vector2 jumpPw = new Vector2(0, jump);
      playerRigidbody.AddForce(jumpPw, ForceMode2D.Impulse);
      goJump = false;
    }
  }

}
