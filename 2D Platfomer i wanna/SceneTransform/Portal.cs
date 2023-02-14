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
  
  //사이트 주소 https://medium.com/@qldrhqorhsh/unity-tutorial-6-scene-%EB%A7%B5-%EC%9D%B4%EB%8F%99-e92d05840c2d 
}
