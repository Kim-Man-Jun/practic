using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    bool isBulletTime;
    
    void Start()
    {
      isBulletTime = false;
    }

    void Update()
    {
      if(Input.GetMouseButton(1) && isBulletTime = false)   //마우스 오른쪽 버튼을 누르고 있을때
      {
        Time.timeScale = 0.5f;
        isBulletTime = true;
      }
      
      if(Input.GetMouseButtonUp(1) && isBulletTime = true)
      {
        Time.timeScale = 1.0f;
        isBulletTime = false;
      }
    }
}

//참고주소 https://luv-n-interest.tistory.com/952
//위에 누르고 있을때 화면이 살짝 어두워지는 효과도 추가해야할 듯
//씬 전체를 어둡게 한 다음에 플레이어에 달아놓은 광원을 on/off 하는 방식이면 어떨까?
//색깔은 (180, 180, 180)으로 한 다음에 플레이어한테는 (255, 255, 255) 달아주기
