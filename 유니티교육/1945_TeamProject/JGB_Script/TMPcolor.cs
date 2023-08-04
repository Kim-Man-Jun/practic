using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPcolor : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;
    TextMeshProUGUI textBossWarning;


    //��ü�� ��Ȱ��ȭ �Ҷ��� start�Լ� x
    private void Awake()
    {
        //ĳ��
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }

    //Ȱ��ȭ�ɶ�
    private void OnEnable()
    {
        //�ڷ�ƾ ����
        StartCoroutine("ColorLerpLoop");
    }


    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            //������ �Ͼ������ ����������
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            //������ ���������� �Ͼ������
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }
    //�ڷ�ƾ�Լ� ������ �ε巴�� �ٲ۴�.
    IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            //lerpTime �ð����� while() �ݺ��� ����
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            //Text - TextMeshPro�� ��Ʈ ������ startColor���� endColor�� ����
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);
            // �� ������ ��ٸ�
            yield return null;
        }
    }
}