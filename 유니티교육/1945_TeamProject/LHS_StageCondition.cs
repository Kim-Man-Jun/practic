using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_StageCondition : MonoBehaviour
{
    //State�� �ִ� ���͵�
    List<GameObject> MonsterListInRoom = new List<GameObject>();

    //����?
    //�÷��̾ �濡 �ִ���
    public bool playerInThisRoom = false;
    public bool isClearRoom = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //�÷��̾ �濡 ������ �� ���� �� ����Ʈ�� �����Ų��.
            playerInThisRoom = true;
            //�÷��̾� Ÿ���� static����
        }
        if(collision.CompareTag("Monster"))
        {
            MonsterListInRoom.Add(collision.gameObject);
            //Debug.Log("Mob name" + collision.gameObject.name);
        }
    }
}
