using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  void Update()
  {
    transform.Translate(Vector3.forward * 10.0f);
    //프레임마다 오브젝트를 정면을 향해 발사
  }
}
