using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mouseShoot : MonoBehaviour
{
    public GameObject mousePointer;
    public Transform firePos;

    [Header("Bullet List")]
    [SerializeField] private GameObject Bullet;

    Vector2 pointer;

    // Start is called before the first frame update
    void Start()
    {
        Initiate();
        InvokeRepeating("Shooting", 0.0f, 1f);
    }

    private void Initiate()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        pointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePointer.transform.position = pointer;
    }

    private void Shooting()
    {
        Instantiate(Bullet, firePos.transform.position, Quaternion.identity);
    }
}
