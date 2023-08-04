using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�̵�, �ִϸ��̼�
//�Ѿ˹߻�
public class LHS_Player2Move : MonoBehaviour
{
    //�̵��ӵ�
    [Header("�̵��ӵ�")]
    [SerializeField] float moveSpeed = 5f;
    public float hp = 100;
    public float maxHp = 100; 
    
    Animator anim;
    
    //player������ 
    public bool startGame = false;

    //�Դ� �� ������ üũ
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
        //Linecast -> �׽�Ʈ���̶�� �׸��Ⱑ ����?
        //Linecast ���̸�ŭ ���� �׸���? �ƴ� ������ �ɷ� ���� �� �׸���? 
        //Rotate�� ���� �� �ֳ�?
        Physics2D.Linecast(transform.position, transform.position + (transform.up * 1.5f));
        Debug.DrawLine(transform.position, transform.position + (transform.up * 1.5f));
        #endregion
        
        Move();

        //������ �ΰ� ���� �� 
        if(LHS_GameManager.instance.itemNum == 1)
        {
            //�ڽ� �Ѿ� �ι�°�� Ű��
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
            #region �ִϸ��̼� ����
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

            #region �̵�
            //������ ��� ������� �ϰ����� �ӵ��� �����Ű�� ���ؼ��� 
            //������ ũ�⸦ 1�� �ٲ��ִ� normalized�� Ȱ�� -> �밢���̵�
            //���1
            /*Vector3 dir = new Vector3(h, v, 0);
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;*/

            //���2
            //���� ���� �Ŀ��� ������ ����
            transform.Translate(new Vector3(h, v, 0).normalized * moveSpeed * Time.deltaTime);

            //�̵� ���� x�� 2.45
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
            //�����Ҷ� ���� ��ġ�� �̵� //���ڷ� �Ҽ��� �ְ�, ��ġ ������ ����
            //���� ���� ���� �̵�����
            Vector3 endPos = new Vector3(0, -4, 0);

            //��������, ��ǥ����, �̵��ӵ�
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
            //���� ����
            Debug.Log("���� ����");
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
            //�� �ٽ� �ٲ�� 
            Invoke("ColorChange", 0.5f);
        }
    }

    void ColorChange()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
