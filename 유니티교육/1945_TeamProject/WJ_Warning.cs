using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WJ_Warning : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;  //�ؽ�Ʈ ��������
    TextMeshProUGUI textBossWarning;    //���ܳ��ٰ�
    //��ü�� ��Ȱ��ȭ �Ҷ��� start�Լ� x -> Awake���

    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();  //�̰��� 'ĳ��' �̶���
    }

    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");  //�ڷ�ƾ ����
    }
    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            //���� White -> Red Change
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            //������ Red -> White
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    //�ڷ�ƾ �Լ��� ������ �ε巴�� �ٲ۴�.
    IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            //lerpTime �ð����� while �ݺ����� ����
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            //Text-TextMesh�� ��Ʈ ������ startColor���� endColor�� ����
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }
}