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
    if(state == State.Ready && Time.time >= lastFireTime + gunData.timeBetFire)     //현재 발사 가능 상태 and 마지막 발사에서 timeBetFire 시간이 지남
    {
      lastFireTime = Time.time;                 //마지막 총 발사 시점 갱신
      Shot();                                   //Shot 메서드 실행
    }
  }
  
  private void Shot()                               //실제 발사 처리 메서드
  {
    RaycastHIt hit;                                 //레이캐스트에 의한 충돌 정보를 저장하는 변수
    Vector3 hitPosition = Vector3.zero;             //탄알이 맞은 곳을 저장할 변수
    
    if(Physics.Raycast(fireTransform.posijtion, fireTrasnform.forward, out hit, fireDistance))    //시작 지점, 방향, 충돌 정보 변수, 사정거리
    {
      IDamageable target = hit.collider.GetComponent<IDamagealbe>();          //레이가 충돌할 때, 충돌한 상대방으로부터 IDamageable 오브젝트 가져오기
      if(target != null)                                                      //가져오기 성공했을 경우
      {
        target.OnDamage(gunDAta.damage, hit.point, hit.normal);               //상대방의 OnDamage 함수를 실행해 상대방에 데미지 주기
      }
      hitPosition = hit.point;                                                //레이가 충돌한 위치를 저장
    }
    else                                                                      //레이가 충돌을 안했을때
    {
      hitPosition = fireTransform.position + fireTransform.forward * fireDistance;      //탄알의 최대 사정거리를 충돌 위치로 사용
    }
    
    StartCoroutine(ShotEffect(hitPosition));                                  //발사 이펙트 재생 시작
    
    magAmmo--;                                                                //남은 탄알 수를 -1 처리
    if(magAmmo <= 0)                                                          //남은 탄알 수가 0 이하일때
    {
      state = State.Empty;                                                    //상태를 Empty로 갱신함
    }
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
