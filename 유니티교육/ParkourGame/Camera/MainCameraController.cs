using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;

    public float rotationY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var state = vcam.State;

        var rotation = state.FinalOrientation;

        var euler = rotation.eulerAngles;

        rotationY = euler.y;

        var roundeRotationY = Mathf.RoundToInt(rotationY);
    }

    public Quaternion flatRotation => Quaternion.Euler(0, rotationY, 0);
}
