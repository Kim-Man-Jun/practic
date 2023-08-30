using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public void BtnExcute()
    {
        GameObject.FindWithTag("Slot").BroadcastMessage("RandomGatch");
    }
}
