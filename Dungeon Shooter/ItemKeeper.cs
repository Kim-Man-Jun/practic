using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKeeper : MonoBehaviour
{
    public static int hasKeys = 0;
    public static int hasArrows = 5;

    // Start is called before the first frame update
    void Start()
    {
        hasKeys = PlayerPrefs.GetInt("keys");
        hasArrows = PlayerPrefs.GetInt("Arrows");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SaveItem()
    {
        PlayerPrefs.SetInt("Keys", hasKeys);
        PlayerPrefs.SetInt("Arrows", hasArrows);

    }
}
