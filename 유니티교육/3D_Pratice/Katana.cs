using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    public float Attack = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            float AttackSum = player.Attack + Attack;
            other.gameObject.GetComponent<MonsterController>().Damage(AttackSum);
        }
    }
}
