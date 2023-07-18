using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using Unity.Mathematics;

public class PlayerData                         //저장되는 플레이어 위치값, 회전값
{
    public Vector3 PlayerSavePos;
    public Vector3 PlayerSaveRot;
}

public class DataManager : MonoBehaviour
{
    public PlayerData nowPlayer = new PlayerData();     //객체값 가져오기

    string Path;                                        //저장할 폴더 경로
    string FileName = "/SaveFile.txt";                  //저장 파일 이름

    public static DataManager instance;                 //싱글톤 선언

    private PlayerController thePlayer;                 //플레리어 위치, 회전값을 가져오기 위해 선언

    private void Awake()                        //싱글톤 기본
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Path = Application.dataPath + "/Save/";         //경로 선언

        if (!Directory.Exists(Path))                    //해당 경로에 파일이 존재하지 않는다면
        {
            Directory.CreateDirectory(Path);            //폴더를 생성
        }
    }

    public void SaveData()
    {
        string Data = JsonUtility.ToJson(nowPlayer);    //제이슨화
        File.WriteAllText(Path + FileName, Data);
        print(Data);
        print("저장 완료");
    }

    public void LoadData()
    {
        if (File.Exists(Path + FileName))               //세이브 파일이 있을 경우
        {
            string LoadData = File.ReadAllText(Path + FileName);        //세이브 시 했던 제이슨화의 역순
            nowPlayer = JsonUtility.FromJson<PlayerData>(LoadData);

            thePlayer = FindObjectOfType<PlayerController>();           //플레이어 위치값 회전값 찾기 위한 변수 생성

            thePlayer.transform.position = nowPlayer.PlayerSavePos;     //세이브 위치값을 현재 위치값으로 덮기
            thePlayer.transform.eulerAngles = nowPlayer.PlayerSaveRot;

            thePlayer.isDead = false;
            thePlayer.GetComponent<CapsuleCollider2D>().enabled = true;
            thePlayer.GetComponent<BoxCollider2D>().enabled = true;
            PlayerController.jumpCount = 1;                              //static 변수를 가져오려면 클래스명을 써주면 된다.
            

            print(LoadData);
            print("불러오기 완료");
        }
        else
        {
            print("파일이 없어용");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))                  //아이워너 세이브기 때문에 총알 맞을 경우
        {
            thePlayer = FindObjectOfType<PlayerController>();           //변수 생성

            nowPlayer.PlayerSavePos = thePlayer.transform.position;     //현재 플레이어 위치는 세이브 위치값으로
            nowPlayer.PlayerSaveRot = thePlayer.transform.rotation.eulerAngles;

            SaveData();
        }
    }
}
