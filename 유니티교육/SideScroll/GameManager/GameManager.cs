using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MainImage;
    public Sprite GameOverspr;
    public Sprite GameClearspr;
    public GameObject Panel;
    public GameObject RestartButton;
    public GameObject NextButton;
    Image TitleImage;

    //시간 제한 추가
    public GameObject TimeBar;  //시간 표시 이미지
    public GameObject TimeText; //시간 표시 첵스트
    TimeControl timeCnt;

    public GameObject scoreText;
    public static int totalScore;
    public int stageScore = 0;


    //사운드 재생
    public AudioClip clearSound;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        MainImage.SetActive(false);
        Panel.SetActive(false);

        timeCnt = GetComponent<TimeControl>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                TimeBar.SetActive(false);
            }
        }

        UpdateScore();

        PlayerPrefs.SetInt("Score", 100);
    }

    private void UpdateScore()
    {
        int score = stageScore + totalScore;
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState == "gameClear")
        {
            MainImage.SetActive(true);
            Panel.SetActive(true);
            //변수로 잡은 스프라이트 이미지 변경가능함
            Button bt = RestartButton.GetComponent<Button>();
            //버튼 UI의 누를 수 있는 기능을 끔
            bt.interactable = false;

            MainImage.GetComponent<Image>().sprite = GameClearspr;
            PlayerController.gameState = "gameEnd";

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
                int time = (int)timeCnt.displayTime;
                totalScore += time * 10;
            }

            totalScore += stageScore;
            stageScore = 0;
            UpdateScore();

            //사운드 재생
            AudioSource soundPlayer = GetComponent<AudioSource>();

            if(soundPlayer != null)
            {
                soundPlayer.Stop();
                soundPlayer.PlayOneShot(clearSound);
            }
        }

        else if (PlayerController.gameState == "gameOver")
        {
            MainImage.SetActive(true);
            Panel.SetActive(true);
            Button bt = NextButton.GetComponent<Button>();
            bt.interactable = false;
            MainImage.GetComponent<Image>().sprite = GameOverspr;
            PlayerController.gameState = "gameEnd";

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
            }

            //사운드 재생
            AudioSource soundPlayer = GetComponent<AudioSource>();

            if (soundPlayer != null)
            {
                soundPlayer.Stop();
                soundPlayer.PlayOneShot(gameOverSound);
            }
        }
        else if (PlayerController.gameState == "playing")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            PlayerController playerCnt = player.GetComponent<PlayerController>();
            //시간 제한 및 시간 갱신 추가
            if (timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    int time = (int)timeCnt.displayTime;

                    TimeText.GetComponent<Text>().text = time.ToString();

                    if (time == 0)
                    {
                        playerCnt.GameOver();
                    }
                }
            }

            if(playerCnt.Score != 0)
            {
                stageScore += playerCnt.Score;
                playerCnt.Score = 0;
                UpdateScore();
            }
        }
    }

    public void Jump()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerCnt = Player.GetComponent<PlayerController>();
        playerCnt.Jump();

    }
}
