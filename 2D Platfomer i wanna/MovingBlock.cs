using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
  public float moveX = 0.0f;
  public float moveY = 0.0f;
  public float times = 0.0f;
  public float weight = 0.0f;
  public bool isMoveWhenOn = false;
  
  public bool isCanMove = true;
  float perDx;
  float perDy;
  Vector3 defPos;
  bool isReverse = false;
  
  void Start()
  {
  }
  
  void Update()
  {
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
  }
  
  private void OnCollisionExit2D(Collision2D collision)
  {
  }
}
