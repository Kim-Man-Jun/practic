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
  
  /*------------추가부분
  
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
    gameoverUI.SetActive(true);
  }
  
}
