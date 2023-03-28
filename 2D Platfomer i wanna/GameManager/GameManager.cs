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
  
  public AudioClip GameOver;
  
  /*------------추가부분
  static bool isClear = false;
  
  Vector3 StartingPos;
  Quaternion StartingRotate;
  bool isStarted = false;
  
  static int stageLevel = 0;
  */------------완료
  
  void Awake()
  {
    if(instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }
  
  void Start()
  {
    StartingPos = GameObject.FindGameObjectWithTag("Start").transform.position;
    StartingRotate = GameObject.FindGameObjectWithTag("Start").transform.rotation;
    
    if(stageLevel > 0)
    {
      StartGame();  //이부분 체크해야함
    }
  }
  
  void Update()         //게임오버 상태에서 재시작 가능하게 만들기
  {
    if (isGameover && Input.GetKey(KeyCode.R))
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
  
  public void OnPlayerDead
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
  
  public static void clearGame()
  {
    isClear = true;
    
    stageLevel++;
    SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);
  }
  
}
