using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//처음 발사할때 플레이어를 찾아 그 방향대로 이동하고 싶다. (회전도 같이)
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

        //초기값
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
                // 플레이어를 바라보는 방향을 주기 위해
                Vector3 directionToPlayer = target.transform.position - transform.position;

                transform.position += dir * speed * Time.deltaTime;
                //각도 계산
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
    }

    //플레이어 방향으로 바라보기
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

    //플레이어와 충돌하면 플레이어 점수 깎임
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //플레이어 체력 깎기
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Destroy(gameObject);
            Debug.Log("플레이어 충돌");
        }
    }
}
