using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
  public Gun gun;                                     //사용할 총 변수
  public Transform gunPivot;                          //총 배치의 기준점이 될 변수
  public Transform leftHandMount;                     //왼손이 위치할 지점
  public Transform rightHandMount;                    //오른손이 위치할 지점
  
  private PlayerInput playerInput;
  private Animator playerAnimator;
  
  void Start()
  {
    playerInput = GetComponent<PlayerInput>();
    playerAnimator = GetComponent<Animator>();
  }
  
  private void OnEnable()
  {
    gun.gameObject.SetActive(false);
  }
  
  void Update()
  {
    
  }
}
