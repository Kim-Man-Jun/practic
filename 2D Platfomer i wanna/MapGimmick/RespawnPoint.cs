using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject MoreJumpPrefab;

    void Start()
    {
        InvokeRepeating("Respawn", 0, 0.5f);
    }

    void Respawn()
    {
        if(MoreJumpPrefab != null)
        {
            Instantiate(MoreJumpPrefab, transform.position, transform.rotation);
        }
    }
}

//https://solution94.tistory.com/10 활성화 비활성화 방법 이건 좋은 방법이 아닌듯?
//https://overworks.github.io/unity/2019/07/16/null-of-unity-object.html null 체크
