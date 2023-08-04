using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Buri : MonoBehaviour
{
    public float speed = 8.0f;
    public int m_Attack = 10;
    public GameObject Player_Death;
    public GameObject target;

    Vector2 dir;
    Vector2 dirNo;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - transform.position;
        dirNo = dir.normalized;
        StartCoroutine(Buri());
    }

    IEnumerator Buri()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            transform.Translate(dirNo * speed * Time.deltaTime);
            yield return null;
        }
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(Player_Death, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Player>().Damage(m_Attack);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
