using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
  void Start()
  {
    Rigidbody2D rbody = GetComponent<Rigidbody2D>();
    rbody.bodyType = RigidbodyType2D.Static;
  }
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      if(rbody.rbodyType == RigidbodyType2D.static)
      {
        rbody.rbodyType == RigidbodyType2D.Dynamic;
        
        Destroy(this.gameObject, 5.0f);
      }
    }
  }
}
