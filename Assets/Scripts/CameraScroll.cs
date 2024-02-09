using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    Camera c;
    void Start() 
    {
        c = GetComponent<Camera>();
    }

    void Update() 
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0) 
        {
            c.orthographicSize += scroll * -20;
        }
    }
}
