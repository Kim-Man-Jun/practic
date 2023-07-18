using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerStart : MonoBehaviour
{
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = this.gameObject.transform.position;
        player = FindObjectOfType<PlayerController>();

        if (player != null)
        {
            if (DataManager.StageFirst == false)
            {
                player.transform.position = pos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

