using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody2D BulletPrefab;        //프리팹 총알의 rigid 가져옴
    public Transform firePos;               //플레이어에 붙어있는 총알 발사 지점
    public float cooltime;                  //총알 발사 쿨타임
    private float curtime;                  //총알 발사 후 지나가는 시간
    public Vector2 PlayerVector;            //플레이어 좌우 구분을 위한 각도 구하기용 벡터값
    public Vector2 FireposVector;
    public float BulletSpeed = 20.0f;       //총알 스피드

    private void Start()
    {

    }

    void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");     //플레이어 변수를 만들고 오브젝트 찾기
        PlayerVector = player.GetComponent<Transform>().position;           //플레이어 위치값 구하기           
        FireposVector = GetComponent<Transform>().position;                 //현재 오브젝트의 위치값 구하기

        float angle = GetAngle(PlayerVector, FireposVector);                //플레이어와 총구와의 각도 구하기

        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                if (angle <= -150 && angle >= -170)         //왼쪽일때
                {
                    //bullet를 FirePos.transform.position 위치에 FirePos.transform.rotation 회전값으로 복제한다
                    Rigidbody2D BulletPre = Instantiate(BulletPrefab, firePos.position, Quaternion.identity);
                    BulletPre.velocity = BulletSpeed * firePos.transform.right * -1;
                }
                else if (angle <= 0 && angle >= -20)        //오른쪽일때
                {
                    Rigidbody2D BulletPre = Instantiate(BulletPrefab, firePos.position, Quaternion.identity);
                    BulletPre.velocity = BulletSpeed * firePos.transform.right;
                }
            }
            curtime = cooltime;         //총알 발사 후 잠깐의 딜레이 타임
        }
        curtime -= Time.deltaTime;
    }


    public static float GetAngle(Vector2 vStart, Vector2 vEnd)
    {
        Vector2 v = vEnd - vStart;          //변수 v 생성 
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;       //이거는 알아봐야함
    }
}
