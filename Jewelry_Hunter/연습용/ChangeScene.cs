using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Monoehaviour
{
  public string sceneName;
  
  void Start()
  {
  }
  
  void Update()
  {
  }
  
  public void Load()
  {
    SceneManager.LoadScene(sceneName);
  }
}
