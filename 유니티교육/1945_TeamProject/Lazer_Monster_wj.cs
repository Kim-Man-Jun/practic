using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Monster_wj : MonoBehaviour
{
    public Transform ms;
    public Transform ms2;
    public GameObject Lazerbullet;
    public GameObject Item = null;
    public GameObject DeathMonster;
    //
    public int HP = 30;
    public float moveSpeed = 2f;
    public float Delay = 2.2f;
    public float drop = 5f;


    void Start()
    {
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        WJ_SoundManager.instance.lazerMonster();
        Instantiate(Lazerbullet, ms.position, Quaternion.identity);
        Instantiate(Lazerbullet, ms2.position, Quaternion.identity);
        Invoke("CreateBullet", 1.6f);
    }
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    public void ItemDrop()
    {
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= drop)
        {
            Instantiate(Item, ms.position, Quaternion.identity);
        }
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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
