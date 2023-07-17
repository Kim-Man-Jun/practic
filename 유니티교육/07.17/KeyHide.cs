using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHide : MonoBehaviour
{
    public string targetName = "Player";

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
        if (collision.gameObject.name == targetName)
        {
            this.gameObject.SetActive(false);
            //PlayerData playerData = new PlayerData();
            //playerData.KeyCount++;
            //Debug.Log(playerData.KeyCount);

            GameObject.Find(targetName).GetComponent<PlayerData>().KeyCounter++;

        }
    }
}
