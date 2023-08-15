using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//CharacterParams는 플레이어 파라미터 클래스와 몬스터 파라미터 클래스의 
//부모 클래스 역할을 함
public class CharacterParams : MonoBehaviour
{
    //약식 프로퍼티, 속성 선언
    //유니티 인스펙터에 노출되는 걸 막음, 정식 프로퍼티로 전환 쉬움
    //퍼블릭 변수와 똑같이 사용 가능
    public int level { get; set; }
    public int maxHp { get; set; }
    public int curHp { get; set; }
    public int attackMin { get; set; }
    public int attackMax { get; set; }
    public int defense { get; set; }
    public bool isDead { get; set; }

    [System.NonSerialized]
    public UnityEvent deadEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        InitParams();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //CharacterParams 클래스를 상속한 자식클래스에서
    //InitParams에 자신만의 명령어를 추가하면 자동으로 필요한 명령어 실행
    public virtual void InitParams()
    {

    }

    public int GetRandomAttack()
    {
        int randAttack = Random.Range(attackMin, attackMax + 5);
        return randAttack;
    }

    public void SetEnemyAttack(int enemyAttackPower)
    {
        curHp -= enemyAttackPower;
        UpdateAfterReceiveAttack();
    }

    //캐릭터가 적으로부터 공격을 받은 뒤에 자동으로 실행될 함수를 가상함수로
    protected virtual void UpdateAfterReceiveAttack()
    {
        print(name + "'s Hp : " + curHp);

        if(curHp <= 0)
        {
            curHp = 0;
            isDead = true;
            deadEvent.Invoke();
        }
    }

}
