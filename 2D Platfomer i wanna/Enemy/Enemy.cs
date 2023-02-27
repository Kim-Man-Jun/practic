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
    
  }
}
