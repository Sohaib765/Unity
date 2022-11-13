using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //Animation variables
    public Animator doorAnim;
    private float delayAmount = 7f;

    //public AudioSource gasAudio;

    //Triggers the open animation for the door
    public void AnimationTriggerFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorAnim.SetBool("isTriggered", true);

            StartCoroutine(CloseDoor());
        }
    }

    //Coroutine that triggers the close animation for the door after a set amount of time
    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(delayAmount);

        doorAnim.SetBool("isTriggered", false);
    }
}
