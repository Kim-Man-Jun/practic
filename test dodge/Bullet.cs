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
}
