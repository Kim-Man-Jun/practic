using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private UIInventoryItem item;

    public void Awake()
    {
        //현재 오브젝트 최상위 개체에서 canvas 가져옿기
        canvas = transform.root.GetComponent<Canvas>();
        //기본 카메라 태그 찾기
        mainCam = Camera.main;
        //자식에 달린 오브젝트 가져오기
        item = GetComponentInChildren<UIInventoryItem>();
    }

    //각각 스프라이트와 갯수 가져오기
    public void SetData(Sprite sprite, int quantity)
    {
        item.SetData(sprite, quantity);
    }

    //드래그 한 오브젝트 위치 update용
    private void Update()
    {
        //참조용 벡터2 변수 선언, 채우기용
        Vector3 position;
        //RectTransform에 대한 로컬 위치로 변환하는 메서드
        RectTransformUtility.ScreenPointToWorldPointInRectangle
            //canvas의 tranform을 RectTransform로 변환함
            ((RectTransform)canvas.transform,
            //화면 좌표로 표현된 현재 마우스 위치
            Input.mousePosition,
            //화면 좌표를 캔버스 내에서의 로컬 좌표로 변환할 때 사용할 카메라 지정
            canvas.worldCamera,
            //out로 position에 정보를 저장함
            out position);
        //윗작업으로 얻은 position을 canvas transform으로 변환함, 아래로 했다가 정상작동을 안했음.
        //transform.position = canvas.transform.TransformPoint(position);

        transform.position = Input.mousePosition;

        Debug.Log(canvas.name);
    }

    public void Toggle(bool val)
    {
        Debug.Log($"Item toggled {val}");
        gameObject.SetActive(val);
    }
}
