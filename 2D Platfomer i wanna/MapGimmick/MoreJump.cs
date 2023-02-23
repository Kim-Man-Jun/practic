using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJump : MonoBehaviour
{
    public GameObject morejumpPre;
    public float Interval;
    
    void Start()
    {
        InvokeRepeating("Respawn", 0.0f, Interval);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerController.jumpCount >= 1)
            {
                PlayerController.jumpCount--;
                Destroy(this.gameObject);
            }

            else if (PlayerController.jumpCount == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
   
    private void Respawn()
    {
      if(this.gameObject = null)
      {
          Instatiate(morejumpPre, Transform MoreJump);
      }
    }

    //circle collider 추가 - is trigger 체크
    //prefab 처리
    //02.22 할일 morejump 체크 후 = 해냈다! 기분 너무 좋다. playercontroller에 있는 jumpcount를 public static로 전역변수 선언
    //이럴 경우 굳이 제일 앞에 public Playercontroller를 선언해줄 필요가 없음.
    //invokerepeating을 이용한 재생성 처리까지 
}
