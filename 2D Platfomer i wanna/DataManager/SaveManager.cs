using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class SaveManager : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject Player;
    public Vector3 PlayerNowPos;
    public Vector3 PlayerNowRot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayerNowPos = Player.transform.localPosition;
            PlayerNowRot = Player.transform.localRotation.eulerAngles;

            DataManager.instance.SaveData();

            Debug.Log(PlayerNowPos);
            Debug.Log(PlayerNowRot);

        }
    }
}
//https://ansohxxn.github.io/categories/#unity-lesson-3
