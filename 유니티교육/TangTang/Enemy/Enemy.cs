using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform Player;

    public float speed;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = Player.position - transform.position;
        direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;
    }
}
