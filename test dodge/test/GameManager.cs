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
      SceneManager.LoadScene("SampleScene") //r키를 누를 경우 sampleScene를 불러옴
    }
  }
  
  public void EndGame()
  {
    isGameover = true;
    gameoverText.SetActive(true);
    
    float bestTime = PlayerPrefs.GetFloat("BestTime");
    
    if(surviveTime > bestTime)  //surviveTime이 bestTime보다 클 경우
    {
      bestTime = surviveTime; //베스트타임을 변경
      PlayerPrefs.SetFloat("BestTime", bestTime); //변경된 베스트타임을 BestTime 키로 저장함
    }
    
    recordText.text = "Best Time : " + (int) bestTime;
  }
}
