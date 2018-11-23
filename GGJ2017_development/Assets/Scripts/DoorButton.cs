using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

    public AudioSource source;

    public AudioClip switchFrameClip;

    public void SwitchFrame()
    {
        source.PlayOneShot(switchFrameClip);
    }

    void Update()
    {
        if (Input.GetAxis("Cross") > 0)
        {
            Application.Quit();
        }
    }
}