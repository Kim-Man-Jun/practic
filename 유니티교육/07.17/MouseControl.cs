using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float angle = 360;
    float rotateAngle = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //카메라로부터 화면의 안쪽으로 빔을 쏜다
            var wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(wPos, Vector2.zero);

            if (hit)     //무언가에 부딪히고 있다면
            {
                if (hit.collider.gameObject.name == "Flower")     //부딪힌거에 이름이 ""면
                {
                    rotateAngle = angle;        //회전 각도를 지정
                    transform.Rotate(0, 0, rotateAngle / 50);
                }
            }
        }
    }

    //private void OnMouseDown()      //마우스로 터치되면
    //{
    //    gameObject.SetActive(false);
    //}
}
