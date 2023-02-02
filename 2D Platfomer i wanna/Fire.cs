using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
  public GameObject Bullet;
  public Transform FirePos;
  
  void Update()
  {
    if(Input.GetKeyButtonDown("fire1"))
    {
      Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
      //bullet를 FirePos.transform.position 위치에 FirePos.transform.rotation 회전값으로 복제한다
    }
  }
}
