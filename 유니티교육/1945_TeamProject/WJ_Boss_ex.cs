using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Boss_ex : MonoBehaviour
{
    public int HP = 500;
    public GameObject BossExplosion;
    void Start()
    {
        
    }
    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
        {
            //gameObject.SetActive(false);
            Instantiate(BossExplosion, transform.position, Quaternion.identity);
            WJ_SoundManager.instance.ExplosionSound();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
