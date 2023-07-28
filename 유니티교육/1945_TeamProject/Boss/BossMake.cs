using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMake : MonoBehaviour
{
    [SerializeField] GameObject textBossWarning;
    [SerializeField] GameObject BossMaxHpBar;
    [SerializeField] GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BossController.BossAppear == 1)
        {
            StartCoroutine("BossAppearWarning");
        }
    }

    IEnumerator BossAppearWarning()
    {
        yield return new WaitForSeconds(2f);

        textBossWarning.SetActive(true);
        BossMaxHpBar.SetActive(true);
        Boss.SetActive(true);

        BossController.BossAppear = 0;
    }
}
