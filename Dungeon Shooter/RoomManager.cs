using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public static int doorNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];
            Exit exit = doorObj.GetComponent<Exit>();
            if (doorNumber == exit.doorNumber)
            {
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y;

                if (exit.direction == ExitDirection.up)
                {
                    y += 2;
                }
                if (exit.direction == ExitDirection.down)
                {
                    y -= 2;
                }
                if (exit.direction == ExitDirection.left)
                {
                    x -= 2;
                }
                if (exit.direction == ExitDirection.right)
                {
                    x += 2;
                }
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y);
                break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ChangeScene(string scenename, int doornum)
    {
        doorNumber = doornum;
        SceneManager.LoadScene(scenename);
    }
}
