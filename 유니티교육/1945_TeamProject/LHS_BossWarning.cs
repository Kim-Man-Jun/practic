using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LHS_BossWarning : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;
    Text textBossWarning;
    float curTime = 0f;

    private void Awake()
    {
        textBossWarning = GetComponent<Text>();
    }

    //Ȱ��ȭ �ɶ�
    private void OnEnable()
    {
        //�ڷ�ƾ ����
        StartCoroutine("ColorLerpLoop");
    }

    //��Ȱ��ȭ
    private void OnDisable()
    {

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

            // Text - TextMeshPro�� ��Ʈ ������ startColor���� endColor�� ����
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }

    void Update()
    {
        curTime += Time.deltaTime;

        if (curTime >= 2.5f)
        {
            gameObject.SetActive(false);
        }
    }
}

