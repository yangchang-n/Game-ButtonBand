using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource  sampleMusic;
    public bool         startPlaying;
    public BeatScroller beatScroller;

    public Vector3      scorePostion = new Vector3(0, 1.5f, 0);
    public GameObject   score300;
    public GameObject   score200; // score200 sprite 구하기
    public GameObject   score100;
    public GameObject   score050;
    public GameObject   score000;

    public static GameManager instance;

    public int currentCombo;
    public int currentScore;
    // public int currentAccuracy; // Accuracy 시스템 만들기

    public int scorePerNote = 100;
    public int scorePer300 = 300;
    public int scorePer200 = 200;
    public int scorePer100 = 100;
    public int scorePer050 = 50;
    public int scorePer000 = 0;

    // public float accuracy300 = 100;
    // public float accuracy200 = 60;
    // public float accuracy100 = 25;
    // public float accuracy050 = 10;
    // public float accuracy000 = 0;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[]    multiplierThresholds;

    public TMP_Text comboText;
    public TMP_Text scoreText;
    public TMP_Text multiplierText;

    void Start()
    {
        instance = this;

        scoreText.text = "Score : 0";
        currentMultiplier = 1;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;

                sampleMusic.Play();
            }
        }
    }

    public void NoteHit() // 각 Hit에 따라 점수 prefab destroy할 방법 찾기
    {  
        Debug.Log("Hit on Time");

        // GameObject clone300 = Instantiate(score300, scorePostion, Quaternion.identity);
        // Destroy(clone300, 0.2f);

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker ++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                currentMultiplier ++;
                multiplierTracker = 0;
            }
        }

        currentCombo ++;
        // currentScore += scorePerNote * currentMultiplier;

        comboText.text = "" + currentCombo;
        scoreText.text = "Score : " + currentScore;
        multiplierText.text = "Multiplier : x" + currentMultiplier;
    }

    public void Hit300()
    {
        GameObject clone300 = Instantiate(score300, scorePostion, Quaternion.identity);
        Destroy(clone300, 0.2f);
        currentScore += scorePer300 * currentMultiplier;
        NoteHit();
    }

    public void Hit200()
    {
        GameObject clone200 = Instantiate(score200, scorePostion, Quaternion.identity);
        Destroy(clone200, 0.2f);
        currentScore += scorePer200 * currentMultiplier;
        NoteHit();
    }

    public void Hit100()
    {
        GameObject clone100 = Instantiate(score100, scorePostion, Quaternion.identity);
        Destroy(clone100, 0.2f);
        currentScore += scorePer100 * currentMultiplier;
        NoteHit();
    }

    public void Hit050()
    {
        GameObject clone050 = Instantiate(score050, scorePostion, Quaternion.identity);
        Destroy(clone050, 0.2f);
        currentScore += scorePer050 * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        GameObject clone000 = Instantiate(score000, scorePostion, Quaternion.identity);
        Destroy(clone000, 0.2f);

        currentCombo = 0;
        currentMultiplier = 1;
        multiplierTracker = 0;

        comboText.text = "";
        multiplierText.text = "Multiplier : x" + currentMultiplier;
    }
}