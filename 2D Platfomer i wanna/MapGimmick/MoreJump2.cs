using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerController.jumpCount >= 1)
            {
                PlayerController.jumpCount--;
                Destroy(this.gameObject);
            }

            else if (PlayerController.jumpCount == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
