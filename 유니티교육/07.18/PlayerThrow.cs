using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject daru;     //프리팹 가져오기 변수

    public float throwX = 8;    //던지는 힘
    public float throwY = 4;

    public float offsetY = 1;   //통 들어올릴때 위치

    // Start is called before the first frame update
    void Start()
    {
        Destroy(daru, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 newPos = transform.position;
            newPos.y += offsetY;
            //프리팹 생성
            GameObject go = Instantiate(daru, newPos, Quaternion.identity);
            //프리팹의 rigidbody 가져오기
            Rigidbody2D rig = go.GetComponent<Rigidbody2D>();
            //프리팹 날리기
            rig.AddForce(new Vector2(throwX, throwY), ForceMode2D.Impulse);
        }
    }
}
