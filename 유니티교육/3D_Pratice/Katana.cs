using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("적 충돌");
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 충돌");
        }
    }
}
