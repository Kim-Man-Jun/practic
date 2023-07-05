using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ParticleSystem targetExplosion;

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
        if (collision.collider.CompareTag("Shell"))
        {
            ParticleSystem fire = Instantiate(targetExplosion, transform.position, Quaternion.identity);
            fire.Play();

            Destroy(gameObject);
            Destroy(fire.gameObject, 1f);
        }
    }
}
