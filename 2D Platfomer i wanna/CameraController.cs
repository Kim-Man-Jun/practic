using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  Vector3 cameraPosition = new Vector(0, 0, -10);
  
  void FixedUpdate()
  {
    transform.position = Vector3.Lerp(transform.position, playerTransform.position + cameraPosition,
    Time.deltaTime * cameraMoveSpeed);
  }
}
