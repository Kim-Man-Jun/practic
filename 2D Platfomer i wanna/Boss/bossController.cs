using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    //보스 등장 관련 변수들
    [Header("Boss Appear")]
    bool coolTimeOnOff = false;
    public float coolTimeMax = 2f;
    float coolTime;

    //보스 스테이터스 관련
    [Header("Boss State")]
    public Slider bossHpBar;
    public int bossHpMax = 200;
    private int bossHpMin;

    [Header("Boss Attack")]
    public GameObject bossBullet1;
    public GameObject bossBullet2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bossHpMin = bossHpMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolTimeOnOff == false)
        {
            coolTime += Time.deltaTime;

            if (coolTime > coolTimeMax)
            {
                firstStart();
            }
        }

        //보스 HP바 관련 지속적인 업데이트
        bossHpBar.value = bossHpMin;
    }

    //보스 데미지 처리 메서드
    public void Damaged(int dmg)
    {
        bossHpMin -= dmg;

        if (bossHpMin <= 0)
        {
            bossHpBar.value = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(Damaged());
        }
    }

    IEnumerator Damaged()
    {
        sr.color = new Color(1, 0.5f, 0.5f, 0.6f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1, 1, 1, 1);
    }

    //보스 첫 등장씬
    private void firstStart()
    {
        if (coolTime > coolTimeMax)
        {
            gameObject.transform.position = new Vector2(44, 4f);
            rb.bodyType = RigidbodyType2D.Static;
            GetComponent<bossMoving>().enabled = true;
            coolTimeOnOff = true;
            coolTime = 0f;
        }
    }
}
