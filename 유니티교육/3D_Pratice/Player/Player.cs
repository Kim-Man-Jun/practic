using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //3D에서 길찾기로 쓸 수 있음
    NavMeshAgent agent;
    Animator anim;

    public string hitCheck;

    public float Hp = 100;
    public float Attack = 10;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        anim.SetInteger("aniNum", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //레이캐스트 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            //Physics.Raycast(ray변수, out 레이캐스트 hit 타입 변수)
            //가상의 선이 물체와 충돌했을 경우 true 값 반환

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Terrain")
                {
                    hitCheck = "Terrain";
                    agent.SetDestination(hit.point);
                }

                if (hit.collider.gameObject.tag == "Monster")
                {
                    hitCheck = "Monster";
                    agent.SetDestination(hit.point);
                }
            }
        }

        //내비게이션 메쉬 이동 중이며 목적지에 도착했는지
        if (agent.velocity.magnitude >= 0.2f)       //움직일 때
        {
            if (agent.remainingDistance <= 1.5f)    //도착할 때
            {
                if (hitCheck == "Terrain")
                {
                    anim.SetInteger("aniNum", 0);
                }
                else if (hitCheck == "Monster")
                {
                    anim.SetInteger("aniNum", 2);
                }
            }
            else
            {
                anim.SetInteger("aniNum", 1);
            }
        }


    }
}
