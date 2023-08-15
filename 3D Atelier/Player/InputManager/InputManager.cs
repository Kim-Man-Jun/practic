using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckClick();
    }

    void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //카메라로부터 화면상의 좌표를 관통하는 기상의 선을 생성해서 리턴하는 함수
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Physics.Raycast(레이 타입 변수, out 레이 캐스트 히트 타입변수)
            //가상의 레이가 충돌체와 충돌하면 true 값을 리턴하면서 동시에
            // raycast hit 변수에 충돌 대상의 정보를 담아 주는 함수
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Terrain")
                {
                    //Player.transform.position = hit.point;

                    Player.GetComponent<PlayerFSM>().MoveTo(hit.point);
                }
                else if(hit.collider.gameObject.tag == "Enemy")     //클릭한 대상이 적일 경우
                {
                    Player.GetComponent<PlayerFSM>().AttackEnemy(hit.collider.gameObject);
                }
            }
        }
    }
}
