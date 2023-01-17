using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public GameObject mainImage;
  public Sprite gameOverSpr;
  public Sprite gameClearSpr;
  public GameObject panel;
  public GameObject restartButton;
  public GameObject nextButton;
  
  Image titleImage;
  
  public GameObject timeBar;
  public GameObject timeText;
  TimeController timeCnt;
  
  public GameObject scoreText;
  public static int totalScore;
  public int stageScore = 0;
  
  public AudioClip meGameOver;
  public AudioClip meGameClear;
  
  public GameObject inputUi;
  
  void Start()
  {
    Invoke("InactiveImage", 1.0f);
    panel.SetActive(false);
    
    timeCnt = GetComponent<TimeController>();
    if(timeCnt != null)
    {
      if(timeCnt.gameTime == 0.0f)
      {
        timeBar.SetActive(false);
      }
    }
    
    UpdateScore();
  }
  
  void Update()
  {
    if(PlayerController.gameState == "gameclear")
    {
      mainImage.SetActive(ture);
      panel.SetActive(true);
      Button bt = restartButton.GetComponent<Button>(); //restart button을 불러서
      bt.interactable = false;  //restart button을 비활성화 처리
      mainImage.GetComponent<Image>().sprite = gameClearSpr;
      PlayerController.gameState = "gameend";
      
      if(timeCnt != null)
      {
        timeCnt.isTimeOver = true;
        int time = (int)timeCnt.displayTime;
        totalScore += time * 10;
      }
      
      totalScore += stageScore;
      stageScore = 0;
      UpdateScore();
      
      AudioSource soundPlayer = GetComponent<AudioSource>();
      if(soundPlayer != null)
      {
        soudPlayer.Stop();
        spundPlayer.PlayOneShot(meGameClear);
      }
      
      inputUI.SetActive(false);
    }
    else if(PlayerController.gameState == "gameover")
    {
      mainImage.SetActive(ture);
      panel.SetActive(true);
      Button bt = nextButton.GetComponent<Button>();  //next button을 불러서
      bt.interactable = false;  //next button을 비활성화 처리
      mainImage.GetComponent<Image>().sprite = gameOverSpr;
      PlayerController.gameState = "gameend";
      
      if(timeCnt != null)
      {
        timeCnt.isTimeOver = true;  //시간 카운트 중지
      }
      
      AudioSource soundPlayer = GetComponent<AudioSource>();
      if(soundPlayer != null)
      {
        soudPlayer.Stop();
        spundPlayer.PlayOneShot(meGameOver);
      }
      
      inputUI.SetActive(false);
    }
    else if (PlayerController.gameState == "playing")
    {
      GameObject player = GameObject.FindGameObjectWithTag("Player")
      PlayerController playerCnt = player.GetComponent<PlayerController>();
      if(timeCnt != null)
      {
        if(timeCnt.gameTime > 0.0f)
        {
          int time = (int)timeCnt.displayTime;  //int형 자료로 정의함으로써 정수 외 소숫점을 버림
          timeText.GetComponent<Text>().text = time.ToString();
          if(time == 0)
          {
            PlayerCnt.GameOver();
          }
        }
      }
      
      if(playerCnt.score != 0)
      {
        stageScore += playerCnt.score;
        playerCnt.score = 0;
        UpdateScore();
      }
    }
  }
  
  void InactiveImage()
  {
    mainImage.SetActive(false);
  }
  
  void UpdateScore()
  {
    int score = stageScore + totalScore;
    scoreText.GetComponent<Text>().text = score.ToString();
  }
  
  public void Jump()
  {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    PlayerController playerCnt = player.GetComponent<PlayerController>();
    playerCnt.Jump();
  }
}
