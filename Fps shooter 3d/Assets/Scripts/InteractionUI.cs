
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    //Raycast varibles
    public bool interactiveObjectInRange;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask interactivelayerMask;
    private RaycastHit hit;
    private float distance = 5f;

    //UI varible
    public GameObject text;
    public GameObject doorLocked_Text;

    //Script reference variable
    private AnimationHandler animationHandlerScriptRef;

    public GameObject card;

    private void Awake()
    {
        animationHandlerScriptRef = GameObject.FindGameObjectWithTag("Door").GetComponent<AnimationHandler>();
    }

    private void Update()
    {
        interactiveObjectInRange = Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit,
                                   distance, interactivelayerMask);
        
        if (interactiveObjectInRange)
        {
            Debug.Log("You can interact with this object");
            text.gameObject.active = true;

            
        }
        else
        {
            text.gameObject.active = false;

            doorLocked_Text.gameObject.active = false;
        }

        if (interactiveObjectInRange && Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("LockedDoor"))
        {
            Debug.Log("The door is locked");
            doorLocked_Text.gameObject.active = true;

            Debug.Log(hit.collider.tag);

            if (card == null)
            {
                Debug.Log("Locked door open");
                Debug.Log("card collected");
                animationHandlerScriptRef.LockedDoorAnimationTriggerFunction();

                doorLocked_Text.gameObject.active = false;
            }
        }

        if (interactiveObjectInRange && Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Door"))
        {
            animationHandlerScriptRef.UnlockedDoorAnimationTriggerFunction();

            Debug.Log("Unlocked door open");

            //animationHandlerScriptRef.lockedDoorAnim.enabled = true;
        }


    }

}