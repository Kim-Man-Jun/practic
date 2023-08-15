using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : CharacterParams
{
    public string name { get; set; }
    public int curExp { get; set; }
    public int expToNextLevel { get; set; }
    public int money { get; set; }

    public override void InitParams()
    {
        name = "Yuni";
        level = 1;
        maxHp = 200;
        curHp = maxHp;
        attackMin = 20;
        attackMax = 30;
        defense = 1;

        curExp = 0;
        expToNextLevel = 100 * level;
        money = 10;

        isDead = false;

        UIMananger.instance.UpdatePlayerUI(this);
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();

        UIMananger.instance.UpdatePlayerUI(this);
    }

    public void AddMoney(int money)
    {
        this.money += money;
        UIMananger.instance.UpdatePlayerUI(this);
    }
}
