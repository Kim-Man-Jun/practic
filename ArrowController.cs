using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2;    //ȭ�� ���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);    // deleteTime �Ŀ� gameObject �����ϱ�
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);   //������ ���� ������Ʈ�� �ڽ����� ����
        GetComponent<CircleCollider2D>().enabled = false;   //�浹 ���� ��Ȱ��ȭ
        GetComponent<Rigidbody2D>().simulated = false;
    }

}
