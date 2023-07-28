using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        PlayerController.Bomb = 3;
        PlayerController.WeaponPower = 0;
        PlayerController.NowHP = 100;
        BossController.BossAppear = 0;
        BossController.BossNowHp = 20000;

        SceneManager.LoadScene("KMJ_Stage");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
