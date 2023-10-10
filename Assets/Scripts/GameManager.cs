using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource  sampleMusic;
    public bool         startPlaying;
    public BeatScroller beatScroller;

    public GameObject   score300;
    public GameObject   score000;

    public static GameManager instance;

    // public int currentScore;
    // public int scorePerNote = 100;

    // public Text scoreText;
    // public Text multiplierText;

    void Start()
    {
        instance = this;

        // scoreText.text = "Score : 0";
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

        Vector3 scorePostion = new Vector3(0, 2f, 0);
        GameObject clone300 = Instantiate(score300, scorePostion, Quaternion.identity);
        Destroy(clone300, 0.2f);

        // currentScore += scorePerNote;
        // scoreText.text = "Score : " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        Vector3 scorePostion = new Vector3(0, 2f, 0);
        GameObject clone000 = Instantiate(score000, scorePostion, Quaternion.identity);
        Destroy(clone000, 0.2f);
    }
}