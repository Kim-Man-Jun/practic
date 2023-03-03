using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
  public string startPoint;
  private Player player;
  
  void Start()
  {
    if(player == null)
    {
      player = FindObjectOfType<Player>();
    }
    
    if(startPoint == thePlayer.currentMapName)
    {
      player.transform.position = transform.position;
    }
  }
}
