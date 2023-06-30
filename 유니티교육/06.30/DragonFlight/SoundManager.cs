using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;    //자기 자신을 변수로 담음, 싱글톤
    public AudioClip soundShoot;
    public AudioClip soundDie;
    AudioSource myAudio;

    private void Awake()        //start보다 빠름
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);
    }

    public void PlaySound()
    {
        myAudio.PlayOneShot(soundShoot);
    }
}
