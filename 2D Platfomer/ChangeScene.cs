using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
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
