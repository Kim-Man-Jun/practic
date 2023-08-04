using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG2_WJ : MonoBehaviour
{
    public float scrollSpeed = 0.005f;
    Material myMaterial;
    public GameObject nextStage;
    public Transform Player;

    void Start()
    {
     myMaterial = GetComponent<Renderer>().material;   
    }

    // Update is called once per frame
    void Update()
    {
        float newOffsetY = myMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);
        myMaterial.mainTextureOffset = newOffset;
    }
}
