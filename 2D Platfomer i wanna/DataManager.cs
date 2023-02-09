using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
  static GameObject container;
  //싱글톤
  static DataManager instance;
  public static DataManager Instance
  {
    get
    {
      if(!instance)
      {
        container = new GameObject();
        container.name = "DataManager";
        instance = container.AddComponent(typeof(DataManager)) as DataManager;
        DontDestroyOnLoad(container);
      }
      return instance;
    }
  }
  
  string GameDataFileName = "GameData.json";      //게임 데이터 파일 이름 설정, "원하는 이름(영문으로).json"
  public Data date = new Data();                  //저장용 클래스 변수
  
  
}
