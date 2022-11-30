using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //Animation variables
    [SerializeField] private Animator unlockedDoorAnim;
    [SerializeField] private Animator lockedDoorAnim;
    //[SerializeField] private Animator door02Anim;
    private float delayAmount = 7f;

    //public AudioSource gasAudio;

    private void Awake()
    {
        unlockedDoorAnim = GetComponentInChildren<Animator>();
        lockedDoorAnim = GetComponentInChildren<Animator>();
    }

    //Triggers the open animation for the door
    public void LockedDoorAnimationTriggerFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lockedDoorAnim.SetBool("isTriggered", true);

            StartCoroutine(CloseLockedDoor());
        }
    }
    private IEnumerator CloseLockedDoor()
    {
        yield return new WaitForSeconds(delayAmount);
        lockedDoorAnim.SetBool("isTriggered", false);
    }


    public void UnlockedDoorAnimationTriggerFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            unlockedDoorAnim.SetBool("Door02", true);

            //door02Anim.SetBool("Door02", true);

            StartCoroutine(CloseUnlockedDoor());
        }
    }
    private IEnumerator CloseUnlockedDoor()
    {
        yield return new WaitForSeconds(delayAmount);
        unlockedDoorAnim.SetBool("Door02", false);

        //door02Anim.SetBool("Door02", false);
    }
}
