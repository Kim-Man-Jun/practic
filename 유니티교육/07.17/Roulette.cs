using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class roulette : MonoBehaviour
{
    public float maxSpeed = 50f;

    float Speed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Speed = Speed * 0.98f;
        transform.Rotate(0, 0, Speed);
    }

    private void OnMouseDown()      //마우스로 터치되면
    {
        Speed = maxSpeed;
    }
}
