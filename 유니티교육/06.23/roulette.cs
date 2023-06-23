using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    public List<string> list = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        int ran = Random.Range(0, 22); // 0~21

        Debug.Log("반장 당첨 : "+list[ran]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
