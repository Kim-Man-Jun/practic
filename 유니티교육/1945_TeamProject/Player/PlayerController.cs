using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    BoxCollider2D box2D;

    public float Speed = 2f;
    public float MaxHP = 100f;
    public static float NowHP = 100f;
    public Image NowHPBar;

    public GameObject[] Bullet;

    public Transform pos1 = null;

    public static int WeaponPower = 0;
    public static int Bomb = 2;

    public GameObject BoomEffect;

    public float CoolTime;
    public float CoolTimestatic = 0.1f;

    public GameObject[] SpecialAttackFire = new GameObject[4];
    public GameObject[] Bullet_SP = new GameObject[4];
    public Transform[] SpecialAttackPos = new Transform[4];
    public bool specialAttackOnOff = false;

    string nowAnime = "Idle";

    private void Awake()
    {
        for (int i = 0; i < SpecialAttackFire.Length; i++)
        {
            SpecialAttackFire[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        box2D = GetComponent<BoxCollider2D>();

        for (int i = 0; i < SpecialAttackFire.Length; i++)
        {
            SpecialAttackFire[i].GetComponent<Animator>();
        }
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
                nowAnime = "Right";
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f)
            {
                animator.Play("Left");
                nowAnime = "Left";
            }
            else
            {
                animator.Play("Idle");
                nowAnime = "Idle";
            }
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetAxis("Horizontal") >= 0.3f)
            {
                animator.Play("Left");
                nowAnime = "Left";
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f)
            {
                animator.Play("Right");
                nowAnime = "Right";
            }
            else
            {
                animator.Play("Idle");
                nowAnime = "Idle";
            }
        }

        //분신 이동 애니메이션
        if (specialAttackOnOff == true)
        {
            for (int i = 0; i < SpecialAttackFire.Length; i++)
            {
                SpecialAttackFire[i].GetComponent<Animator>().Play(nowAnime);
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

        //총 발사 관련
        if (Input.GetKey(KeyCode.Z))
        {
            if (CoolTime == 0)
            {
                if (WeaponPower == 0)
                {
                    WeaponPower = 0;
                }
                else if (WeaponPower == 1)
                {
                    WeaponPower = 1;
                }
                else if (WeaponPower == 2)
                {
                    WeaponPower = 2;
                }
                else if (WeaponPower == 3)
                {
                    WeaponPower = 3;
                }

                Instantiate(Bullet[WeaponPower], pos1.position,
                    Quaternion.identity);

                if (specialAttackOnOff == true)
                {
                    for (int i = 0; i < SpecialAttackPos.Length; i++)
                    {
                        Instantiate(Bullet_SP[WeaponPower], SpecialAttackPos[i].position,
                    Quaternion.identity);
                    }
                }

                CoolTime = CoolTimestatic;
            }

            CoolTime -= Time.deltaTime;

            if (CoolTime < 0)
            {
                CoolTime = 0;
            }
        }

        //필살기 발동
        if (Input.GetKey(KeyCode.X))
        {
            if (Bomb > 0)
            {
                SPOn();
            }
            else if (Bomb <= 0)
            {
                return;
            }
        }

        //현재 HP 계산
        NowHPBar.fillAmount = (float)NowHP / (float)MaxHP;

    }

    //폭탄 사용 코루틴 시작
    void SPOn()
    {
        if (specialAttackOnOff == false)
        {
            StartCoroutine(SPFire());
        }

        else
        {
            return;
        }
    }

    //폭탄 사용 코루틴
    IEnumerator SPFire()
    {
        specialAttackOnOff = true;
        Bomb--;
        box2D.enabled = false;

        for (int i = 0; i < SpecialAttackFire.Length; i++)
        {
            SpecialAttackFire[i].SetActive(true);
        }

        yield return new WaitForSeconds(5);

        specialAttackOnOff = false;
        box2D.enabled = true;
        for (int i = 0; i < SpecialAttackFire.Length; i++)
        {
            SpecialAttackFire[i].SetActive(false);
        }
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

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.9f);
        SceneManager.LoadScene("GameOver");

    }

}
