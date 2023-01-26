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
    if(PlaerController.gameState == "gameover")
    {
      mainImage.SetActive(true);
      panel.SetActive(true);
      Button bt = nextButton.GetComponent<Button>();
      bt.interactable = false;
      mainImage.GetComponent<Image>().sprite = gameOverSpr;
      PlayerController.gameState = "gameend";
      else if(PlayerController.gameState == "playing")
      {
      }
    }
    
    void InactiveImage()
    {
      mainImage.SetActive(false);
    }
  }
  
}
