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
            StartCoroutine(Respawn());
            MoreJumpObject.SetActive(true);
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
        yield return new WaitForSeconds(0.5f);
        MJOnOff = true;
    }
    
    //circle collider 추가 - is trigger 체크
    //prefab 처리
    //02.22 할일 morejump 체크 후 = 해냈다! 기분 너무 좋다. playercontroller에 있는 jumpcount를 public static로 전역변수 선언
    //invokerepeating을 이용한 재생성 처리까지 
    //https://allaboutmakers.tistory.com/32 게임오브젝트 온오프
    //https://novlog.tistory.com/entry/Unity-%EC%BD%94%EB%A3%A8%ED%8B%B4Coroutine-%EC%B4%9D-
    //%EC%A0%95%EB%A6%AC-feat-RPG-%ED%8F%AC%EC%85%98-%EB%94%9C%EB%A0%88%EC%9D%B4-%EC%98%88%EC%A0%9C 기본 코루틴 강의
}
