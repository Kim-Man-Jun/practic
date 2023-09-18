using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMoving : MonoBehaviour
{
    [Header("Moving State")]
    public float bossMovingSpeed = 10f;
    public float bossRemainTime = 1f;
    private bool bossMovingOnOff = true;

    // Start is called before the first frame update
    void Start()
    {
        //보스 움직임
        StartCoroutine(BossMoving());
    }

    // Update is called once per frame
    void Update()
    {
        //보스 움직임 관련
        //아래로 움직이기
        if (bossMovingOnOff == false)
        {
            transform.Translate(0, -bossMovingSpeed * Time.deltaTime, 0);
        }
        //위로 움직이기
        else if (bossMovingOnOff == true)
        {
            transform.Translate(0, bossMovingSpeed * Time.deltaTime, 0);
        }
    }

    //보스 움직임 코루틴
    IEnumerator BossMoving()
    {
        if (bossMovingOnOff == false)
        {
            bossMovingOnOff = true;
        }

        else if (bossMovingOnOff == true)
        {
            bossMovingOnOff = false;
        }

        yield return new WaitForSeconds(bossRemainTime);
        StartCoroutine(BossMoving());
    }
}
