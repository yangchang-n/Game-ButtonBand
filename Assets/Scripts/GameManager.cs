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
    public GameObject   score000;

    public static GameManager instance;

    public int currentCombo;
    public int currentScore;
    public int scorePerNote = 100;

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

    public void NoteHit()
    {  
        Debug.Log("Hit on Time");

        GameObject clone300 = Instantiate(score300, scorePostion, Quaternion.identity);
        Destroy(clone300, 0.2f);

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
        currentScore += scorePerNote * currentMultiplier;

        comboText.text = "" + currentCombo;
        scoreText.text = "Score : " + currentScore;
        multiplierText.text = "Multiplier : x" + currentMultiplier;
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