using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
  public Vector3 position;
  public float leftlimit;
  public float rightlimit;
  public float toplimit;
  public float bottomlimit;
  
  public bool leftrightmoving;
  public bool topbottommoving;
  
  void Start()
  {
    position = transform.position;
  }
  
  void Update()
  {
    if(leftrightmoving == false && topbottommoving == false)
    {
      return();
    }
    else if(leftrightmoving == true && topbottommoving == false)
    {
    
    }
    else if(leftrightmoving == false && topbottommoving == true)
    {
    
    }
  }
}