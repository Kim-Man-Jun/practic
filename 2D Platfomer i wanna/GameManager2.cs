using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
  public static GameManager instance;
  
  public bool isGameover = false;
  public GameObject gameoverUI;
  
  void Awake()
  {
    if(instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  void Start()
  {
  }
  
  void Update()
  {
  }
  
}
