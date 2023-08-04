using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_bullet_wj : MonoBehaviour
{
    public float BulletSpeed = 6f;
    Vector2 vec2 = Vector2.down;
    void Update()
    {
        transform.Translate(vec2 * BulletSpeed * Time.deltaTime);
    }
    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
