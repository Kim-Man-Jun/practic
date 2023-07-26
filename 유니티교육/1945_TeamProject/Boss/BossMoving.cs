using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMoving : MonoBehaviour
{
    Animator animator;
    public Vector2 PlayerVector;
    public Vector2 BossVector;

    bool aniOnoff;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerVector = player.GetComponent<Transform>().position;
        BossVector = GetComponent<Transform>().position;

        float angle = GetAngle(PlayerVector, BossVector);
        print(angle);

        if (aniOnoff == false)
        {
            if (angle > 80 && angle < 100)
            {
                animator.Play("BossIdle");
            }
            else if (angle >= -20 && angle < 80)
            {
                animator.Play("BossLeft");
            }
            else if (angle <= -145 || angle > 100)
            {
                animator.Play("BossRight");
            }
        }

        float bossnow = BossController.BossNowHp;

        if (bossnow <= 18000 && bossnow > 12000)
        {
            animator.Play("BossSpin");
        }
        else if (bossnow <= 12000 & bossnow > 6000)
        {
            animator.Play("BossSpin");
        }
        else if (bossnow <= 6000)
        {
            animator.Play("BossSpin");
        }

    }

    public static float GetAngle(Vector2 vStart, Vector2 vEnd)
    {
        Vector2 v = vEnd - vStart;          //변수 v 생성 
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;       //이거는 알아봐야함
    }
}
