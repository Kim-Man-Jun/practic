using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBlock : MonoBehaviour
{
    public GameObject FlashBlock;       
    public bool FBOnOff;                //블록 초기 On/off 정하는 용도
    public float FBOnOffDeleyTime;      //비활성화 후 다시 나타나는데 필요한 딜레이 시간
    public float FBLeftTime;            //닿기만 해도 사라지는 morejump와 다르게 몇초 뒤에 자동으로 사라지기 위한 변수

    void Start()
    {
        if (FBOnOff == false)           //블록이 비활성화 되어 있을때
        {
            InvokeRepeating("Respawn", 0.0f, FBOnOffDeleyTime);
        }
    }
    
    void Update()
    {
        if(FBOnOff == true)
        {
            FBLeftTime -= Time.deltaTime;
            if(FBLeftTime <= 0)
            {
                FlashBlock.SetActive(false);
                FBOnOff = false;
            }
        }
    }

    void Respawn()
    {
        FlashBlock.SetActive(true);
        FBOnOff = true;
    }
    
}

//기본 골조 록맨에 나오는 사라지는 블록처럼 
