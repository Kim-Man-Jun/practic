using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

public class MapTransform : MonoBehaviour
{
    public GameObject AreaCamera;

    public float LeftX = -1.52f;
    public float DownY = 5.6f;
    public float RightX = 39.4f;
    public float UpY = 29f;

    public int RoomNum = 0;
    private int nowRoomNum;

    public bool MapMoving = false;
    public float MovingSpeed = 50f;

    private void Start()
    {
        nowRoomNum = RoomNum;
    }

    private void Update()
    {
        //switch (nowRoomNum)
        //{
        //    case 0:
        //        AreaCamera.transform.position = new Vector2(LeftX, DownY);
        //        break;
        //    case 1:
        //        AreaCamera.transform.position = new Vector2(RightX, DownY);
        //        break;
        //    case 2:
        //        AreaCamera.transform.position = new Vector2(RightX, UpY);
        //        break;
        //    case 3:
        //        AreaCamera.transform.position = new Vector2(LeftX, UpY);
        //        break;
        //}

        if (MapMoving == true)
        {
            if (nowRoomNum == 0)
            {
                AreaCamera.transform.position = new Vector2(LeftX, DownY);

                if (AreaCamera.transform.position.x == LeftX
                    && AreaCamera.transform.position.y == DownY)
                {
                    MapMoving = false;
                }
            }

            else if (nowRoomNum == 1)
            {
                AreaCamera.transform.position = new Vector2(RightX, DownY);

                if (AreaCamera.transform.position.x == RightX
                    && AreaCamera.transform.position.y == DownY)
                {
                    MapMoving = false;
                }
            }

            else if (nowRoomNum == 2)
            {
                AreaCamera.transform.position = new Vector2(RightX, UpY);
            }

            else if (nowRoomNum == 3)
            {
                AreaCamera.transform.position = new Vector2(LeftX, UpY);
            }

            else
            {
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(nowRoomNum);
        print(MapMoving);
        if (collision.gameObject.tag == "Player")
        {
            if (MapMoving == false)
            {
                if (nowRoomNum <= RoomNum)
                {
                    nowRoomNum++;
                    MapMoving = true;
                }

                if (nowRoomNum >= RoomNum)
                {
                    nowRoomNum--;
                    MapMoving = true;
                }
            }

            //if (nowRoomNum == RoomNum)
            //{
            //    return;
            //}
        }
    }
}
