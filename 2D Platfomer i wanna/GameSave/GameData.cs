using System;

[Serializable]      //직렬화

public class Data
{
  void Start()
  {
    DataManager.Instance.LoadGameData();
  }
  
  void OnApplicationQuit()
  {
    DataMaanger.Instance.SaveGameData();
  }
  
}
