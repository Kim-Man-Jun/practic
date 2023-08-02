using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject TapBtn;

    // Start is called before the first frame update
    void Start()
    {
        BackGround.SetActive(false);
        TapBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowBack()
    {
        BackGround.SetActive(true); 
        TapBtn.SetActive(true);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Village");
    }
}
