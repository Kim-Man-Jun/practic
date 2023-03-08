using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJump : MonoBehaviour
{
    public GameObject MoreJumpObject;
    public bool MJOnOff;
    public float MJOnOffDeleyTime;
    public float accumTime;
        
    void Update()
    {
        if(MJOnOff == false)
        {
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerController.jumpCount >= 1)
            {
                PlayerController.jumpCount--;
                MoreJumpObject.SetActive(false);
                MJOnOff = false;
            }

            else if (PlayerController.jumpCount == 0)
            {
                MoreJumpObject.SetActive(false);
                MJOnOff = false;
            }
        }
    }
    
    IEnumerator Respawn()
    {
        
    }
    
    //circle collider 추가 - is trigger 체크
    //prefab 처리
    //02.22 할일 morejump 체크 후 = 해냈다! 기분 너무 좋다. playercontroller에 있는 jumpcount를 public static로 전역변수 선언
    //invokerepeating을 이용한 재생성 처리까지 
    //https://allaboutmakers.tistory.com/32 게임오브텍으 온오프
}
