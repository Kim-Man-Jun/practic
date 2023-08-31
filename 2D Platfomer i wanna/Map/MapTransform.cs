using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MapTransform : MonoBehaviour
{
    public GameObject Area;

    public float LeftX = -1.52f;
    public float DownY = 5.6f;
    public float RightX = 39.4f;
    public float UpY = 29f;

    public int RoomNum;

    public bool MapMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        ChangeRoom();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeRoom()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        switch (player.PlayerNowRoom)
        {
            case 0:
                Area.transform.position = new Vector3(LeftX, DownY, 0);
                break;

            case 1:
                Area.transform.position = new Vector3(RightX, DownY, 0);
                break;

            case 2:
                Area.transform.position = new Vector3(RightX, UpY, 0);
                break;

            case 3:
                Area.transform.position = new Vector3(LeftX, UpY, 0);
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (collision.gameObject.tag == "Player")
        {
            //if (player.PlayerNowRoom < RoomNum)
            //{
            //    player.PlayerNowRoom++;
            //    ChangeRoom();
            //}

            //else if (player.PlayerNowRoom > RoomNum)
            //{
            //    player.PlayerNowRoom--;
            //    ChangeRoom();
            //}

            if (RoomNum == 0)
            {
                player.PlayerNowRoom = 0;
                ChangeRoom();
            }

            else if (RoomNum == 1)
            {
                player.PlayerNowRoom = 1;
                ChangeRoom();
            }

            else if (RoomNum == 2)
            {
                player.PlayerNowRoom = 2;
                ChangeRoom();
            }

            else if (RoomNum == 3)
            {
                player.PlayerNowRoom = 3;
                ChangeRoom();
            }

            else if (player.PlayerNowRoom == RoomNum)
            {

            }
        }
    }
}
