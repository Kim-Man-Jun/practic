using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class S4Item : MonoBehaviour
{
    public int flag = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 6.5f)
            flag *= -1;
        if (transform.position.x <= -6.5f)
            flag *= -1;
        transform.Translate(flag * 6 * Time.deltaTime, 0, 0);

    }
}
