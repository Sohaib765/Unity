using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabbaleObject : MonoBehaviour
{
    private Rigidbody objectRigidBody;

    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidBody.useGravity = false;
        objectRigidBody.drag = 5f;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidBody.useGravity = true;
        objectRigidBody.drag = 0f;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 8f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);

            objectRigidBody.MovePosition(newPosition);
        }
    }
}
