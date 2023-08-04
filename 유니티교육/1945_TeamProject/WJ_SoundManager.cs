using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_SoundManager : MonoBehaviour
{
    public static WJ_SoundManager instance;
    public AudioClip soundExplosion;
    public AudioClip soundDie;
    public AudioClip Shooting;
    public AudioClip Lazer;
    public AudioClip GameOver;
    public AudioClip Clear;
    public AudioClip BossBGM;
    //

    [Header("∏ÛΩ∫≈Õ∫“∑ø")]
    public AudioClip MBullet1;
    public AudioClip MBullet2;
    public AudioClip MBullet3;
    public AudioClip Thunder;
    public AudioClip CircleFire;
    public AudioClip drill;
    //
    AudioSource myAudio;

    public void Awake()
    {
        if(WJ_SoundManager.instance == null)
        {
            WJ_SoundManager.instance = this;
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void ExplosionSound()
    {
        myAudio.PlayOneShot(soundExplosion);
    }

    public void ShootSound()
    {
        myAudio.PlayOneShot(Shooting);
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);
    }

    public void LazerSound()
    {
        myAudio.PlayOneShot(Lazer);
    }
    public void BossSound()
    {
        myAudio.PlayOneShot(BossBGM);
    }

    public void drillSound() { myAudio.PlayOneShot(drill);}
    public void BasicMonster() { myAudio.PlayOneShot(MBullet1); }
    public void HomingMonster() { myAudio.PlayOneShot(MBullet2); }
    public void lazerMonster() { myAudio.PlayOneShot(MBullet3); }
    public void ThunderBoss() { myAudio.PlayOneShot(Thunder); }
    public void CircleSound() { myAudio.PlayOneShot(CircleFire); }
    public void OverSound() { myAudio.PlayOneShot(GameOver); }
    public void ClearSound() { myAudio.PlayOneShot(Clear); }

    void Update()
    {
        
    }
}
