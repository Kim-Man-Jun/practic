using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int level = 0;
    public int hp = 0;
    public float atk = 0f;

    [SerializeField]
    int KeyCount = 0;

    public int KeyCounter { get { return KeyCount; } set { KeyCount = value; } }    //이거 중요함

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
