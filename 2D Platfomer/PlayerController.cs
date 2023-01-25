using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private bool isDead = false;
  
  private Rigidbody2D playerRigidbody;
  private float axisH = 0.0f;
  public float spped = 4.0f;
  
  public float jump = 9.0f;
  public LayerMask groundLayer;
  private bool onGround = false;  
  
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody2D>();
  }
  
  void Update()
  {
    if(isDead)
    {
      return;
    }
    
    if(Input.GetKeyDown(space) && jumpCount < 2)
    {
      jumpCount++;
      playerRigidbody.velocity = Vector2.zero;
      playerRigidbody.AddFocrce(new Vector2(0, jumpForce));
    }
    else if(Input.GetKeyDown(space) && playerRigidbody.Vector2.y > 0)
    {
      playerRigidbody.velocity = playerRigidbody.velocity * 0.8f;
    }
  }
  
  private void Die()
  {
    playerRigidbody.Velocity = Vector2.Zero;
    isDead = true;
  }
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag == "Dead" && !isDead)
    {
      Die();
    }
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.contacts[0].noraml.y > 0.7f;
    {
      isGrounded = true;
      jumpCount = 0;
    }
  }
  
  private void OncollisionExit2D(Collision2D collision)
  {
    isGrounded = false;
  }
}
