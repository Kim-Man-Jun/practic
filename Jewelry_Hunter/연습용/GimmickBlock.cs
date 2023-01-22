using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
  public float length = 0.0f; //자동 낙하 탐지 거리용 변수 
  public bool isDelefte = false;  //낙하 후 제거할지 안할지 여부 변수
  
  bool isFell = false;  //낙하 on,off
  float fadeTime = 0.5f;  //fade out 시간 설정
  
  void Start()
  {
    Rigidbody2D rbody = GetComponent<Rigidbody2D>();  //컴포넌트 끌고오기
    rbody.bodyType = RigidbodyType2D.Static;  //rigidbodyType를 static으로 설정해 고정시켜놓음
  }
  
  void Update()
  {
    GameObject player = GamaObject.FindGameObjectWithTag("Player"); //tag : player 찾기
    if(player != null)  //플레이어가 존재할 경우
    {
      float d = Vector2.Distance(transform.position, player.transform.position);  //플레이어와의 거리 계산
      if(length >= d)
      {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        if(rbody.bodyType == RigidbodyType2D.Static)  //오브젝트가 고정 상태일때
        {
          rbody.bodyType = RigidbodyType2D.Dynamic; //일정 거리에 진입시 static에서 dynamic으로 변경해 움직일수 있게 만듦
        }
      }
    }
    if(isFell)  //낙하, 투명도를 변경해 페이드아웃 효과를 주기 시작
    {
      fadeTime -= Time.deltaTime; //이전 프레임과의 차이만큼 시간 차감
      Color col = GetComponent<SpriteRenderer>().color; //spriterenderer를 가져와 색조정을 시작
      col.a = fadeTime; //투명도 변경
      GetComponent<SpriteRenderer>().color = col; //컬러 값을 재설정
      if(fadeTime<=0.0f)
      {
        Destroy(this.gameObject); //fadeTime이 0이나 0이하가 될 경우 이 오브젝트를 파괴함
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
