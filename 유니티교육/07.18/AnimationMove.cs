using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManPlayerAnimation : MonoBehaviour
{
    Animator anima;
    public string nowMode = "";
    public string UpAnim = "";
    public string DownAnim = "";
    public string RightAnim = "";
    public string LeftAnim = "";

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        nowMode = DownAnim;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            nowMode = UpAnim;
        }
        if (Input.GetKey("down"))
        {
            nowMode = DownAnim;
        }
        if (Input.GetKey("left"))
        {
            nowMode = LeftAnim;
        }
        if (Input.GetKey("right"))
        {
            nowMode = RightAnim;
        }

        anima.Play(nowMode);
    }
}
