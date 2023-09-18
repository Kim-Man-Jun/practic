using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossMapTransform : MonoBehaviour
{
    [SerializeField] private GameObject Area1;
    [SerializeField] private GameObject Area2;
    Collider2D Area1col;
    Collider2D Area2col;

    public GameObject camera_Area1;
    public GameObject camera_Area2;

    GameObject player;

    bool Onoff = false;

    private void Awake()
    {
        Area1col = Area1.GetComponent<PolygonCollider2D>();
        Area2col = Area2.GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void AreaPositionReturn()
    {
        Vector2 area1position0 = Area1col.GetComponent<PolygonCollider2D>().points.ElementAt(0);
        Vector2 area1position1 = Area1col.GetComponent<PolygonCollider2D>().points.ElementAt(1);

        float area1_rangeX = (area1position0.x - area1position1.x) - player.transform.position.x;

        if (area1_rangeX < 7.5f)
        {
            cameraMovement();
        }
    }

    private void cameraMovement()
    {
        camera_Area1.SetActive(false);
        camera_Area2.SetActive(true);
        Onoff = true;
    }

    private void Update()
    {
        if (Onoff == false)
        {
            AreaPositionReturn();
        }

    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("실행");
    //        if (confiner.m_BoundingShape2D == Area1)
    //        {
    //            Debug.Log("실행1");
    //            confiner.m_BoundingShape2D = Area2col;
    //        }

    //        else if (confiner.m_BoundingShape2D == Area2)
    //        {
    //            Debug.Log("실행2");
    //            confiner.m_BoundingShape2D = Area1col;
    //        }
    //    }
    //}
}
