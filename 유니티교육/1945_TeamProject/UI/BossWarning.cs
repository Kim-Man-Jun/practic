using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossWaring : MonoBehaviour
{
    [SerializeField]
    float lerptime = 0.2f;
    TextMeshProUGUI textBossWarning;

    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();
        Destroy(textBossWarning, 2.5f);
    }

    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }

    IEnumerator ColorLerpLoop()
    {
        while (this)
        {
            //옷 색상을 하얀색에서 빨간색으로
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            //옷 색상을 빨간색에서 하얀색으로
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    //색깔을 부드럽게 바꾸기
    IEnumerator ColorLerp(Color startcolor, Color endcolor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            //lerptime 시간 동안 while 반복 실행
            currentTime += Time.deltaTime;
            percent = currentTime / lerptime;

            //startcolor에서 endcolor로 변경
            textBossWarning.color = Color.Lerp(startcolor, endcolor, percent);

            yield return null;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
