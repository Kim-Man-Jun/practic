using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MovingPlatformLR : MonoBehaviour
{
    public float MovingSpeed = 0.5f;    //발판 움직이는 속도
    public float MovingTime;            //코루틴 반복시간이자 왼쪽으로 움직이는 시간
    public bool MovingLR;               //false일때 왼쪽으로, true일때 오른쪽으로

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BlockMoving");
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingLR == false)
        {
            transform.Translate(-MovingSpeed * Time.deltaTime, 0, 0);
        }
        else if (MovingLR == true)
        {
            transform.Translate(MovingSpeed * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator BlockMoving()
    {
        if (MovingLR == true)
        {
            MovingLR = false;
        }
        else if (MovingLR == false)
        {
            MovingLR = true;
        }
        yield return new WaitForSeconds(MovingTime);
        StartCoroutine("BlockMoving");
    }

}
