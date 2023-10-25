using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public BeatScroller beatScroller;
    public GameObject   buttonLine;

    public bool         canBePressed;
    public KeyCode      keyToPress;
    public GameObject   hitEffect;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                Instantiate(hitEffect, new Vector3(transform.position.x, -3.2f, 0), Quaternion.identity);

                // GameManager.instance.NoteHit();
                float judgeRange  = beatScroller.scrollSpeed / 10f;
                float judgePreset = buttonLine.transform.position.y;

                if (Mathf.Abs(transform.position.y) + judgePreset > 0.5f * judgeRange)
                {
                    Debug.Log("50");
                    GameManager.instance.Hit050();
                } else if (Mathf.Abs(transform.position.y) + judgePreset > 0.2f * judgeRange)
                {
                    Debug.Log("100");
                    GameManager.instance.Hit100();
                } else if (Mathf.Abs(transform.position.y) + judgePreset > 0.1f * judgeRange)
                {
                    Debug.Log("200");
                    GameManager.instance.Hit200();
                } else
                {
                    Debug.Log("300");
                    GameManager.instance.Hit300();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();
            }
        }
    }
}