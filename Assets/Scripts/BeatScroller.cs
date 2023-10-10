using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public  float   beatTempo;
    public  float   multipleSpeed;
    public  float   scrollSpeed;
    public  bool    hasStarted;

    void Start()
    {
        scrollSpeed = beatTempo * multipleSpeed / 60f;
    }

    void Update()
    {
        if (!hasStarted)
        {
            /*
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
            */
        }
        else
        {
            transform.position -= new Vector3(0f, scrollSpeed * Time.deltaTime, 0f);
        }
    }
}