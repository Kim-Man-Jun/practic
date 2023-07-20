using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJump : MonoBehaviour
{
    public GameObject MoreJumpObject;
    public bool MJOnOff;
    public float MJOnOffDeleyTime;


    void Start()
    {
        if (MJOnOff == false)
        {
            InvokeRepeating("Respawn", 0.0f, MJOnOffDeleyTime);
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerController.jumpCount == 1)
            {
                PlayerController.jumpCount = 1;
                MoreJumpObject.SetActive(false);
                MJOnOff = false;
            }

            if (PlayerController.jumpCount >= 2)
            {
                PlayerController.jumpCount = 1;
                MoreJumpObject.SetActive(false);
                MJOnOff = false;
            }

            if (PlayerController.jumpCount == 0)
            {
                MoreJumpObject.SetActive(false);
                MJOnOff = false;
            }
        }
    }

    void Respawn()
    {
        MoreJumpObject.SetActive(true);
        MJOnOff = true;
    }
}
