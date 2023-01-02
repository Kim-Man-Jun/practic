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
    if(!isGameover)
    {
      surviveTime += Time.deltatime;  //생존 시간 갱신(deltatime)
      timeText.text = "Time : " + (int) surviveTime;  //갱신한 시간을 timeText를 이용해 표시
    }
    else
    {
    if(Input.GetKeyDown(KeyCode.R)
    {
      SceneManager.LoadScene("SampleScene")
    }
  }
  
  public void EndGame()
  {
  }
}
