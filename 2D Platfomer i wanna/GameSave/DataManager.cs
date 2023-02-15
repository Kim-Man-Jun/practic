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
  
  public void LoadGameData()                      //불러오기
  {
    string filePath = Application.persistentDataPath + "/" + GameDataFileName;
    if(File.Exists(filePath))                     //저장된 게임이 있을 경우
    {
      //저장된 파일을 읽어오고 Json을 클래스 형식으로 전환해서 할당
      string FromJsonData = File.ReadAllText(filePath);
      data = JsonUtility.FromJson<Data>(FromJsonData);
      print("불러오기 완료");
    }
  }
  
  public void SaveGameData()                        //저장하기
  {
    //클래스를 Json 형식으로 전환
    string ToJsonData = JsonUtility.ToJson(data, true);
    string filePath = Application.persistentDataPath + "/" + GameDataFileName;
    
    //이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
    File.WriteAllText(filePathm ToJsonData);
    
    print("저장 완료");
  }
}
