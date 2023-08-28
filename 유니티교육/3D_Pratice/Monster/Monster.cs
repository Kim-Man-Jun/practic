using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public GameObject Player;

    NavMeshAgent agent;
    Animator anim;

    public float Hp = 20;
    public float Attack = 5;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        anim.SetInteger("Num", 0);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.transform.position);

        if (agent.velocity.magnitude >= 0.2f)       //움직일 때
        {
            if (agent.remainingDistance <= 1.0f)    //도착할 때
            {
                anim.SetInteger("Num", 2);
            }
            else
            {
                anim.SetInteger("Num", 1);
            }
        }
    }
}
