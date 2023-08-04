using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WJ_Warning : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;  //텍스트 깜빡깜빡
    TextMeshProUGUI textBossWarning;    //숨겨놨다가
    //객체를 비활성화 할때는 start함수 x -> Awake사용

    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();  //이것을 '캐싱' 이라함
    }

    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");  //코루틴 생성
    }
    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            //색상 White -> Red Change
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            //색상을 Red -> White
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    //코루틴 함수의 색깔을 부드럽게 바꾼다.
    IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            //lerpTime 시간동안 while 반복문을 실행
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            //Text-TextMesh의 폰트 색상을 startColor에서 endColor로 변경
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }
}