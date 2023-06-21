using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayTest : MonoBehaviour
{
    Text txttest;
    public string[] Inventory = new string[6];
    public int num;
    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        txt.text = $"{num + 1}번" + " " + Inventory[num];

        Debug.Log("Inventory[0] : " + Inventory[0]);
        Debug.Log("Inventory[1] : " + Inventory[1]);
        Debug.Log("Inventory[2] : " + Inventory[2]);
        Debug.Log("Inventory[3] : " + Inventory[3]);
        Debug.Log("Inventory[4] : " + Inventory[4]);
        Debug.Log("Inventory[5] : " + Inventory[5]);

        Debug.Log("Inventory[0] + Inventory[2] : " + Inventory[0] + " " + Inventory[2]);
        Debug.Log("Inventory[1] + Inventory[3] : " + Inventory[1] + " " + Inventory[3]);
        Debug.Log("Inventory[4] + Inventory[5] : " + Inventory[4] + " " + Inventory[5]);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
