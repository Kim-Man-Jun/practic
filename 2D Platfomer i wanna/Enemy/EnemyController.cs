using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string Direction;
    public Vector2 velocity;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (Direction == "Left")
        {
            spriteRenderer.flipX = true;
        }

        else if (Direction == "Right")
        {
            spriteRenderer.flipX = false;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        rb.AddForce(velocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2f);
    }
}
