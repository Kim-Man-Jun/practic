using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public ParticleSystem shellExplosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            ParticleSystem fire = Instantiate(shellExplosion, transform.position, Quaternion.identity);
            fire.Play();
            Destroy(gameObject);
            Destroy(fire.gameObject, 1f);
        }

    }
}
