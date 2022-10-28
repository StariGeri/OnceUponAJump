using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class bgScroller : MonoBehaviour
{
    public float scrollSpeed = -2f;
    public Camera cam;

    /*void Update() 
    {
        transform.position += new Vector3(scrollSpeed * Time.deltaTime,0);

        if(transform.position.x  < -18.7)
        {
            transform.position = new Vector3(134.2f,transform.position.y);
        }
    }*/

    // the backgrounds move themselves in front of the camera after the camera left them
    void Update() 
    {
        transform.position += new Vector3(scrollSpeed * Time.deltaTime,0);

        if(transform.position.x + 38.5f < cam.transform.position.x)
        {
            transform.position = new Vector3(cam.transform.position.x + 38.5f,transform.position.y);
        }
    }
}