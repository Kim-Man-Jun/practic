using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBlock : MonoBehaviour
{
    public GameObject FlashBlock;
    public bool FBOnOff;
    public float FBStartTime;           //morejump와 다르게 시작에도 차이점을 주기 위한 변수
    public float FBOnOffDeleyTime;
    public float FBLeftTime;            //닿기만 해도 사라지는 morejump와 다르게 몇초 두에 자동으로 사라지기 위한 변수

    void Start()
    {
        if (FBOnOff == false)
        {
            InvokeRepeating("Respawn", FBStartTime, FBOnOffDeleyTime);
        }
    }
    
    void Update()
    {
        FBLeftTime -= Time.deltaTime;
        if(FBLeftTime <= 0)
        {
            FlashBlock.SetActive(false);
            FBOnOff = false;
        }
    }

    void Respawn()
    {
        FlashBlock.SetActive(true);
        FBOnOff = true;
    }
    
}

//기본 골조 록맨에 나오는 사라지는 블록처럼 
