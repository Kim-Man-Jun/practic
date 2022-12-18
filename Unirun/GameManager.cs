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

    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeCnt;         //변수 선언

    public GameObject scoreText;
    public static int totalScore;
    public int stageScore = 0;

    public AudioClip meGameOver;
    public AudioClip meGameClear;

    public GameObject inputUI;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InactiveImage", 1.0f);  //이미지 숨기기
        panel.SetActive(false); //패널 숨기기

        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                timeBar.SetActive(false);
            }
        }
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState == "gameclear")     //게임 클리어 시 실행되는 동작
        {
            mainImage.SetActive(true);  //이미지 표시
            panel.SetActive(true);  //패널 이미지 표시
            Button bt = restartButton.GetComponent<Button>();       //버튼 변수 생성 및 리스타트 버튼 무효화
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClearSpr;
            PlayerController.gameState = "gameend";

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;

                //점수 추가
                int time = (int)timeCnt.displayTime;
                totalScore += time * 10;
            }

            totalScore += stageScore;
            stageScore = 0;
            UpdateScore();

            AudioSource soundPlayer = GetComponent<AudioSource>();

            if (soundPlayer != null)
            {
                soundPlayer.Stop();
                soundPlayer.PlayOneShot(meGameClear);
            }

            inputUI.SetActive(false);
        }


        else if (PlayerController.gameState == "gameover")       //게임 오버 시 실행되는 동작
        {
            mainImage.SetActive(true);
            panel.SetActive(true);
            Button bt = nextButton.GetComponent<Button>();       //버튼 변수 생성 및 next 버튼 무효화
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOverSpr;
            PlayerController.gameState = "gameend";

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
            }

            AudioSource soundPlayer = GetComponent<AudioSource>();
            if (soundPlayer != null)
            {
                soundPlayer.Stop();
                soundPlayer.PlayOneShot(meGameOver);
            }

            inputUI.SetActive(false);
        }

        else if (PlayerController.gameState == "playing")        //게임중
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerCnt = player.GetComponent<PlayerController>();
            if (timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    int time = (int)timeCnt.displayTime;
                    timeText.GetComponent<Text>().text = time.ToString();

                    if (time == 0)
                    {
                        playerCnt.GameOver();
                    }
                }
            }

            if (playerCnt.score != 0)
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
