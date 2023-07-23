using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    public const int ANI_IDLE = 0;
    public const int ANI_WALK = 1;
    public const int ANI_ATTACK = 2;
    public const int ANI_ATKIDLE = 3;
    public const int ANI_DIE = 4;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //애니메이션 번호를 입력 받아서 플레이어의 애니메이션을 바꿔줌
    public void ChangeAni(int aniNumber)
    {
        anim.SetInteger("AniName", aniNumber);
    }
}
