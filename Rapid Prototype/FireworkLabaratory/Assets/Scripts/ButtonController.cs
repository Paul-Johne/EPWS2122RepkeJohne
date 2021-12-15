using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void OnAndOff()
    {
        if (VFXControl.isPlaying)
        {
            VFXControl.isPlaying = false;
        }
        else
        {
            VFXControl.isPlaying = true;
        }
    }
}
