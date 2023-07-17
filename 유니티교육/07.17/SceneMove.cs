using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public PlayerController playerController;
    public string SceneName;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(playerController.KeyOnOff);

            if (playerController.KeyOnOff == true)
            {
                SceneManager.LoadScene(SceneName);
                playerController.KeyOnOff = false;
            }
        }
    }
}
