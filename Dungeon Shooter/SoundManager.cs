using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType
{
    None,
    Title,
    InGame,
    InBoss,
}

public enum SEType
{
    GameClear,
    GameOver,
    Shoot,
}

public class SoundManager : MonoBehaviour
{
    public AudioClip bgmInTitle;
    public AudioClip bgmInGame;
    public AudioClip bgmInBoss;

    public AudioClip meGameClear;
    public AudioClip meGameOver;
    public AudioClip seShoot;

    public static SoundManager soundManager;

    public static BGMType plyingBGM = BGMType.None;

    // Start is called before the first frame update

    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBgm(BGMType type)
    {
        if (type != plyingBGM)
        {
            plyingBGM = type;
            AudioSource audio = GetComponent<AudioSource>();

            if (type == BGMType.Title)
            {
                audio.clip = bgmInTitle;
            }
            else if (type == BGMType.InGame)
            {
                audio.clip = bgmInGame;
            }
            else if (type == BGMType.InBoss)
            {
                audio.clip = bgmInBoss;
            }
            audio.Play();
        }
    }

    public void StopBgm()
    {
        GetComponent<AudioSource>().Stop();
        plyingBGM = BGMType.None;
    }

    public void SEPlay(SEType type)
    {
        if (type == SEType.GameClear)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameClear);
        }
        else if (type == SEType.GameOver)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameOver);
        }
        else if (type == SEType.Shoot)
        {
            GetComponent<AudioSource>().PlayOneShot(seShoot);
        }
    }
}
