using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopGame : MonoBehaviour
{
    public string targetObjectName;
    public GameObject Panel;

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
        if (collision.gameObject.name == targetObjectName)
        {
            Time.timeScale = 0.0f;

            //UI패널 가져오기, 간단하게
            //GameObject.Find("Restart").SetActive(true);

            Panel.SetActive(true);
            
        }
    }
}
//게임멈추기 간단한 버전
