using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField]
    float lerptime = 0.1f;
    TextMeshProUGUI textBossWarning;

    //객체를 비활성화 했을 때는 start가 동작 X
    private void Awake()
    {
        //캐싱 작업 : 가져오기 작업을 뜻함
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }

    //활성화 될 때
    private void OnEnable()     //활성화 될때
    {
        StartCoroutine("ColorLerpLoop");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
