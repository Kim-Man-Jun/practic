using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public Vector3 PlayerSavePos;
    public Vector3 PlayerSaveRot;
}

public class DataManager : MonoBehaviour
{
    public PlayerData nowPlayer = new PlayerData();
    public SaveManager SaveManager;

    string Path;
    string FileName = "/SaveFile.txt";

    //싱글톤 선언
    public static DataManager instance;

    public GameObject Player;

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

        Path = Application.persistentDataPath + "/";
    }
    // Start is called before the first frame update
    void Start()
    {
        Path = Application.dataPath + "/Save/";
        if (!Directory.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }
    }

    public void SaveData()
    {
        nowPlayer.PlayerSavePos = SaveManager.PlayerNowPos;
        nowPlayer.PlayerSaveRot = SaveManager.PlayerNowRot;

        string Data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(Path + FileName, Data);
        print(Data);
    }

    public void LoadData()
    {
        string LoadData = File.ReadAllText(Path + FileName);
        nowPlayer = JsonUtility.FromJson<PlayerData>(LoadData);

        nowPlayer.PlayerSavePos = SaveManager.PlayerNowPos;
        nowPlayer.PlayerSaveRot = SaveManager.PlayerNowRot;

        Player.transform.position = nowPlayer.PlayerSavePos;
        //Player.transform.rotation = nowPlayer.PlayerSaveRot;

        print(LoadData);
    }
}
