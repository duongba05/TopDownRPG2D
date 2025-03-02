using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] private Image fadedScreen;
    [SerializeField] private float fadeSpeed = 1f;

    private IEnumerator fadeRountine;

    public void FadeToBlack()
    {
        if(fadeRountine != null)
        {
            StopCoroutine(fadeRountine);    
        }
        fadeRountine = FadeRoutine(1);
        StartCoroutine(fadeRountine);
    }
    public void FadeToClear()
    {
        if (fadeRountine != null)
        {
            StopCoroutine(fadeRountine);
        }
        fadeRountine = FadeRoutine(0);
        StartCoroutine(fadeRountine);
    }
    private IEnumerator FadeRoutine(float targetAlpha)
    {
        while (!Mathf.Approximately(fadedScreen.color.a, targetAlpha))
        {
            float alpha = Mathf.MoveTowards(fadedScreen.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadedScreen.color = new Color(fadedScreen.color.r, fadedScreen.color.g, fadedScreen.color.b, alpha);
            yield return null;
        }
    }
}
