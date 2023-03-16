using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class CameraSetting : MonoBehaviour
{
    public CameraManager cameraManager;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraManager.bottomLimit -= 100.0f;
        }
    }
}
