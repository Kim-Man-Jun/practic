using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float Speed = 2f;
    public float MaxHP = 100f;
    public static float NowHP = 100f;
    public Image NowHPBar;

    public GameObject[] Bullet;

    public Transform pos1 = null;
    public Transform pos2 = null;
    public Transform pos3 = null;

    public static int WeaponPower = 0;
    public static int Bomb = 3;

    public GameObject BoomEffect;

    public float CoolTime;
    public float CoolTimestatic = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 움직임 관련
        float moveX = Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = Speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Translate(moveX, moveY, 0);

        //플레이어 애니메이션 관련
        if (Input.GetAxis("Vertical") >= 0)
        {
            if (Input.GetAxis("Horizontal") >= 0.3f)
            {
                animator.Play("Right");
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f)
            {
                animator.Play("Left");
            }
            else
            {
                animator.Play("Idle");
            }
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetAxis("Horizontal") >= 0.3f)
            {
                animator.Play("Left");
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f)
            {
                animator.Play("Right");
            }
            else
            {
                animator.Play("Idle");
            }
        }

        //맵 이동제한 걸기
        if (transform.position.x <= -1.9f)
        {
            transform.position = new Vector3(-1.9f, transform.position.y, 0);
        }
        if (transform.position.x >= 1.9f)
        {
            transform.position = new Vector3(1.9f, transform.position.y, 0);
        }
        if (transform.position.y >= -16.18f)
        {
            transform.position = new Vector3(transform.position.x, -16.18f, 0);
        }
        if (transform.position.y <= -23.37f)
        {
            transform.position = new Vector3(transform.position.x, -23.37f, 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (CoolTime == 0)
            {
                if (WeaponPower == 0)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
                else if (WeaponPower == 1)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
                else if (WeaponPower == 2)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower], pos2.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower], pos3.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
                else if (WeaponPower == 3)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower], pos2.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower], pos3.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
            }

            CoolTime -= Time.deltaTime;

            if (CoolTime < 0)
            {
                CoolTime = 0;
            }
        }

        NowHPBar.fillAmount = (float)NowHP / (float)MaxHP;

    }

    public void Damage(int attack)
    {
        NowHP -= attack;

        if (NowHP <= 0)
        {
            NowHPBar.fillAmount = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.9f);
    }
}
