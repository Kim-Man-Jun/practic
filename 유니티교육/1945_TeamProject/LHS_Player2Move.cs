using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//이동, 애니메이션
//총알발사
public class LHS_Player2Move : MonoBehaviour
{
    //이동속도
    [Header("이동속도")]
    [SerializeField] float moveSpeed = 5f;
    public float hp = 100;
    public float maxHp = 100; 
    
    Animator anim;
    
    //player움직임 
    public bool startGame = false;

    //먹는 거 나한테 체크
    //int power = 0;
    [SerializeField] GameObject uiHP;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Intro();

        #region Linecast Test
        //Linecast -> 테스트용이라면 그리기가 가능?
        //Linecast 길이만큼 선을 그린다? 아님 나가는 걸로 따라서 선 그리기? 
        //Rotate도 돌릴 수 있나?
        Physics2D.Linecast(transform.position, transform.position + (transform.up * 1.5f));
        Debug.DrawLine(transform.position, transform.position + (transform.up * 1.5f));
        #endregion
        
        Move();

        //아이템 두개 먹을 시 
        if(LHS_GameManager.instance.itemNum == 1)
        {
            //자식 총알 두번째꺼 키기
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveX = h * moveSpeed * Time.deltaTime;
        float moveY = v * moveSpeed * Time.deltaTime;

        if (startGame == true)
        {
            #region 애니메이션 적용
            if (h >= 0.5f)
            {
                anim.SetBool("Right", true);
            }
            else
            {
                anim.SetBool("Right", false);
            }

            if (h <= -0.5f)
            {
                anim.SetBool("Left", true);
            }
            else
            {
                anim.SetBool("Left", false);
            }
            #endregion

            #region 이동
            //벡터의 양과 상관없이 일관적인 속도를 적용시키기 위해서는 
            //벡터의 크기를 1로 바꿔주는 normalized를 활용 -> 대각선이동
            //방법1
            /*Vector3 dir = new Vector3(h, v, 0);
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;*/

            //방법2
            //게임 시작 후에만 움직임 가능
            transform.Translate(new Vector3(h, v, 0).normalized * moveSpeed * Time.deltaTime);

            //이동 막기 x축 2.45
            if (transform.position.x >= 2.45f)
            {
                transform.position = new Vector3(2.45f, transform.position.y, 0);
            }
            else if (transform.position.x <= -2.45f)
            {
                transform.position = new Vector3(-2.45f, transform.position.y, 0);
            }
            if(transform.position.y <= -4.5)
            {
                transform.position = new Vector3(transform.position.x, -4.5f, 0);
            }
            else if (transform.position.y >= 4.5)
            {
                transform.position = new Vector3(transform.position.x, 4.5f, 0);
            }
            #endregion
        }
    }

    void Intro()
    {
        if (startGame == false)
        {
            //시작할때 게임 위치로 이동 //숫자로 할수도 있고, 위치 지정도 가능
            //지점 도착 이후 이동가능
            Vector3 endPos = new Vector3(0, -4, 0);

            //시작지점, 목표지점, 이동속도
            transform.position = Vector3.MoveTowards(transform.position, endPos, 0.02f);

            if (transform.position == endPos)
            {
                startGame = true;
            }
        }
    }
    
    public void Damage(int attack)
    {
        hp -= attack;

        Score();
        if (hp <= 0)
        {
            //게임 종료
            Debug.Log("게임 종료");
            SceneManager.LoadScene("GameOver");
        }
    }

    void Score()
    {
        float getHp = hp / maxHp;
        uiHP.gameObject.GetComponent<Image>().fillAmount = getHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            /*power += 1;

            if (power >= 2)
            {
                power = 2;
            }
*/
            LHS_GameManager.instance.itemNum++;
            LHS_AudioManager.instance.ItemAdd();
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Monster"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            //색 다시 바뀌게 
            Invoke("ColorChange", 0.5f);
        }
    }

    void ColorChange()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
