using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHomingBullet4 : MonoBehaviour
{
    public GameObject target;
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;
    public GameObject player;


    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        if(player != null) { 
        //�÷��̾� �±׷� ã��
        target = GameObject.FindGameObjectWithTag("Player");
        //A - B   �÷��̾� - �̻���    
        dir = target.transform.position - transform.position;
        //���⺤�͸� ���ϱ� �������� 1��ũ��� �����.
        dirNo = dir.normalized;
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(dirNo * Speed * Time.deltaTime);
        if (player == null)
        {
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //�÷��̾� �����
            // Destroy(collision.gameObject);
            //�̻��� �����
            Destroy(gameObject);
        }
    }
}
