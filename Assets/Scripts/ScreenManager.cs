using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public  Image       fadeInOutScreen;
    public  float       fadeSpeed = 1.0f;
    private bool        isFadingOut = false;

    public  GameObject  startButton;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScreen(string screenName)
    {
        StartCoroutine(FadeOut(screenName));
    }

    IEnumerator FadeIn()
    {
        float alpha = 1.0f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeInOutScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(string screenName)
    {
        if (isFadingOut)
            yield break;

        isFadingOut = true;

        float alpha = 0.0f;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeInOutScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(screenName);
    }

    public void ClickStart()
    {
        FadeToScreen("SelectMusic");
    }

    public void ClickBack()
    {
        FadeToScreen("MainScreen");
    }

    public void ClickPlay()
    {
        FadeToScreen("GamePlay");
    }
}