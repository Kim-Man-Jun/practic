using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject continueButton;
    public string firstSceneName;

    // Start is called before the first frame update
    void Start()
    {
        string sceneName = PlayerPrefs.GetString("LastScene");
        if (sceneName == "")
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            continueButton.GetComponent<Button>().interactable = true;
        }

        SoundManager.soundManager.PlayBgm(BGMType.Title);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButtonClicked()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerHp", 3);
        PlayerPrefs.SetString("LastScene", firstSceneName);
        RoomManager.doorNumber = 0;

        SceneManager.LoadScene(firstSceneName);
    }

    public void ContinueButtonClicked()
    {
        string sceneName = PlayerPrefs.GetString("LastScene");
        RoomManager.doorNumber = PlayerPrefs.GetInt("LastDoor");
        SceneManager.LoadScene(sceneName);
    }
}
