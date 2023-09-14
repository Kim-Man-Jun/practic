using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Moving")]
    private float axisH;
    private float axisV;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");

        if (axisH == 0 && axisV == 0)
        {
            anim.SetBool("Run", false);
        }

        else if (axisH != 0 || axisV != 0)
        {
            anim.SetBool("Run", true);
            if (axisH > 0)
            {
                sr.flipX = false;
                rb.velocity = new Vector2(moveSpeed * axisH, rb.velocity.y);
            }
            else if (axisH < 0)
            {
                sr.flipX = true;
                rb.velocity = new Vector2(moveSpeed * axisH, rb.velocity.y);
            }

            if (axisV > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, moveSpeed * axisV);
            }

            else if (axisV < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, moveSpeed * axisV);
            }
        }
    }
}
