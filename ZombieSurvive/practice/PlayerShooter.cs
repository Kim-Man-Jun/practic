using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
  public Gun gun;                                     //사용할 총 변수
  public Transform gunPivot;                          //총 배치의 기준점이 될 변수
  public Transform leftHandMount;                     //왼손이 위치할 지점
  public Transform rightHandMount;                    //오른손이 위치할 지점
  
  private PlayerInput playerInput;                    //플레이어의 입력
  private Animator playerAnimator;                    //애니메이터 컴포넌트
  
  void Start()
  {
    playerInput = GetComponent<PlayerInput>();
    playerAnimator = GetComponent<Animator>();
  }
  
  private void OnEnable()
  {
    gun.gameObject.SetActive(true);                  //슈터가 활성화될 때 총도 같이 on
  }
  
  private void OnDisable
  {
    gun.gameObject.SetActive(false);                 //슈터가 활성화될 때 총도 같이 off
  }
  
  void Update()
  {
    
  }
  
  private void UpdateUI()
  {
    if(gun != null && UIManager.instance != null)
    {
      UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);       //UI매니저 탄알 텍스트에 탄창의 탄알과 남은 탄알 표시
    }
  }
  
  private void OnAnbimatorIK(int layerIndex)
  {
    
  }
}
