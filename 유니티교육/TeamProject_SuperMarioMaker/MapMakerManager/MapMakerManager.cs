using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MapMaker_Camera : MonoBehaviour
{
    public Sprite selectBlock;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
    }

    public void MouseClick()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            GameObject click_obj = hit.transform.gameObject;

            if (click_obj.layer == 6)
            {
                click_obj.GetComponent<SpriteRenderer>().sprite = selectBlock;
                click_obj.GetComponent<SpriteRenderer>().color = Color.white;
            }

            if (click_obj.layer == 5)
            {
                Sprite click_obj_Sprite =  click_obj.GetComponent<Image>().sprite;
                selectBlock = click_obj_Sprite;
            }
        }
    }
}
