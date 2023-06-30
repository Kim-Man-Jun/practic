using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //어디에서나 접근 가능하도록 static 사용, 싱글톤 패턴
    public static GameManager Instance;
    public Text scoreText;
    int score = 0;

    public Text StartText;


    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void AddScore(int num)       //점수를 추가해주는 함수
    {
        score += num;
        scoreText.text = "Score : " + score;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartGame");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartGame()
    {
        int i = 3;
        while (i > 0)
        {

            StartText.text = i.ToString();
            yield return new WaitForSeconds(1);

            i--;
        }

        if (i == 0)
        {
            StartText.text = "Game Start";
            yield return new WaitForSeconds(1.5f);

            StartText.gameObject.SetActive(false);
            yield break;
        }
    }
}
