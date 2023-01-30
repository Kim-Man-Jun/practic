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
    Rigidbody2D rbody = GetComponent<Rigidbody2D>();
    rbody.bodyType = RigidbodyType2D.Static;            //물리 현상 고정
  }
  
  void Update()
  {
    GameObject player=GameObject.FindGameObjectWithTag("Player");
    if(player != null)
    {
      float d = Vectro2.Distance(transform.position, player.transform.position);      //플레이어와의 거리 계산
      if(length >= d)         //위 계산한 거리가 탐지 거리보다 작거나 같을 경우에
      {
        Rigidbody rbody = GetComponent<Rigidbody2D>();
        if(rbody.bodyType = RigidbodyType2D.Static)
        {
          rbody.bodyType = RigidbodyType2D.Dynamic;     //물리 현상 고정 해제
        }
      }
    }
    
    if(isFell)
    {
      fadeTime -= Time.deltaTime;
      Color col = GetComponent<SpriteRenderer>().color;   //컬러값을 가져옴
      col.a = fadeTime;                                   //투명도 변경
      GetComponent<SpriteRenderer>().color = col;         //컬러값 재설정
      if(fadeTime <= 0.0f)                                //fadeTime이 0보다 작아졌을때
      {
        Destroy(gameObject);                              //이 오브젝트를 없애버림
      }
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision)
  {
    if(isDelete)
    {
      isFell = true;
    }
  }
}
