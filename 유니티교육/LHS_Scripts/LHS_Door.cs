using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Door : MonoBehaviour
{
    //아래로 내려가고
    //플레이가 닿으면 애니메이션 실행

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
                Debug.Log("다시 열림");
                anim.SetBool("EndDoor", false);
            }

            else
            {
                Debug.Log("열려라");
                anim.SetBool("OpenDoor", true);

                //한번만 실행되게 하고 싶음
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
            Debug.Log("나갔다");
            anim.SetBool("EndDoor", true);
            isSound = false;
        }
    }

    void ColliderCheck()
    {
        //충돌처리가 적용 생각해야함 ..! 
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
