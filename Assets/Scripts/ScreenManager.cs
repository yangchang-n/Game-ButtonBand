using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public  Image       loadingScreen;
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
            loadingScreen.color = new Color(0, 0, 0, alpha);
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
            loadingScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(screenName);
    }

    public void ClickStartButton()
    {
        FadeToScreen("MusicSelection");
    }

    public void ClickStartMusic()
    {
        FadeToScreen("GamePlay");
    }
}