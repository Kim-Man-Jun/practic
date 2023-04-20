using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public GameObject gameoverUI;
    public GameObject gamerestartUI;

    public AudioClip GameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()         //게임오버 상태에서 재시작 가능하게 만들기
    {
        if (isGameover && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKey(KeyCode.R))        //그냥 일반 상태에서도 재시작 가능
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnPlayerDead()

    {
        isGameover = true;

        AudioSource soundPlayer = GetComponent<AudioSource>();
        
        if (soundPlayer != null)
        {
            soundPlayer.Stop();
            soundPlayer.PlayOneShot(GameOver);
        }

        gameoverUI.SetActive(true);
        gamerestartUI.SetActive(true);
    }

}
