using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float Speed = 10.0f;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(10);
            //폭발 이벤트 생성
            Instantiate(Explosion, transform.position, Quaternion.identity);
            SoundManager.instance.SoundDie(); //죽음 사운드 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    //OnBecameInvisible() 화면 밖으로 나가서 안 보이게 되면 호출이 되는 함수
    private void OnBecameInvisible()
    {
        //미사일이 화면 밖으로 나갈때 파괴
        Destroy(gameObject);
    }

}
