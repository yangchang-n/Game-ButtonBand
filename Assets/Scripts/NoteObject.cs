using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool         canBePressed;
    public KeyCode      keyToPress;
    // public BeatScroller beatScroller;

    void Start()
    {
        // beatScroller = GetComponent<BeatScroller>();
        // float ms = beatScroller.multipleSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                // GameManager.instance.NoteHit();
                if ((transform.position.y < -0.25 * 1 - 3.2) || (transform.position.y > 0.5 * 1 - 3.2)) // preset, multiSpeed 관련 구현 필요
                {
                    Debug.Log("50");
                    GameManager.instance.Hit050();
                } else if ((transform.position.y < -0.1 * 1 - 3.2) || (transform.position.y > 0.2 * 1 - 3.2))
                {
                    Debug.Log("100");
                    GameManager.instance.Hit100();
                } else if ((transform.position.y < -0.05 * 1 - 3.2) || (transform.position.y > 0.1 * 1 - 3.2))
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