using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator doorAnim;

    public AudioSource gasAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Medium cube"))
        {
            doorAnim.SetBool("IsTriggered", true);
            Debug.Log("Open");

            gasAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Medium cube"))
        {
            doorAnim.SetBool("IsTriggered", false);
            Debug.Log("Close");
        }
    }
}
