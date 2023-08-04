using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2_Monster : MonoBehaviour
{
    public GameObject Player_Death;
    public GameObject Item = null;
    public GameObject DeathMonster;
    public float moveSpeed = 5f;
    public int HP = 3; 
    public float drop = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, -moveY, 0);
    }
    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
        {
            ItemDrop();
            Instantiate(DeathMonster, transform.position, Quaternion.identity);
            WJ_SoundManager.instance.ExplosionSound();
            Destroy(gameObject);
        }
    }
    public void ItemDrop()
    {
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= drop)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(Player_Death, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
