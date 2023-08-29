using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana_Enemy : MonoBehaviour
{
    public float Attack = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("충ㄷ올");
            MonsterController monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterController>();
            float AttackSum = monster.Attack + Attack;
            other.gameObject.GetComponent<Player>().Damage(AttackSum);
        }
    }
}
    
