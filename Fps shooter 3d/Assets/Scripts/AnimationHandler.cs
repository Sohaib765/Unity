using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //Animation variables
    public Animator unlockedDoorAnim;
    public Animator lockedDoorAnim;
    private float delayAmount = 7f;

    //public AudioSource gasAudio;

    //Triggers the open animation for the door
    public void LockedDoorAnimationTriggerFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lockedDoorAnim.SetBool("isTriggered", true);

            StartCoroutine(CloseLockedDoor());
        }
    }

    public void UnlockedDoorAnimationTriggerFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            unlockedDoorAnim.SetBool("unlockedDoor", true);

            StartCoroutine(CloseUnlockedDoor());
        }
    }

    //Coroutine that triggers the close animation for the door after a set amount of time
    private IEnumerator CloseLockedDoor()
    {
        yield return new WaitForSeconds(delayAmount);
        lockedDoorAnim.SetBool("isTriggered", false);
    }

    
    private IEnumerator CloseUnlockedDoor()
    {
        yield return new WaitForSeconds(delayAmount);
        unlockedDoorAnim.SetBool("unlockedDoor", false);
    }
}
