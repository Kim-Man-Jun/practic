using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet_dead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.48f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
