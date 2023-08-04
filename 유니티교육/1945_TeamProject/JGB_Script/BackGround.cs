using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 0.01f;
    Material myMaterial;
    public float TimeCount;
    public GameObject nextStage;
    public Transform next;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }


    void Update()
    {
        if (TimeCount <= 17)
        {

        
        float newOffsetY = myMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);

        myMaterial.mainTextureOffset = newOffset;
        }
        TimeCount += Time.deltaTime;

        if (TimeCount > 7.5)
        {
            next.transform.Translate(Vector2.down * 3 * Time.deltaTime);
        }
        if(TimeCount > 7.5) 
        {
            nextStage.SetActive(true);
        }
    }



}
