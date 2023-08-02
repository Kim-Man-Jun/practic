using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    AudioSource GameOver;

    private void Awake()
    {
        Screen.SetResolution(620, 1920, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameOver = GetComponent<AudioSource>();
        GameOver.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        PlayerController.Bomb = 2;
        PlayerController.WeaponPower = 0;
        PlayerController.NowHP = 100;
        BossController.BossAppear = 0;
        BossController.BossNowHp = 20000;
        BossController.BossClear = false;

        SceneManager.LoadScene("KMJ_Stage");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
