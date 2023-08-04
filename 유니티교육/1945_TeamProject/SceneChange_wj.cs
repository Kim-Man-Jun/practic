using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_wj : MonoBehaviour
{
    public string sceneName;
    public void LoadStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
