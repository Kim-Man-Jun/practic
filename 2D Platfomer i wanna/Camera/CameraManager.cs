using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;
    public float yaxis = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            //카메라의 좌표 갱신
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            //가로 방향 동기화와 양 끝에 이동 제한 적용
            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }

            //세로 방향 동기화와 위아래에 이동 제한 적용
            if (y < bottomLimit)
            {
                y = bottomLimit;
            }
            else if (y > topLimit)
            {
                y = topLimit;
            }

            Vector3 v3 = new Vector3(x, y + yaixs, z);
            transform.position = v3;
        }
    }
}


//씬전환처럼 하는 카메라매니저를 생각해봄
//변수를 좀더 추가한 다음 첫번째 컷 리미트까지 걸어놓고 플레이어가 'next' 태그에 닿았을 경우
//카메라를 xy리미트를 다시 재설정하고 카메락사 이동하는 형식으로 만들어보면 어떨까 생각함
//'previous'로 똑같이 이전 화면으로 돌아갈 수 있음
//카메라 매니저를 두개로 나눠야 할거 같음
//캐릭터 팔로우 하나와 씬 전체 보여주는 형식 이렇게 두개로 나눔
//스위치는 start에다가 컴포넌트를 걸어서 on/off 조작 가능하게 만들고
//맵마다 스위치를 조정하는 식으로 해보면 어떨까?

