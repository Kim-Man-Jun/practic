using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject MoreJumpPrefab;

    void Start()
    {
        InvokeRepeating("Respawn", 0, 0.5f);
    }

    void Respawn()
    {
        Instantiate(MoreJumpPrefab, transform.position, transform.rotation);
    }
}
