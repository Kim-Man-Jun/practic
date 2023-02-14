using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
  //카메라 스크립트 변수
  private MainCameraController cam;
  //새로운 맵으로 이동 시 카메라 최소, 최대 범위 설정
  [SerializeField] Vector2 newMinCameraBoundary;
  [SerializeField] Vector2 newMaxCameraBoundary;
  //플레이어가 새로운 맵으로 이동된 후 위치 조절하는 변수
  [SerializeField] Vector2 playerPosOffset;
  //출구 위치 조정 변수
  [SerializeField] Transform exitPos;
  
  void Awake()
  {
    cam = Camera.main.GEtComponent<MainCameraController>();
  }
  
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      cam.minCameraBoundary = new MinCameraBoundary;
      cam.maxCameraBoundary = new MaxCameraBoundary;
      
      cam.player.position = exitPos.position + (Vector3)playerPosOffset;
    }
  }
  
  //사이트 주소 https://jjong-ga.tistory.com/104 topview 형식
}
