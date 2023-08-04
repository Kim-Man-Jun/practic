using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아래로만 이동하는 적
public class LHS_Monster2 : MonoBehaviour
{
    public float speed = 5f;
    public int hp = 50;
    public int attack = 20;
    public int addScore = 10;

    [SerializeField] GameObject item;
    [SerializeField] GameObject effectfab;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어면 죽기
        if(collision.gameObject.CompareTag("Player"))
        {
            //플레이어 체력 깎기
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Debug.Log("플레이어 충돌");
        }
    }

    public void Damage(int attack)
    {
        hp -= attack;

        if(hp <= 0)
        {
            //아이템 생성 후
            Instantiate(effectfab, transform.position, Quaternion.identity);
            Instantiate(item, transform.position, Quaternion.identity);
            LHS_AudioManager.instance.MonsterDie();

            //죽기
            Destroy(gameObject);
        }
    }
}
