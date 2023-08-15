using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class XMLManager : MonoBehaviour
{
    public static XMLManager instance;

    //xml파일 변수
    public TextAsset enemyFileXml;

    //여러개의 변수를 넣어서 구조체를 생성
    struct MonParams
    {
        //xml 파일로부터 각각의 몬스터의 파라미터 값을 읽어 들이고
        //구조체 내부 변수에 저장, 구조체를 이용해 각 몬스터에 파라미터 값으로 전달함
        public string name;
        public int level;
        public int maxHP;
        public int attackMin;
        public int attackMax;
        public int defense;
        public int exp;
        public int rewardMoney;
    }

    //Dictionary의 키값으로 적의 이름을 사용하기 때문에 string
    //데이터 값으로는 구조체를 이용하기 때문에 MonParams으로 지정
    Dictionary<string, MonParams> dicMonsters = new Dictionary<string, MonParams>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeMonsterXML();
    }

    private void MakeMonsterXML()
    {
        XmlDocument monsterXMLDoc = new XmlDocument();
        monsterXMLDoc.LoadXml(enemyFileXml.text);

        XmlNodeList monsterNodeList = monsterXMLDoc.GetElementsByTagName("row");

        //노드 리스트로부터 각각의 노드를 추출
        foreach (XmlNode monsterNode in monsterNodeList)
        {
            MonParams monParams = new MonParams();

            foreach (XmlNode childeNode in monsterNode.ChildNodes)
            {
                if (childeNode.Name == "name")
                {
                    monParams.name = childeNode.InnerText;
                }

                if (childeNode.Name == "level")
                {
                    monParams.level = Int16.Parse(childeNode.InnerText);
                }

                if (childeNode.Name == "maxHp")
                {
                    monParams.maxHP = Int16.Parse(childeNode.InnerText);
                }

                if (childeNode.Name == "attackMin")
                {
                    monParams.attackMin = Int16.Parse(childeNode.InnerText);
                }

                if (childeNode.Name == "attackMax")
                {
                    monParams.attackMax = Int16.Parse(childeNode.InnerText);
                }

                if (childeNode.Name == "defense")
                {
                    monParams.defense = Int16.Parse(childeNode.InnerText);
                }

                if (childeNode.Name == "exp")
                {
                    monParams.exp = Int16.Parse(childeNode.InnerText);
                }

                if (childeNode.Name == "rewardMoney")
                {
                    monParams.rewardMoney = Int16.Parse(childeNode.InnerText);
                }

                print(childeNode.Name + " : " + childeNode.InnerText);
            }

            dicMonsters[monParams.name] = monParams;
        }
    }

    //외부로부터 몬스터의 이름과 EnemyParams 객체를 전달 받아서
    //해당 이름을 가진 몬스터의 데이터를 전달받은 EnemyParams에 전달, 적용하는 역할을 하는 함수
    public void LoadMonsterParamsFromXML(string monName, EnemyParams mParams)
    {
        mParams.level = dicMonsters[monName].level;
        mParams.curHp = mParams.maxHp = dicMonsters[monName].maxHP;
        mParams.attackMin = dicMonsters[monName].attackMin;
        mParams.attackMax = dicMonsters[monName].attackMax;
        mParams.defense = dicMonsters[monName].defense;
        mParams.exp = dicMonsters[monName].exp;
        mParams.rewardMoney = dicMonsters[monName].rewardMoney;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
