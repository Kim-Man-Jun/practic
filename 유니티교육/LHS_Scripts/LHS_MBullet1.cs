using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//ó�� �߻��Ҷ� �÷��̾ ã�� �� ������ �̵��ϰ� �ʹ�. (ȸ���� ����)
public class LHS_MBullet1 : MonoBehaviour
{
    [SerializeField] float speed = 3;
    public int attack = 10;
    public bool isidle = false;

    GameObject target;
    Vector3 dir;
    Vector2 direction;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        //�ʱⰪ
        //dir = target.transform.position - transform.position;
        dir = (target.transform.position - transform.position).normalized;
        direction = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
    }
    void Update()
    {

        if(isidle)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        else
        {
            Rotation();

            transform.position += dir * speed * Time.deltaTime;
        }
        //transform.Translate(dir * speed * Time.deltaTime);
        /*
                // �÷��̾ �ٶ󺸴� ������ �ֱ� ����
                Vector3 directionToPlayer = target.transform.position - transform.position;

                transform.position += dir * speed * Time.deltaTime;
                //���� ���
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
    }

    //�÷��̾� �������� �ٶ󺸱�
    void Rotation()
    {
        if(target != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            /*Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, speed * Time.deltaTime);
            transform.rotation = rotation;*/

            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }
    }

    //�÷��̾�� �浹�ϸ� �÷��̾� ���� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //�÷��̾� ü�� ���
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Destroy(gameObject);
            Debug.Log("�÷��̾� �浹");
        }
    }
}
