using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;

    protected Player player;

    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
    }

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if(cooldownTimer < 0)
        {
            UseSkill();
            //스킬 사용 가능
            cooldownTimer = cooldown;
            return true;
        }

        Debug.Log("Skill CoolTime!");
        return false;
    }

    public virtual void UseSkill()
    {
        //사용할 스킬 만들기

    }
}
