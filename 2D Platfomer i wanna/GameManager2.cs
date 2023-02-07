using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
  public static GameManager instance;
  
  public bool isGameover = false;
  public GameObject gameoverUI;
  
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
  
  void Update()         //게임오버 상태에서 재시작 가능하게 만들기
  {
    if (isGameover && Input.GetKey(KeyCode.R))
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
  
  public void OnPlayerDead
  {
  }
  
}
