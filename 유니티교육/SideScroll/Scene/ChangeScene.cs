using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public string SceneNameRe;

    public void RestartLoad()
    {
        SceneManager.LoadScene(SceneNameRe);
    }

    public void Load()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
