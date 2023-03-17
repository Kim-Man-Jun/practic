using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class CameraAdjustment : MonoBehaviour
{
    public CameraManager cameraManager;
    
    public float leftLimitadjust;
    public float rightLimitadjust;
    public float topLimitadjust;
    public float bottomLimitadjust;
    
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraManager.leftLimit = leftLimitadjust;
            cameraManager.rightLimit = rightLimitadjust;
            cameraManager.topLimit = topLimitadjust;
            cameraManager.bottomLimit = bottomLimitadjust;

        }
    }
}
