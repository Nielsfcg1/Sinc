using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

    public AudioSource source;

    public AudioClip switchFrameClip;

    public void SwitchFrame()
    {
        source.PlayOneShot(switchFrameClip);
    }
}