using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator ani;
    public float MoveSpeed = 5;
    public GameObject Bullet = null;
    public Transform pos = null;

    public float CoolTime;
    public float CoolTimeBase = 0.5f;

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
            Instantiate(Bullet, pos.position, Quaternion.identity);
        }

        transform.Translate(moveX, moveY, 0);
    }
}
