using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SaveManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip saveSound;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))                  //아이워너 세이브기 때문에 총알 맞을 경우
        {
            DataManager dataManager = FindObjectOfType<DataManager>();  //객체 생성
            dataManager.Saveprocedure();

            audio.PlayOneShot(saveSound);
        }
    }
}
//https://ansohxxn.github.io/categories/#unity-lesson-3
