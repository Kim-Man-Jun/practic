using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
  public UnityEngine.UI.Image fade;
  
  public bool FadeInOut;
  
  public float FadeIn = 1.0f;
  public float FadeInTime = 0.0f;
  
  public float FadeOut = 1.0f;
  public float FadeOutTime = 0.0f;

  void Start()
  {
  }
  
  void Update()
  {
    if(FadeInOut = true)
    {
      FadeInTime += Time.deltaTime;
      
      if(FadeIn > 0.0f && FadeInTime >= 0.1f)
      {
        FadeIn -= 0.1f;
        fade.color = new Color (0, 0, 0, FadeIn)
        time = 0;
    }
    
    if(FadeInOut = false)
    {
      FadeOutTime += Time.deltaTime;
      
      if(FadeOut > 0.0f && FadeOutTime >= 0.1f)
      {
        FadeOut -= 0.1f;
        fade.color = new Color (255, 255, 255, FadeIn)
        time = 0;
      }
    }
  }
}
