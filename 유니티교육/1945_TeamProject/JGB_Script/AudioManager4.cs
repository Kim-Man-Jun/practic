using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager4 : MonoBehaviour
{
    public AudioClip soundExplosion; //재생할 소리를 변수로 담습니다.
    public AudioClip soundbomerang;
    public AudioClip soundGetItem;
    public AudioClip soundHeal;
    public AudioClip soundBg2;
    public AudioClip gameClear;
    public AudioClip hit;
    public AudioClip super;

    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    public static AudioManager4 instance;  //자기자신을 변수로 담습니다.
    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (AudioManager4.instance == null) //incetance가 비어있는지 검사합니다.
        {
            AudioManager4.instance = this; //자기자신을 담습니다.
        }
    }
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundExplosion); //soundExplosion을 재생합니다.
    }
    public void PlayClear() 
    {
        myAudio.PlayOneShot(gameClear);
    }
    public void PlayBomerang() 
    {
        myAudio.PlayOneShot(soundbomerang);
    }
    public void PlayGetItem() 
    {
        myAudio.PlayOneShot(soundGetItem);
    }
    public void PlayHeal() {
        myAudio.PlayOneShot(soundHeal);
    }
    public void PlayBg2() 
    {
        myAudio.PlayOneShot(soundBg2);
    }
   public void StopBg2() 
    {
        myAudio.Stop();
    }
    public void Playhit()
    {
        myAudio.PlayOneShot(hit);
    }
    public void PlaySuper()
    {
        myAudio.PlayOneShot(super);
    }

    void Update()
    {
       
    }

}
