using ExitGames.Client.Photon.StructWrapping;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;


public class Pipe_top2 : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D cc;
    SpriteRenderer sr;

    //전체 플레이어 배열로
    GameObject[] Player;
    //플레이어 숫자 변수
    int playerNum;
    //기존 파이프 vector2값
    public Vector2 oriPipe;
    //이어진 파이프 vector2값
    public Vector2 connectPipe;

    public int dirInfo; //(위 : 0, 오른 : 1, 왼 : 2, 아래 : 3)

    public int pipeOutDir;

    private void Awake()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        rb = Player[playerNum].GetComponent<Rigidbody2D>();
        cc = Player[playerNum].GetComponent<CapsuleCollider2D>();
        sr = Player[playerNum].GetComponent<SpriteRenderer>();

        Player[playerNum].GetComponent<Transform>();
        Player[playerNum].GetComponent<Animator>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //인
        if (Input.GetMouseButtonDown(0))
        {
            connectPipe = mousePos;
        }

        //아웃
        if (Input.GetMouseButtonDown(1))
        {
            oriPipe = mousePos;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == Player[playerNum])
        {
            switch (dirInfo)
            {
                //입구 위
                case 0:
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        pipeDir("Down");
                    }
                    break;

                //입구 오른쪽
                case 1:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        pipeDir("Left");
                    }
                    break;

                //입구 왼쪽
                case 2:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        pipeDir("Right");
                    }
                    break;

                //입구 아래
                case 3:
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        pipeDir("Up");
                    }
                    break;

                default: break;

            }
        }
    }

    private void pipeDir(string Dir)
    {
        StartCoroutine($"slow{Dir}");
    }

    private void pipeMovement()
    {
        if (Player[playerNum].transform.position.x - oriPipe.x < 1.2f 
            && Player[playerNum].transform.position.x - oriPipe.x > -1.2f)
        {
            Player[playerNum].transform.position = connectPipe;
        }

        else if (Player[playerNum].transform.position.x - connectPipe.x < 1.2f
            && Player[playerNum].transform.position.x - connectPipe.x > -1.2f)
        {
            Player[playerNum].transform.position = oriPipe;
        }

        StartCoroutine("pipeOutMovement");
    }

    IEnumerator pipeOutMovement()
    {
        switch (pipeOutDir)
        {
            //입구 위
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    rb.velocity = Vector2.zero;
                    new WaitForSeconds(0.2f);
                    Player[playerNum].transform.Translate(new Vector2(0, +0.4f));
                }
                break;

            //입구 오른쪽
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    rb.velocity = Vector2.zero;
                    new WaitForSeconds(0.2f);
                    Player[playerNum].transform.Translate(new Vector2(-0.4f, 0));
                }
                break;

            //입구 왼쪽
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    rb.velocity = Vector2.zero;
                    new WaitForSeconds(0.2f);
                    Player[playerNum].transform.Translate(new Vector2(+0.4f, 0));
                }
                break;

            //입구 아래
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    rb.velocity = Vector2.zero;
                    new WaitForSeconds(0.2f);
                    Player[playerNum].transform.Translate(new Vector2(0, -0.4f));
                }
                break;

            default: break;
        }

        rb.gravityScale = 3;
        cc.enabled = true;
        sr.sortingOrder = 1;

        yield return new WaitForSeconds(0.1f);
    }

    #region slowDir_pipeIn

    IEnumerator slowDown()
    {
        rb.gravityScale = 0;
        cc.enabled = false;
        sr.sortingOrder = -1;

        for (int i = 0; i < 4; i++)
        {
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(0.2f);
            Player[playerNum].transform.Translate(new Vector2(0, -0.4f));
        }

        pipeMovement();
    }


    IEnumerator slowUp()
    {
        rb.gravityScale = 0;
        cc.enabled = false;
        sr.sortingOrder = -1;

        for (int i = 0; i < 4; i++)
        {
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(0.2f);
            Player[playerNum].transform.Translate(new Vector2(0, 0.4f));
        }

        rb.gravityScale = 3;
        cc.enabled = true;
        sr.sortingOrder = 1;

        pipeMovement();
    }

    IEnumerator slowLeft()
    {
        rb.gravityScale = 0;
        cc.enabled = false;
        sr.sortingOrder = -1;

        for (int i = 0; i < 4; i++)
        {
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(0.2f);
            Player[playerNum].transform.Translate(new Vector2(-0.4f, 0));
        }

        rb.gravityScale = 3;
        cc.enabled = true;
        sr.sortingOrder = 1;

        pipeMovement();
    }

    IEnumerator slowRight()
    {
        rb.gravityScale = 0;
        cc.enabled = false;
        sr.sortingOrder = -1;

        for (int i = 0; i < 4; i++)
        {
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(0.2f);
            Player[playerNum].transform.Translate(new Vector2(0.4f, 0));
        }

        rb.gravityScale = 3;
        cc.enabled = true;
        sr.sortingOrder = 1;

        pipeMovement();
    }
    #endregion
}
