using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Monster5 : Monster4
{

    private void Start()
    {
        CancelInvoke();
    }
    
    void DFire() 
    {
        BulletPos.Rotate(0, 0, 45);
        Instantiate(Bullet, transform.position, BulletPos.rotation);
    }
 

}
