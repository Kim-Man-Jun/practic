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
  public static GameDateManager instance;
  
  public gameObject player; 
  
  Data player = new Data(){ stage = 1, PlayerTransformX = player.transform.x, 
                            PlayerTransformY = player.transform.y}
  PlayerData nowPlayer = new PlayerData();                          

                            
  void Awake()                      //싱글톤 매서드
  {
    if(instance == null)
    {
      instance = this;
    }
    else if(instance != this)
    {
      Destroy(instance.gameObject);
    }
    
    DontDestroyOnLoad(gameObject);
  }
  
  void Start()
  {
    string jsonData = JsonUtility.ToJson(player);
  }
  
  void Update()
  {
  }
  
}
