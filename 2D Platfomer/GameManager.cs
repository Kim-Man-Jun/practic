using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public GameObject mainImage;
  public Sprite gameOverSpr;
  public GameObject panel;
  public GameObject restartButton;
  
  Image titleImage;
  
  void Start()
  {
    Invoke("InactiveImage", 1.0f);
    panel.SetActive(false);
  }
  
  void Update()
  {
  }
  
}
