using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using DG.Tweening;

public class ScreenSwitcher : MonoBehaviour
{
    // public CanvasGroup Fade_img;
    // float fadeDuration = 2;

    // public static ScreenSwitcher Instance
    // {
    //     get
    //     {
    //         return Instance;
    //     }
    // }

    // private static ScreenSwitcher instance;

    // void Start()
    // {
    //     if (instance != null)
    //     {
    //         DestroyImmediate(this.gameObject);
    //         return;
    //     }
    //     instance = this;

    //     DontDestroyOnLoad(gameObject);
    // }

    // public void ChangeScene()
    // {
    //     Fade_img.DOFade(1, fadeDuration)
    //     .OnStart(() =>
    //     {
    //         Fade_img.blocksRaycasts = true;
    //     })
    //     .OnComplete(() =>
    //     {
    //     });
    // }

    public void ClickStartButton()
    {
        SceneManager.LoadScene("MusicSelection");
    }

    public void ClickStartMusic()
    {
        SceneManager.LoadScene("GamePlay");
    }
}