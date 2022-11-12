using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator doorAnim;

    //public AudioSource gasAudio;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("IsTriggered", true);
            Debug.Log("Open");

            gasAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("IsTriggered", false);
            Debug.Log("Close");
        }
    }*/

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
