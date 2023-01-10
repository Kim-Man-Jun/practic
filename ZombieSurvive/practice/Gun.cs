using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  public enum State
  {
    Ready,        //발사 준비됨
    Empty,        //탄창이 빔
    Reloading     //재장전 중
  }
  
  public State state {get; private set;}            //현재 총의 상태
  
  public Transform fireTransform;                   //탄알이 발사될 위치
  
  public ParticleSystem muzzleFlashEffect;          //머즐플래시 효과
  public ParticleSystem shellEjectEffect;           //탄피 배출 효과
  
  private LineRenderer bulletLineRenderer;          //탄알 궤적을 그리기 위한 렌더러
  
  private AudioSource gunAudioPlayer;               //총 소리 재생기
  
  public GunData gunData;                           //총의 현재 데이터
  
  private float fireDistance = 50;                  //총 사정거리
  
  public int ammoRemain = 100;                      //남은 전체 탄알
  public int magAmmo;                               //현재 탄창에 남아 있는 탄알
  
  private float lastFireTime;                       //총을 마지막으로 발사한 시점
  
  private void Awake()                              //사용할 컴포넌트 긁어오기
  {
    gunAudioPlayer = GetComponent<AudioSource>();
    bulletLineRenderer = GetComponent<LineRenderer>();

    bulletLineRenderere.positionCount = 2;          //사용할 점을 두개로 변경
    bulletLineRenderer.enabled = false;             //라인 렌더러를 비활성화
  }
  
  private void OnEnable()                           //총 상태 초기화 메서드
  {
    ammoRemain = gunData.startAmmoRemain;           //전체 예비 탄알 양을 초기화
    magAmmo = GunData.magCapacity;                  //현재 탄창을 가득 채우기
    
    state = State.Ready;
    lastFireTime = 0;
  }
  
  public void Fire()                                //총 발사 시도하는 메서드
  {
  }
  
  private void Shot()                               //실제 발사 처리 메서드
  {
  }
  
  private Ienumerator ShotEffect(Vector3 hitPosition) //발사 이펙트와 소리를 재생하고 탄알 궤적을 그림
  {
    muzzleFlashEffect.Play();                         //머즐 플래시 효과 재생
    shellEjectEffect.Play();                          //탄피 배출 효과 재생
    
    gunAudioPlayer.PlayOneShot(gunData.shotClip);     //총 쏘는 소리 재생
    
    bulletLineRenderer.SetPosition(0, fireTransform.position);    //렌더러 선 시작점은 총구의 위치
    bulletLineRenderer.SetPosition(1,hitPosition);                //선 끝점은 충돌 위치
    
    bulletLineRenderer.enabled = true;               //라인 렌더러 재생, 탄알 궤적 그리기
    
    yield return new WaitForSeconds(0.0f);           //0.03초 동안 처리를 잠깐 대기
    
    bulletLineRenderer.enabled = false;              //0.03초 후 라인 렌더러 끄기
  }
  
  public bool Reload()
  {
    return false;                                     //재장전 시도
  }
  
  private IEnumerator ReloadRoutine()                 //실제 재장전 처리를 진행
  {
    state = State.Reloading;                          //현재 상태를 재장전 중 상태로 전환
    yield return new WaitForSeconds(gunData.reloadTime);  //gunData에 있는 재장전 시간만큼 처리 쉬기
    state = State.Ready;                              //총의 현재 상태를 발사 가능한 상태로 변경
  }
  
}
