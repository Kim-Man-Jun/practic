using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float LeftLimit;
    public float RightLimit;
    public float TopLimit;
    public float BottomLimit;

    public GameObject SubScreen;

    public bool isForceScrollX = false;
    public float forceScrollSpeedX = 0.5f;
    public bool isForceScrollY = false;
    public float forceScrollSpeedY = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if (Player != null)
        {
            float x = Player.transform.position.x;
            float y = Player.transform.position.y;
            float z = transform.position.z;

            if (isForceScrollX == true)
            {
                x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
            }

            if (isForceScrollY == true)
            {
                y = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
            }

            if (x < LeftLimit)
            {
                x = LeftLimit;
            }
            else if (x > RightLimit)
            {
                x = RightLimit;
            }
            if (y > TopLimit)
            {
                y = TopLimit;
            }
            else if (y < BottomLimit)
            {
                y = BottomLimit;
            }

            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;

            if (SubScreen != null)
            {
                y = SubScreen.transform.position.y;
                z = SubScreen.transform.position.z;
                Vector3 v = new Vector3(x / 2, y, z);
            }

        }
    }
}
