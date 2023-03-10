using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


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
  string path;
  string filename = "save";


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
    
    path = Application.persistentDataPath + "/"; 
  }
  
  void SaveData()
  {
    string Data = JsonUtility.ToJson(nowPlayer);
    File.WriteeAllText(path + filename, data);
  }
  
  void LoadData()
  {
    string Data = File.ReadAllText(path + filename);
    nowPlayer = JsonUtility.FromJson<PlayerData>(data);
  }
  
}
