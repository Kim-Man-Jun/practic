using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player4Controller : MonoBehaviour
{
    public float Speed;

    public int MaxHp;
    public int CurHp;
    public bool isDead = false;
    public GameObject ammo;
    public GameObject superammo;
    public GameObject ilusion;
    public Image Hp;
    public GameObject HomingAmmo;
    public bool isItem = false;
    public Transform BulletPos;
    public int Hac;
    Animator ani;
    public bool isDamaged = false;
    public bool isNoHit = false;
    public float noHitTime = 0;
    float overTime = 0;
    bool isItem2 = false;
    public int item2 = 3;
    public float ss = 6.5f;
    public float es = -6.5f;
    public int Sc = 0;
    void Start()
    {
        CurHp = MaxHp;
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Hp.fillAmount = (float)CurHp / (float)MaxHp;
        float moveX = Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = Speed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }


        transform.Translate(moveX, moveY, 0);

        if (Input.GetKeyDown(KeyCode.C))
        {
            superAttack();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GeneralFire();
            AudioManager4.instance.PlayBomerang();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            HomingFire();
            AudioManager4.instance.PlayBomerang();
        }
        if (isItem2 == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Time.timeScale = 0.5f;
                Speed = 30;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Time.timeScale = 1f;
                Speed = 15;
            }
        }
        if (transform.position.x >= 8f)
            transform.position = new Vector3(8f, transform.position.y, 0);
        if (transform.position.x <= -8f)
            transform.position = new Vector3(-8f, transform.position.y, 0);
        if (transform.position.y >= 13f)
            transform.position = new Vector3(transform.position.x, 13f, 0);
        if (transform.position.y <= -13f)
            transform.position = new Vector3(transform.position.x, -13f, 0);
        Dead();
        if (isDead == true)
        {
            overTime += Time.deltaTime;
        }
        if (isDamaged == true)
        {
            noHitTime += Time.deltaTime;
            if (noHitTime >= 1)
            {
                isNoHit = false;
                noHitTime = 0;
                isDamaged = false;

                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    void GeneralFire()
    {
        Instantiate(ammo, transform.position, Quaternion.identity);
    }

    void HomingFire()
    {

        if (isItem == true)
        {
            Instantiate(HomingAmmo, transform.position, Quaternion.identity);
            Hac--;
            if (Hac == 0)
            {
                isItem = false;
            }
        }

    }

    void Dead()
    {

        if (CurHp <= 0)
        {
            
                ani.SetBool("Dead", true);
                Destroy(gameObject, 1);
                isDead = true;

                if (overTime > 0.9f)
                {
                    SceneManager.LoadScene("GameOver");
                }
            
        }
    }

    void superAttack()
    {
        if (item2 >= 3)
        {
            item2 -= 3;
            Sc = 0;
            AudioManager4.instance.PlaySuper();
            createSuperAmmo();
        }
    }

    void createSuperAmmo()
    {
        Sc++;
        float ss = 9f;
        float sy = 1;
        for (int i = 0; i < 17; i++)
        {
            ss -= 1;

            Vector2 r = new Vector2(ss, transform.position.y + 1);

            Instantiate(superammo, r, Quaternion.identity);
            GameObject ilusion2 = (GameObject)Instantiate(ilusion, r, Quaternion.identity);
            Destroy(ilusion2, 0.1f);
        }
        for(int j = 0; j < 6; j++)
        {
            sy++;
            Vector2 l = new Vector2(transform.position.x, transform.position.y + sy);
            Instantiate(superammo, l, Quaternion.identity);
        }
        Invoke("createSuperAmmo", 1);

        if (Sc >= 3)
        {
            CancelInvoke("createSuperAmmo");
        }
    }
    void SetDamage()
    {
        CurHp--;
        isDamaged = true;
        isNoHit = true;

        GetComponent<SpriteRenderer>().color = Color.red;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            if (isNoHit == false)
            {
                SetDamage();
            }
        }
        if (collision.CompareTag("Boss"))
        {
            if (isNoHit == false)
            {
                SetDamage();
            }
        }

        if (collision.CompareTag("EnemyBullet"))
        {
            if (isNoHit == false)
            {
                SetDamage();
            }
        }
        if (collision.CompareTag("Item"))
        {
            AudioManager4.instance.PlayHeal();


            if (CurHp == MaxHp)
            {
                CurHp = MaxHp;
            }
            else
            {
                CurHp++;
            }
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item1"))
        {
            AudioManager4.instance.PlayGetItem();
            isItem = true;
            Hac = 25;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item2"))
        {
            AudioManager4.instance.PlayGetItem();

            isItem2 = true;
            item2++;
            Destroy(collision.gameObject);
        }

    }
}
