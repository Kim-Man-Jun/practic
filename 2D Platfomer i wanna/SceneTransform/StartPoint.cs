using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
  public string startPoint;
  
  void Start()
  {
    if(thePlayer == null)
    {
      thePlayer = FindObjectOfType<Player>();
    }
    if(startPoint == thePlayer.currentMapName)
    {
      thePlayer.transform.position = transform.position;
    }
  }
}
