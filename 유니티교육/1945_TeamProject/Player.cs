using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public GameObject[] bullet = null;
    public GameObject Pos2Bullet = null;
    public GameObject Pos3Bullet = null;
    public GameObject Dead_Effect;
    public GameObject Lazer;
    public GameObject GameOver;
    public GameObject NextStage;

    Animator anim;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    WJ_SoundManager sm;
    //
    public Transform Pos;
    public Transform Pos2;
    public Transform Pos3;
    public Transform lzPos;

    public Image Gage;
    public float gValue = 0;
    //
    [Header("플레이어 속성")]
    public float HP = 100;
    public int bPower = 0;
    public int pPower = 0;
    public float moveSpeed = 5;
    //
    float MaxHP = 100;   
    public float Delay = 1.0f;
    //
    public float invDuration = 1f;  //무적시간
    private bool isInvincible = false;  //무적 상태 변수
    //

    private bool isPos2BulletEnalbed = false;
    private bool isPos3BulletEnalbed = false;
    //
    private int bulletCount = 0;    //발사된 총알 개수 세는 변수
    private WJ_BossPart2 bossPart2;

    void Start()
    {
        Screen.SetResolution(700, 1920, true);
        anim = GetComponent<Animator>();    
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameOver.SetActive(false);
        NextStage.SetActive(false);
        bossPart2 = FindObjectOfType<WJ_BossPart2>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");


        if (Input.GetAxis("Horizontal") >= 0.3f)
            anim.SetBool("Right", true);
        else anim.SetBool("Right", false);
        if (Input.GetAxis("Horizontal") <= -0.3f)
            anim.SetBool("Left", true);
        else anim.SetBool("Left", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet[bPower], Pos.position, Quaternion.identity);
            WJ_SoundManager.instance.ShootSound();
            
            bulletCount++;
            gValue += 0.025f;
            Gage.fillAmount = gValue;

            if (isPos2BulletEnalbed && isPos3BulletEnalbed && bulletCount >= 5)    //5발 발사후 pos2발사
            {
                Instantiate(Pos2Bullet, Pos2.position, Quaternion.identity);
                Instantiate(Pos3Bullet, Pos3.position, Quaternion.identity);
                bulletCount = 0;    //발사후 초기화
            }
            else Instantiate(bullet[bPower], Pos.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (gValue >= 1)
            {
                GameObject lz = Instantiate(Lazer, Pos.position, Quaternion.identity);
                WJ_SoundManager.instance.LazerSound();
                Destroy(lz, 2.5f);
                gValue = 0;
            }

            gValue -= 0.01f;

            if (gValue >= 0)
                gValue = 0;
            Gage.fillAmount = gValue;
        }

        if (transform.position.x >= 2.8f)
            transform.position = new Vector3(2.8f, transform.position.y, 0);
        if (transform.position.x <= -2.8f)
            transform.position = new Vector3(-2.8f , transform.position.y, 0);
        if (transform.position.y >= 4.6f)
            transform.position = new Vector3(transform.position.x, 4.4f, 0);
        if (transform.position.y <= -4.6f)
            transform.position = new Vector3(transform.position.x, -4.4f, 0);

        transform.Translate(moveX, moveY, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            bPower += 1;

            if(bPower >= 6)
            {
                bPower = 6;
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Item3")
        {
            isPos2BulletEnalbed = true;
            isPos3BulletEnalbed = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "blue")
        {
            NextStage.SetActive(true);
            WJ_SoundManager.instance.ClearSound();
            Destroy(collision.gameObject);
        }

    }

    public void Damage(int m_Attack)

    { if (!isInvincible)
        {
            HP -= m_Attack;
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            Debug.Log("HP : " + HP);
            float hpGage = HP / MaxHP;
            GameObject.Find("Hp").GetComponent<Slider>().value = hpGage;

            if (HP <= 0)
            {
                Instantiate(Dead_Effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameOver.SetActive(true);
                WJ_SoundManager.instance.OverSound();
            }
            else
            {
                StartCoroutine(DurationTime());
                StartCoroutine(ResetColorAfterDelay(1f));
            }
        }
    }

    private IEnumerator DurationTime()
    {
        isInvincible = true; //무적상태
        yield return new WaitForSeconds(invDuration);
        isInvincible = false;
    }

    private IEnumerator ResetColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.color = new Color(1, 1, 1, 1f); // 색상을 원래대로 복원
    }

}
