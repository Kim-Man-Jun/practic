using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAni : MonoBehaviour
{
    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK = "Attack";
    public const string DIE = "Death";

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

    public void ChangeAni(string aniName)
    {
        anim.Play(aniName);
    }
}
