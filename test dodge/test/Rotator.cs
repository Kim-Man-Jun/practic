using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
  public float rotationSpeed = 60f;
  
  void start()
  {
  }
  
  void Update()
  {
    transform.Rotate(0.0f, rotationSpeed, 0.0f);
  }
}
