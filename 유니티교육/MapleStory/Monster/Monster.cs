using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sp;

    //이동 관련 변수
    public int nextMove;

    public GameObject Bolt;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

        //5초에 한번 랜덤한 움직임
        Invoke("RandomMove", 5);
    }

    public void RandomMove()
    {
        nextMove = Random.Range(-1, 2);
        float nextTime = Random.Range(2f, 5f);

        //미사일 생성
        GameObject go = Instantiate(Bolt, transform.position, Quaternion.identity);

        if(sp.flipX)
        {
            go.GetComponent<Bolt>().dir = Vector3.left;
            go.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            go.GetComponent<Bolt>().dir = Vector3.right;
            go.GetComponent<SpriteRenderer>().flipX = true;
        }

        Invoke("RandomMove", nextTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        if (rigid.velocity.x > 0)
        {
            sp.flipX = true;
        }
        else if (rigid.velocity.x < 0)
        {
            sp.flipX = false;
        }
        else
        {

        }

        //Ground Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove,
            rigid.position.y);

        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 0, 1));

        RaycastHit2D rayHIt = Physics2D.Raycast(frontVec, Vector3.down, 1f,
            LayerMask.GetMask("Ground"));

        if (rayHIt.collider == null)
        {
            nextMove = nextMove * -1;
            CancelInvoke();
            Invoke("RandomMove", 2);
        }

    }
}
