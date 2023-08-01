using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    Material material;
    AudioSource SG;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;

        SG = GetComponent<AudioSource>();

        SG.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float newOffsetY = material.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);

        material.mainTextureOffset = newOffset;

        if (BossController.BossAppear > 0)
        {
            SG.Stop();
        }
    }
}
