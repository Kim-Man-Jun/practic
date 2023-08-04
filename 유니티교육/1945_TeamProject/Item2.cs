using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    public float ItemVelocity = 10f;
    Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }

    private void OnTriggerEnter2D(Collider2D g_item)
    {
        if(g_item.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 20);
    }
}
