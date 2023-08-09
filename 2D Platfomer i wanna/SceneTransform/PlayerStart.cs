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

    private void Awake()                        //싱글톤 선언과 동시에 플레이어 한개로 고정
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
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

    // Update is called once per frame
    void Update()
    {

    }
}

