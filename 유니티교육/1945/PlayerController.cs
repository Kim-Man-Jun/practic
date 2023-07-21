using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator ani;
    public float MoveSpeed = 5;

    public GameObject[] Bullet;

    public Transform pos = null;

    public static int WeaponPower = 0;
    public static int Bomb = 2;

    PlayerController playercontroller;

    public GameObject BoomEffect;

    public Image Gauge;

    public float gValue = 0;

    //레이저 오브젝트
    public GameObject Lazer;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = MoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = MoveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("Right", true);
        }
        else
        {
            ani.SetBool("Right", false);
        }

        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("Left", true);
        }
        else
        {
            ani.SetBool("Left", false);
        }

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("Up", true);
        }
        else
        {
            ani.SetBool("Up", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(Bullet[WeaponPower], pos.position, Quaternion.identity);
        }
        //스페이스바를 누르고 있을 때
        else if (Input.GetKey(KeyCode.Z))
        {
            gValue += 0.005f;

            Gauge.fillAmount = gValue;

            if (gValue >= 1)
            {
                gValue = 1;
                //레이저 발사
                GameObject go = Instantiate(Lazer, pos.position, Quaternion.identity);
                Destroy(go, 2);
                gValue = 0;
            }
        }
        else
        {
            gValue -= 0.005f;

            Gauge.fillAmount = gValue;

            if (gValue <= 0)
            {
                gValue = 0;
            }
        }

        transform.Translate(moveX, moveY, 0);

        if (transform.position.x <= -3.1f)
        {
            transform.position = new Vector3(-3.1f, transform.position.y, 0);
        }
        if (transform.position.x >= 3.1f)
        {
            transform.position = new Vector3(3.1f, transform.position.y, 0);
        }
    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.6f);
    }
}
