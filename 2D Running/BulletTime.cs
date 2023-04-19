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
      if(Input.GetMouseButton(1))   //마우스 오른쪽 버튼을 누르고 있을때
      {
        Time.timeScale = 0.5f;
      }
      
      if(Input.GetMouseButtonUp(1)
      {
        Time.timeScale = 1.0f;
      }
    }
}

//참고주소 https://luv-n-interest.tistory.com/952
//위에 누르고 있을때 화면이 살짝 어두워지는 효과도 추가해야할 듯
