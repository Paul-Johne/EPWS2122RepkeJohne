using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class VFXControl : MonoBehaviour
{
    public static bool isPlaying = false;
    //Light flairLight;

    /*void Start()
    {
        flairLight = GetComponentInChildren<Light>();
    }*/

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlaying = !isPlaying;
        }*/

        if (isPlaying)
        {
            GetComponent<VisualEffect>().Play();
            GetComponentInChildren<Light>().intensity = 40;
        }
        else
        {
            GetComponent<VisualEffect>().Stop();
            GetComponentInChildren<Light>().intensity = 0;
        }
    }
}
