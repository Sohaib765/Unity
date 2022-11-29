using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnableAndDisable : MonoBehaviour
{
    public Collider mainCollider;
    public GameObject rig;
    public Animator ragdollAnimator;

    private Collider[] ragdollColliders;
    private Rigidbody[] limbsRB;

    void Start()
    {
        GetRagdollBits();
        RagdollDisable();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RagdollEnable();
        }
    }
    
    private void GetRagdollBits()
    {
        ragdollColliders = rig.GetComponentsInChildren<Collider>();
        limbsRB = rig.GetComponentsInChildren<Rigidbody>();
    }

    private void RagdollEnable()
    {
        ragdollAnimator.enabled = false;

        foreach (Collider coll in ragdollColliders)
        {
            coll.enabled = true;
        }

        foreach (Rigidbody rigidbody in limbsRB)
        {
            rigidbody.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void RagdollDisable()
    {
        foreach(Collider coll in ragdollColliders)
        {
            coll.enabled = false;
        }

        foreach (Rigidbody rigidbody in limbsRB)
        {
            rigidbody.isKinematic = true;
        }

        ragdollAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    
}
