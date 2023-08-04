using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm4 : MonoBehaviour
{
    public GameObject clearPanel;
    public bool isSound  = false;
    private void Update()
    {
        if(isSound == false) { 
        openPanel();
        }

    }

    void openPanel()
    {
        if (TotalGm.instance.isClear4 == true)
        {
            AudioManager4.instance.PlayClear();
            clearPanel.SetActive(true);
            isSound = true;
        }


    }
 
}
