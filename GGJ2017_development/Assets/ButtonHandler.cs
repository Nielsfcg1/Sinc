using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {
    public Animator animR;
    public Animator animL;
	// Update is called once per frame
	void Update ()
    {
        animR.SetFloat("RightHand", (Input.GetAxis("RightStick") / 2) + 0.5f);
        animL.SetFloat("LeftHand", (Input.GetAxis("LeftStick") / 2) + 0.5f);

    }
}
