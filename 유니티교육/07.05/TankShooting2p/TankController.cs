using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public int playerNum = 1;
    string MoveSpeedAxisName;
    string RotAxisName;
    float MoveSpeed = 10.0f;        //탱크 속도
    float RotSpeed = 150.0f;        //탱크 회전속도

    public Color tankColor;


    // Start is called before the first frame update
    void Start()
    {
        MoveSpeedAxisName = "Vertical" + playerNum;
        RotAxisName = "Horizontal" + playerNum;

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = tankColor;
            renderers[i].material.color = tankColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mv = Input.GetAxis(MoveSpeedAxisName) * MoveSpeed * Time.deltaTime;
        float rot = Input.GetAxis(RotAxisName) * RotSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, rot, 0);
    }
}
