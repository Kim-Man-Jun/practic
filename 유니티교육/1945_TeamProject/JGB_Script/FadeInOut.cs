using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    public bool fadeInOnStart = true;
    public bool fadeOutOnExit = true;

    public Image panel;

    private void Awake()
    {
        panel.gameObject.SetActive(true);
    }
    void Start()
    {
        StartCoroutine(FadeOut());
    }
    float a = 1;
    IEnumerator FadeIn()
    {
        while (panel.color.a < 1)
        {
            a += Time.deltaTime * fadeSpeed;
            panel.color = new Color(0, 0, 0, a);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        while (panel.color.a > 0)
        {
            a -= Time.deltaTime * fadeSpeed;
            panel.color = new Color(0, 0, 0, a);
            Destroy(panel.gameObject ,2f);
            yield return null;
        }
    }
}