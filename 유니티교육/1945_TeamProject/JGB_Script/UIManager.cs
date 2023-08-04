using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject player;
    public Text homingammotext;
    public Text superammotext;
    public float overtime;
    void Start()
    {
        Screen.SetResolution(700, 1920, true);

    }

    private void Awake()
    {
         
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            superammotext.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player4Controller>().item2.ToString();
            homingammotext.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player4Controller>().Hac.ToString();

         
        }
    }
    public  void OnBtn() 
    {
        SceneManager.LoadScene("StartScene");
    }
    
}
