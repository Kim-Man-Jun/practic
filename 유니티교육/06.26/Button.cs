using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    public void Clickleft()
    {
        Debug.Log("왼쪽 클릭");
    }
    public void Clickright()
    {
        Debug.Log("오른쪽 클릭");
    }
    public void Clickup()
    {
        Debug.Log("위쪽 클릭");
    }
    public void Clickdown()
    {
        Debug.Log("아래쪽 클릭");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

//유니티 UI - 버튼 UI On Click에서 불러올만한 스크립트 붙여넣기 - 오른쪽 드롭다운 눌러서 적절한 함수명 찾아서 붙여넣기 하면 버튼 누를때 반응 성공
