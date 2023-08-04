using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_AudioManager : MonoBehaviour
{
    public static LHS_AudioManager instance;

    [SerializeField] AudioClip monsterDie;
    [SerializeField] AudioClip itemAdd;
    [SerializeField] AudioClip openDoor;

    AudioSource soundPlayer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        soundPlayer = GetComponent<AudioSource>();    
    }

    public void MonsterDie()
    {
        soundPlayer.volume = 0.5f;
        soundPlayer.PlayOneShot(monsterDie);
    }

    public void ItemAdd()
    {
        soundPlayer.volume = 1;
        soundPlayer.PlayOneShot(itemAdd);
    }

    public void OpenDoor()
    {
        soundPlayer.volume = 1f;
        soundPlayer.PlayOneShot(openDoor);
    }
}
