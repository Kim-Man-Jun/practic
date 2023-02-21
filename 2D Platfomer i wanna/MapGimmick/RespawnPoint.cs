using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
  public GameObject MoreJump;
  public float Interval;
  
  public void Start()
  {
    if(Interval > 0)
    {
      InvokeRepeating("MoreJump", 0.0f, Interval);
    }
  }
  
  public GameObject MoreJump()
  {
    if(MoreJump != null)
    {
      return Instantiate(MoreJump, transform.position, Quaternion.identity);
    }
    
    return null;
  }
}
