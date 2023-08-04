using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4BG2 : MonoBehaviour
{
    public float scrollSpeed = 0.01f;
    Material myMaterial;
    public float TimeCount;
    public GameObject nextStage;
    public Transform player;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        nextStage.SetActive(false);
        player.transform.position = new Vector3(0, -12, 0);
        AudioManager4.instance.PlayBg2();

    }


    void Update()
    {
       


            float newOffsetY = myMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
            Vector2 newOffset = new Vector2(0, newOffsetY);

            myMaterial.mainTextureOffset = newOffset;
       
    }


     
        
}
