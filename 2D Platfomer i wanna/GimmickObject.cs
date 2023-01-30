using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickObject : MonoBehaviour
{
  public float length = 0.0f;     //자동 낙하 탐지 거리
  public bool isDelete = false;   //낙하 후 제거 여부
  
  bool isFell = false;            //낙하 온오프
  float fadeTime = 0.5f;          //사라질때 fadeout 시간
  
  void start()
  {
  }
  
  void Update()
  {
  }
}
