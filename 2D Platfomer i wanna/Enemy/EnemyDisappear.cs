using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisappear : MonoBehaviour
{
    public GameObject AppearEnemy;
    public GameObject AppearBlock;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = AppearEnemy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

       if (collision.gameObject.tag == "Player" && AppearBlock == true)
        {
            print("xjcl");
            AppearBlock.SetActive(false);
        }

        else if(collision.gameObject.tag == "Dead")
        {
            rb.gravityScale = 4f;
        }
    }
}
