using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCategory_consumables
{
    public int ID;
    public enum Type_consumables
    {
        Recovery,
        Damage,
        Buff,
        Debuff
    };
    public string Name;
    public string Description;
    //회복량, 피해량, 공격력 업이나 방어력 다운 등
    public int Figure;

    //아이템의 속성 1번
    public enum characteristic_1
    {
        abc
    };

    //아이템의 속성 2번
    public enum characteristic_2
    {
        def
    };

    //아이템의 속성 3번
    public enum characteristic_3
    {
        ghi
    };

    //연금술로 추가되는 특성
    public List<string> properties = new List<string>();

}
