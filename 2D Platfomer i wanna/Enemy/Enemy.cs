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
}
