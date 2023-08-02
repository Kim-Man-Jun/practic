using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 속성")]
    public float HP = 100;
    public float MP = 100;
    public float EXP = 100;
    int MaxHp = 100;
    public GameObject HPBar;

    [SerializeField]
    public float MoveSpeed = 3f;
    [SerializeField]
    public float JumpPower = 5f;
    Animator animator;
    Rigidbody2D rbody;
    SpriteRenderer SR;

    bool bJump = false;

    //스킬
    public Transform posR;
    public Transform posL;
    public GameObject Drill;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        Vector3 dir = Vector3.right * h;

        if (h >= 0.1)
        {
            SR.flipX = false;
            animator.SetBool("Walk", true);
        }
        else if (h <= -0.1)
        {
            SR.flipX = true;
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        transform.Translate(dir * MoveSpeed * Time.deltaTime);

        //점프
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (animator.GetBool("Jump") == false)
            {
                Jump();
                animator.SetBool("Jump", true);
            }
        }

        //스킬
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Skill");
            CreateDrill();
        }
    }

    public void CreateDrill()
    {
        GameObject go;

        if (SR.flipX == false)
        {
            go = Instantiate(Drill,
                posR.transform.position, Quaternion.identity); ;
        }
        else
        {
            go = Instantiate(Drill,
                posL.transform.position, posL.transform.rotation);
        }

        Destroy(go, 0.5f);
    }

    private void FixedUpdate()
    {
        //디버그용 레이저
        Debug.DrawRay(rbody.position, Vector2.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rbody.position, Vector3.down,
            1, LayerMask.GetMask("Ground"));

        if (rbody.velocity.y < 0)
        {
            //무언가 부딪혔을때
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.7f)
                {
                    animator.SetBool("Jump", false);
                }
            }
        }
    }

    void Jump()
    {
        rbody.velocity = Vector2.zero;
        rbody.AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MBullet")
        {
            int Mattack = collision.gameObject.GetComponent<Bolt>().att;

            HP -= Mattack;

            float hpGage = HP / MaxHp;

            HPBar.GetComponent<Slider>().value = hpGage;

            Debug.Log("HP : " + HP);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NPC np = GameObject.FindObjectOfType<NPC>();

                np.Hide();
            }
        }
    }
}
