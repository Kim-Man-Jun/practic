using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public class PlayerData
    {
        public Vector2 PlayerTransformX;
        public Vector2 PlayerTransformY;
    }

    PlayerData nowPlayer = new PlayerData();
    string Path;
    string FileName = "Save";
    public Transform Player;

    //싱글톤 선언
    public static DataManager instance;

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
        DontDestroyOnLoad(this.gameObject);

        Path = Application.persistentDataPath + "/";
    }
    // Start is called before the first frame update
    void Start()
    {
        nowPlayer.PlayerTransformX.x = Player.transform.position.x;
        nowPlayer.PlayerTransformX.y = Player.transform.position.y;
        Debug.Log(nowPlayer.PlayerTransformX.x);
        Debug.Log(nowPlayer.PlayerTransformX.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveData()
    {
        string Data = JsonUtility.ToJson(nowPlayer);

        File.WriteAllText(Path + FileName, Data);
    }

    public void LoadData()
    {
        string Data = File.ReadAllText(Path + FileName);
        nowPlayer = JsonUtility.FromJson<PlayerData>(Data);
    }
}


/*JSON 저장하는 방법
1. 저정할 데이터가 존재
2. 데이터를 JSON으로 변환
3. JSON을 외부로 저장

JSON을 불러오는 방법
1. 외부에 저장된 JSON을 가져옴
2. JSON을 데이터 형태로 변환
3. 불러온 데이터를 이용
*/


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save1 : MonoBehaviour
{
    [SerializeField]
    public class SaveTest
    {
        public float PlayerX;
        public float PlayerY;
    }

    SaveTest test = new SaveTest();

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            test.PlayerX = Player.transform.position.x;
            test.PlayerY = Player.transform.position.y;
            Debug.Log(test.PlayerX);
            Debug.Log(test.PlayerY);
        }
    }
}


*/
