using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VirtualPad : MonoBehaviour
{
    public float MaxLength = 70;    //탭이 움직이는 최대 거리
    public bool is4DPad = false;    //상하좌우 여부
    GameObject Player;              //조작할 플레이어
    Vector2 defPos;                 //탭의 초기 좌표
    Vector2 downPos;                //터치 위치

    // Start is called before the first frame update
    void Start()
    {
        //플레이어 가져오기
        Player = GameObject.FindGameObjectWithTag("Player");
        //탭의 초기 좌표
        defPos = GetComponent<RectTransform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PadDown()
    {
        //마우스 포인트의 스크린 좌표
        downPos = Input.mousePosition;
    }

    //드래그 이벤트
    public void PadDrag()
    {
        //마우스 포인트의 스크린 좌표
        Vector2 mousePosition = Input.mousePosition;

        //새로운 탭 위치 바꾸기
        Vector2 newTabPos = mousePosition - downPos;

        if (is4DPad == false)
        {
            newTabPos.y = 0;        //횡스크롤 일때는 y는 0으로
        }

        Vector2 axis = newTabPos.normalized;

        float len = Vector2.Distance(defPos, newTabPos);

        if (len > MaxLength)
        {
            //한계좌표 설정
            newTabPos.x = axis.x * MaxLength;
            newTabPos.y = axis.y * MaxLength;
        }

        GetComponent<RectTransform>().localPosition = newTabPos;
        PlayerController plcnt = Player.GetComponent<PlayerController>();
        plcnt.SetAxis(axis.x, axis.y);
    }

    public void PadUp()
    {
        GetComponent<RectTransform>().localPosition = defPos;
        PlayerController plcnt = Player.GetComponent<PlayerController>();
        plcnt.SetAxis(0, 0);
    }
}
