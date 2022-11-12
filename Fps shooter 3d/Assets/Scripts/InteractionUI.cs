using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public bool interactiveObjectInRange;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask interactivelayerMask;
    private RaycastHit ray;
    private float distance = 5f;

    public GameObject text;

    private AnimationHandler animationHandlerScriptRef;

    private void Awake()
    {
        animationHandlerScriptRef = GetComponent<AnimationHandler>();
    }

    private void Update()
    {
        interactiveObjectInRange = Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out ray,
                                   distance, interactivelayerMask);

        if (interactiveObjectInRange)
        {
            Debug.Log("You cam interact with this object");
            text.gameObject.active = true;
        }
        else
        {
            text.gameObject.active = false;
        }

        if(interactiveObjectInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("sdfefefe");

            animationHandlerScriptRef.AnimationTriggerFunction();

        }
    }

}
