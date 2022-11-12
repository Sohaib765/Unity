using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    //[SerializeField] private Transform WeaponPoint;


    public GrabbaleObject grabbaleObject;

    //Variables for shooting the ray
    float pickUpDistance = 5f;
    private bool isRayIsHittingTheGrabbleObject;
    private RaycastHit rayCastHit;

    private GrabbaleObject obj;
    public bool isGrabbed;

    void Update()
    {
        isRayIsHittingTheGrabbleObject = Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out rayCastHit,
                    pickUpDistance, pickUpLayerMask);

        /*When the player presses the E key it grabs the objects if
        there is the "grabbableObject.Script" is attached to the object*/
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(grabbaleObject == null)
            {
                //Not carrying something, grab
                //float pickUpDistance = 10f;
                if (isRayIsHittingTheGrabbleObject)
                {
                    if (rayCastHit.transform.TryGetComponent(out grabbaleObject))
                    {
                        grabbaleObject.Grab(objectGrabPointTransform);

                        Debug.Log("Object grabbed");
                        
                        isGrabbed = true;
                    }
                }
            }
            else
            {
                //Currently carrying something, drop
                grabbaleObject.Drop();
                grabbaleObject = null;
                isGrabbed = false;
            }
        }

        if (isRayIsHittingTheGrabbleObject)
        {
            //Debug.Log("ray is hitting");
        }
    }
}
