using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2;    //화살 제거 시간

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);    // deleteTime 후에 gameObject 제거하기
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);   //접촉한 게임 오브젝트의 자식으로 설정
        GetComponent<CircleCollider2D>().enabled = false;   //충돌 판정 비활성화
        GetComponent<Rigidbody2D>().simulated = false;
    }

}
