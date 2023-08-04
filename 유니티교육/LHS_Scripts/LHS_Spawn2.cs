using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�ټ� �������� �߻��ϰ� ����
public class LHS_Spawn2 : MonoBehaviour
{
    //���� ���� x ��
    public float ss = -2; //����
    public float es = 2; //��

    public float StartTime = 1; //����
    public float SpawnTime = 10; //���� ������ �ð�

    [Header("�ܰ躰 ����")]
    public GameObject[] monster;

    public GameObject textBossWarning; // ���� ���� �ؽ�Ʈ ������Ʈ
    public GameObject BossBar; // ���� ���� �ؽ�Ʈ ������Ʈ

    //���� ���;���
    //���� UI
    private void Awake()
    {
        
    }

    void Start()
    {
        /*textBossWarning.SetActive(true);
        BossBar.SetActive(true);*/
        Invoke("Monster1", SpawnTime);
    }

    void Update()
    {
        /*if(LHS_GameManager.instance.stageCheck == 2)
        {
            //�������� 2���� ����
            transform.GetChild(0).gameObject.SetActive(true);
        }*/
    }
    
    void Monster1()
    {
        Instantiate(monster[0], transform.position, Quaternion.identity);
        Invoke("Monster2", SpawnTime + 5);
    }

    void Monster2()
    {
        textBossWarning.SetActive(true);
        BossBar.SetActive(true);
        Instantiate(monster[1], transform.position, Quaternion.identity);
        //Invoke("Monster3", SpawnTime + 10);
    }
    
    void Monster3()
    {
        Instantiate(monster[2], new Vector2(1.4f, transform.position.y), Quaternion.identity);
        Invoke("Monster4", SpawnTime + 3);
    }

    void Monster4()
    {
        Instantiate(monster[2], new Vector2(-1.4f, transform.position.y), Quaternion.identity);
        Invoke("Monster5", SpawnTime + 5);
    }

    void Monster5()
    {
        Instantiate(monster[3], transform.position, Quaternion.identity);
    }
}
