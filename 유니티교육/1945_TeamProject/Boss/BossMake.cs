using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMake : MonoBehaviour
{
    [SerializeField] GameObject textBossWarning;
    [SerializeField] GameObject BossMaxHpBar;
    [SerializeField] GameObject Boss;

    public GameObject StageClear;

    private void Awake()
    {
        StageClear.SetActive(false);
    }

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

        if (BossController.BossClear == true)
        {
            StartCoroutine(Clear());
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

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(3.5f);
        StageClear.SetActive(true);
    }

    public void StageSelect()
    {
        SceneManager.LoadScene("StartScene");
    }
}
