using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Door : MonoBehaviour
{
    //�Ʒ��� ��������
    //�÷��̰� ������ �ִϸ��̼� ����

    public float speed = 1;
    Animator anim;

    bool isSound = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
 
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("door_end"))
            {
                Debug.Log("�ٽ� ����");
                anim.SetBool("EndDoor", false);
            }

            else
            {
                Debug.Log("������");
                anim.SetBool("OpenDoor", true);

                //�ѹ��� ����ǰ� �ϰ� ����
                if(!isSound)
                {
                    isSound = true;
                    LHS_AudioManager.instance.OpenDoor();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("������");
            anim.SetBool("EndDoor", true);
            isSound = false;
        }
    }

    void ColliderCheck()
    {
        //�浹ó���� ���� �����ؾ��� ..! 
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
