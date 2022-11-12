using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator doorAnim;

    //public AudioSource gasAudio;

    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            doorAnim.SetBool("isTriggered", true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            doorAnim.SetBool("isTriggered", false);
        }
    }
}
