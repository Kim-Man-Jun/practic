using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Wall : MonoBehaviour
{
    public bool monsterCheck = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(monsterCheck == true)
        {
            if(!collision.CompareTag("Monster"))
            {
                Destroy(collision.gameObject);
            }
        }

        else
        {
            //플레이어는 삭제 되지 않음
            if (!collision.CompareTag("Player") && !collision.CompareTag("Player2Bullet"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
