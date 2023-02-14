using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
  public string transferMapName;
  Private Player thePlayer;
  
  void Start()
  {
    if(thePlayer == null)
    {
      thePlayer = FindObjectOfType<Player>();
    }
  }
  
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.CompareTag("Player"))
    {
      thrPlayer.currentMapName = transferMapName;
      SceneManager.LoadScene(transferMapName);
    }
  }
}
