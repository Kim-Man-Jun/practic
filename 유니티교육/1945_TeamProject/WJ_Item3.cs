using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Item3 : MonoBehaviour
{
    public float ItemVelocity = 10f;
    Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }
}
