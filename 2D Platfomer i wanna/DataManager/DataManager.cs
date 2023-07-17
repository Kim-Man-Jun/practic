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
        string Data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(Path + FileName, Data);
        print(Data);
        print("저장 완료");
    }

    public void LoadData()
    {
        if (File.Exists(Path + FileName))
        {
            string LoadData = File.ReadAllText(Path + FileName);
            nowPlayer = JsonUtility.FromJson<PlayerData>(LoadData);

            thePlayer = FindObjectOfType<PlayerController>();

            thePlayer.transform.position = nowPlayer.PlayerSavePos;
            thePlayer.transform.eulerAngles = nowPlayer.PlayerSaveRot;

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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            thePlayer = FindObjectOfType<PlayerController>();

            nowPlayer.PlayerSavePos = thePlayer.transform.position;
            nowPlayer.PlayerSaveRot = thePlayer.transform.rotation.eulerAngles;

            SaveData();
        }
    }
}
