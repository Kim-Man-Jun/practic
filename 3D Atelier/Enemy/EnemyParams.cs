using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyParams : CharacterParams
{
    public string name;
    public int exp { get; set; }
    public int rewardMoney { get; set; }

    public Image hpBar;

    public override void InitParams()
    {
        /*
        name = "Monster";
        level = 1;
        maxHp = 50;
        curHp = maxHp;
        attackMin = 2;
        attackMax = 4;
        defense = 1;

        exp = 10;
        rewardMoney = Random.Range(10, 31);
        */
        XMLManager.instance.LoadMonsterParamsFromXML(name, this);

        isDead = false;

        IntiHpBarSize();
    }

    private void IntiHpBarSize()
    {
        //hpBar의 사이즈를 원래 자신의 사이즈 ,1배의 사이즈로 초기화 시켜줌
        hpBar.rectTransform.localScale = new Vector3(1, 1, 1);
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();

        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1, 1);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
