using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : MonoBehaviour
{
    [SerializeField]
    GameObject BossBullet;
    public Transform ms4;

    //애니메이션에서 사용할 함수 만들기
    public void RightDownLaunch()
    {
        GameObject go = Instantiate(BossBullet, ms4.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2 (1, -1));
    }
    public void DownLaunch()
    {
        GameObject go = Instantiate(BossBullet, ms4.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(0, -1));
    }
    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(BossBullet, ms4.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(-1, -1));
    }
}
