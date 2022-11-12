using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator doorAnim;

    //public AudioSource gasAudio;

    public void Update()
    {
        StartCoroutine(CloseDoor());
    }

    public void AnimationTriggerFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorAnim.SetBool("isTriggered", true);
        }
    }

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5f);

        doorAnim.SetBool("isTriggered", false);
    }
}
