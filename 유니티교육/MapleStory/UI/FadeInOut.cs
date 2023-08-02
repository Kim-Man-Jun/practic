using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    public bool fadeInOnStart = true;
    public bool fadeOutOnExit = true;

    public Image Panel;


    private void Awake()
    {
        Panel.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    float a = 1;

    IEnumerator FadeIn()
    {
        while (Panel.color.a < 1)
        {
            a += Time.deltaTime * fadeSpeed;
            Panel.color = new Color(0, 0, 0, a);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        while (Panel.color.a > 0)
        {
            a -= Time.deltaTime * fadeSpeed;
            Panel.color = new Color(0, 0, 0, a);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
