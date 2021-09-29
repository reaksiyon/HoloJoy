using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Transform Cam;

    private void Start()
    {
        if (Cam == null)
            Cam = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(Cam); 
    }
}
