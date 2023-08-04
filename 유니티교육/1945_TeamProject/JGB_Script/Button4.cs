using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button4 : MonoBehaviour
{
 
    public void OnClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
