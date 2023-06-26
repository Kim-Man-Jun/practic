using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Shoot((Vector3.forward * shootspeed));
        }
        */

        Destroy(gameObject, 2.0f);
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Enemy")
        {
            Destroy(this.gameObject, 0.2f);
        }
    }
}
