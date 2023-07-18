using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    public GameObject newPrefab;        //프리팹 가져오기

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))     //마우스 왼쪽 버튼을 누를 경우
        {
            //터치한 위치를 카메라 안에서의 위치로 변환
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward);
            pos.z = -5;     //앞쪽에 표시
            //새로운 프리팹을 만들어 그 위치로 이동
            GameObject newGameObject = Instantiate(newPrefab) as GameObject;
            newGameObject.transform.position = pos;     //마우스위치에서 클릭한 곳에 자리잡도록 적용하기
        }
    }
}
