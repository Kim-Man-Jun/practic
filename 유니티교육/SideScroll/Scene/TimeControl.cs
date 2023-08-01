using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    //카운터다운으로 시간 측정할 변수
    public bool isCountDown = true;
    //게임 최대 시간
    public float gameTime = 0;
    //bool 타이머 정지
    public bool isTimeOver = false;
    //표시 시간
    public float displayTime = 0;
    //현재 시간
    float times = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isCountDown)
        {
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeOver == false)
        {
            //시간 누적
            times += Time.deltaTime;

            if (isCountDown)
            {
                //카운트다운
                displayTime = gameTime - times;

                if (displayTime <= 0)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
            }
            else
            {
                displayTime = times;

                if (displayTime >= gameTime)
                {
                    displayTime = gameTime;
                    isTimeOver = true;
                }
            }
        }
    }
}
