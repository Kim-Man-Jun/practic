using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

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
            //레이캐스트 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            //Physics.Raycast(ray변수, out 레이캐스트 hit 타입 변수)
            //가상의 선이 물체와 충돌했을 경우 true 값 반환

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Terrain")
                {
                    player.transform.position = hit.point;
                }
            }
        }
    }
}
