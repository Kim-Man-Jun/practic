using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_BackGround : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        if(transform.position.y > -32)
        {
            transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

            if (transform.position.y <= -25)
            {
                LHS_GameManager.instance.stageCheck = 2;
                Debug.Log("스테이지2 시작");
            }
        }

        else
        {
            transform.GetComponentInChildren<Background>().enabled = true;
        }
    }
}
