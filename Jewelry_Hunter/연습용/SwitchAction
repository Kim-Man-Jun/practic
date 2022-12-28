using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAction : MonoBehaviour
{
  public GameObject targetMoveBlock;
  public Sprite imageOn;
  public Sprite imageOff;
  public bool on = false;
  
  void Start()
  {
    if(on)
    {
      GetComponent<SpriteRenderer>().sprite = imageOn;
    }
    else
    {
      GetComponent<SpriteRenderer>().sprite = imageOff;      
    }
  }
  
  void Update()
  {
  }
  
  void OnTriggerEnter2D(Collider2D col)
  {
    if(col.gameObject.tag == "Player")
    {
      if(on)
      {
        on = false;
        GetComponent<SpriteRenderer>().sprite = imageOff;
        MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
        movBlock.Stop();
      }
      else
      {
        GetComponent<SpriteRenderer>().sprite = imageOn;
        MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
        movBlock.Move();
      }
    }
  }
}
