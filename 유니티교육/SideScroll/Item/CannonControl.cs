using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.VFX;

public class CannonControl : MonoBehaviour
{
    public GameObject objPrefab;
    GameObject Player;
    GameObject gateObj;

    public float DelayYTime = 3f;
    public float FireSpeedX = -4f;
    public float FireSpeedY = 0;
    public float Length = 8.0f;

    float passedTimes = 0;


    // Start is called before the first frame update
    void Start()
    {
        Transform tr = transform.Find("gate");
        gateObj = tr.gameObject;

        //플레이어
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        passedTimes += Time.deltaTime;

        if (CheckLength(Player.transform.position))
        {
            if (passedTimes > DelayYTime)
            {
                passedTimes = 0;
                GameObject obj = Instantiate(objPrefab, gateObj.transform.position,
                    Quaternion.identity);
                Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2(FireSpeedX, FireSpeedY);
                rbody.AddForce(v, ForceMode2D.Impulse);
            }
        }
    }

    bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;

        float d = Vector2.Distance(transform.position, targetPos);

        if (Length >= d)
        {
            ret = true;
        }
        return ret;
    }
}
