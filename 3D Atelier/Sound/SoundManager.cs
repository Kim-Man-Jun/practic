using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//자동으로 AudioSource Component 부착
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource myAudio;

    public AudioClip sndHitEnefmy;
    public AudioClip sndEnemyAttack;
    public AudioClip sndPickUp;
    public AudioClip sndEnemyDie;

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
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        myAudio.PlayOneShot(sndHitEnefmy);
    }
    
    public void PlayEnemyAttackSound()
    {
        myAudio.PlayOneShot(sndEnemyAttack);
    }

    public void PlayEnemyDieSound()
    {
        myAudio.PlayOneShot(sndEnemyDie);
    }

    public void PlayPickUpSound()
    {
        myAudio.PlayOneShot(sndPickUp);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
