using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rigid = null;
    Vector3 lastVelocity;

    public Vector3 MovePos;
    public float ItemVelocity = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        int rnd = Random.Range(1, 5);
        if (rnd == 1)
        {
            rigid.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
        }
        else if (rnd == 2)
        {
            rigid.AddForce(new Vector3(-ItemVelocity, ItemVelocity, 0f));
        }
        else if (rnd == 3)
        {
            rigid.AddForce(new Vector3(ItemVelocity, -ItemVelocity, 0f));
        }
        else if (rnd == 4)
        {
            rigid.AddForce(new Vector3(-ItemVelocity, -ItemVelocity, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "PowerUp")
            {
                PlayerController.WeaponPower++;
                if (PlayerController.WeaponPower >= 3)
                {
                    PlayerController.WeaponPower = 3;
                }

                Debug.Log(PlayerController.WeaponPower);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Bomb")
            {
                PlayerController.Bomb++;
                Debug.Log(PlayerController.Bomb);
                Destroy(gameObject);
            }
        }
    }
}
