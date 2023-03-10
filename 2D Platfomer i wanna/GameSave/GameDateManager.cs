using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Data()
{
  public int stage;
  public float PlayerTransformX;
  public float PlayerTransformY;
}

public class GameDateManager : MonoBehaviour
{
  public gameObject player; 
  
  Data player = new Data(){ stage = 1, PlayerTransformX = player.transform.x, 
                            PlayerTransformY = player.transform.y}
                            

  void Start()
  {
    string jsonData = JsonUtility.ToJson(player);
  }
  
  void Update()
  {
  }
  
}
