using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  public string moveAxisName = "Vertical";      //앞뒤 움직임을 위한 변수
  public string rotateAxisName = "Horizontal";  //좌우 움직임을 위한 변수
  public string fireButtonName = "Fire1";       //발사 버튼 변수
  public string reloadButtonName = "Reload";    //재장전 버튼 변수
  
  public float move {get; private set;}         //감지된 움직임 입력값
  public float rotate {get; private set;}       //감지된 회전 입력값
  public bool fire {get; private set;}          //감지된 발사 입력값
  public bool reload {get; private set;}        //감지된 재장전 입력값
  
  private void Update()
  {
    if(GameManager.instance != null && GameManager.instance.isGameover)   //게임오버 상태에서는 사용자 입력을 감지 안함
    {
      move = 0;
      rotate = 0;
      fire = false;
      reload = false;
      return;
    }
        
    move = Input.GetAxis(moveAxisName);         //move에 대한 입력 감지
    rotae = Input.GetAxis(rotateAxisName);      //rotate에 대한 입력 감지
    fire = Input.GetAxis(fireButtonName);       //fire에 대한 입력 감지
    reload = Input.GetAxis(reloadButtonName);   //reload에 대한 입력 감지
  }
  
}
