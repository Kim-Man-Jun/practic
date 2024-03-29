using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distanceX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.gameObject.transform.Translate(distanceX, 0, 0);

        float distanceY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        this.gameObject.transform.Translate(0, distanceY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);          //collision의 게임 오브젝트 파괴

            Destroy(gameObject);                    //자기자신을 파괴
        }
    }
}
