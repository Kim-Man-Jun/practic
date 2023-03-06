using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject MoreJumpPrefab;

    public void Start()
    {
        if (MoreJumpPrefab == null)
        {
            Invoke("Respawn", 1.0f);
        }
    }

    public void Respawn()
    {
        Instantiate(MoreJumpPrefab, transform.position, transform.rotation);
    }
}
