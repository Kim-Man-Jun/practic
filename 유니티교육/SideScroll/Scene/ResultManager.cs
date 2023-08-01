using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public GameObject ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.GetComponent<Text>().text = GameManager.totalScore.ToString();

        PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
