using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.SceneManagement;

public class PlayerStart : MonoBehaviour
{
    PlayerController player;

    static PlayerStart Instance;

    private void Awake()                        
    {
        //싱글톤 선언과 동시에 플레이어 한개로 고정
        //if (Instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //Instance = this;
        //DontDestroyOnLoad(gameObject);

        Vector3 pos = this.gameObject.transform.position;
        player = FindObjectOfType<PlayerController>();

        if (player != null)
        {
            if (DataManager.StageFirst == false)
            {
                player.transform.position = pos;
            }
        }
    }

    private void Start()
    {

    }

    //private void OnEnable()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    Vector3 pos = this.gameObject.transform.position;
    //    player = FindObjectOfType<PlayerController>();

    //    if (player != null)
    //    {
    //        if (DataManager.StageFirst == false)
    //        {
    //            player.transform.position = pos;
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {

    }

    //public void PlayerStartPos(int stagenum)
    //{
    //    if(stagenum == 1)
    //    {
    //        transform.position = new Vector3(-29.3f, -6.47f, 0);
    //        return;
    //    }
    //    else if (stagenum == 2)
    //    {
    //        transform.position = new Vector3(-18.17f, -6.32f, 0);
    //        return;
    //    }
    //    else if (stagenum == 3)
    //    {
    //        return;
    //    }
    //}
}

