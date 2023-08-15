using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 180f;

    [System.NonSerialized]
    public int money = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }

    public void SetCoinVBalue(int money)
    {
        this.money = money;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerParams>().AddMoney(money);

            SoundManager.instance.PlayPickUpSound();

            //Destroy(gameObject);

            RemoveFromWorld();
        }
    }

    public void RemoveFromWorld()
    {
        gameObject.SetActive(false);
    }
}
