using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameManager instance; // 싱글턴을 할당할 전역 변수
  
  public bool isGameover = false; // 게임오버 on/off
  public Text scoreText;
  public GameObject gameoverUI;
  
  private int score = 0;
  
  void Awake()    //싱글턴 구성함과 동시에 싱글턴이 하나인지 아닌지 체크함
  {
    if(instance == null)
    {
      instance = this;
    }
  }
  else
  {
    Destroy(gameObject);
  }
  
  void Update()   //재시작 가능하게
  {
    if(isGameover && Input.GetMounseButtonDown(0) //마우스 왼쪽 버튼 누르면 재시작 처리
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
  
  public void AddScore(int newScore)    //점수 증가용
  {
    if(!isGameover)
    {
      score += newScore;
      scoreText.text = "Score : " + score;
    }
  }
  
  public void OnPlayerDead()
  {
    isGameover = true;
    gameoverUI.SetActive(true);
  }
    
}


  
