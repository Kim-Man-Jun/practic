using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUI : MonoBehaviour
{
    public GameObject[] Bomb = new GameObject[5];

    private void Awake()
    {
        for (int i = 0; i < Bomb.Length; i++)
        {
            Bomb[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.Bomb == 0)
        {
            for(int i = 0; i < Bomb.Length; i++)
            {
                Bomb[i].SetActive(false);
            }
        }

        else if(PlayerController.Bomb == 1)
        {
            Bomb[0].SetActive(true);
            Bomb[1].SetActive(false);
            Bomb[2].SetActive(false);
            Bomb[3].SetActive(false);
            Bomb[4].SetActive(false);
        }

        else if (PlayerController.Bomb == 2)
        {
            Bomb[0].SetActive(true);
            Bomb[1].SetActive(true);
            Bomb[2].SetActive(false);
            Bomb[3].SetActive(false);
            Bomb[4].SetActive(false);
        }

        else if (PlayerController.Bomb == 3)
        {
            Bomb[0].SetActive(true);
            Bomb[1].SetActive(true);
            Bomb[2].SetActive(true);
            Bomb[3].SetActive(false);
            Bomb[4].SetActive(false);
        }

        else if (PlayerController.Bomb == 4)
        {
            Bomb[0].SetActive(true);
            Bomb[1].SetActive(true);
            Bomb[2].SetActive(true);
            Bomb[3].SetActive(true);
            Bomb[4].SetActive(false);
        }

        else if (PlayerController.Bomb == 5)
        {
            Bomb[0].SetActive(true);
            Bomb[1].SetActive(true);
            Bomb[2].SetActive(true);
            Bomb[3].SetActive(true);
            Bomb[4].SetActive(true);
        }
    }
}
