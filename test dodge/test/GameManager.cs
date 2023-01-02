using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 관련 라이브러리
using UnityEngine.SceneManagement;  //씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
  public GameObject gameoverText;
  public Text timeText;
  public Text recordText;
  
  private float surviveTime;
  private bool isGameover;
  
  void Start()
  {
    surviveTime = 0;
    isGameover = false;
  }
  
  void Update()
  {
  }
  
  public void EndGame()
  {
  }
}
