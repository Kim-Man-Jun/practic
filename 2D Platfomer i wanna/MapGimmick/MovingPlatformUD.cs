using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MovingPlatformUD : MonoBehaviour
{
    public float MovingSpeed = 0.5f;    //발판 움직이는 속도
    public float MovingTime;            //코루틴 반복시간이자 위로 움직이는 시간
    public bool MovingUD;               //false일때 위쪽으로, true일때 아래쪽으로

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BlockMoving");
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingUD == false)
        {
            transform.Translate(0, MovingSpeed * Time.deltaTime, 0);
        }
        else if (MovingUD == true)
        {
            transform.Translate(0, -MovingSpeed * Time.deltaTime, 0);
        }
    }

    IEnumerator BlockMoving()
    {
        if (MovingUD == true)
        {
            MovingUD = false;
        }
        else if (MovingUD == false)
        {
            MovingUD = true;
        }
        yield return new WaitForSeconds(MovingTime);
        StartCoroutine("BlockMoving");
    }

}
