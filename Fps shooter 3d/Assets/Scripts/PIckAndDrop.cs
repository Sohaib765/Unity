using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PIckAndDrop : MonoBehaviour
{
    //Script reference
    public Gun gunScriptRef;

    public Rigidbody rb;
    public Collider coll;
    public Transform player, gunContainer, fpsCamera;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    //Sounds
    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private AudioSource dropSound;

    //UI
    public GameObject ammoCountUI;
    public GameObject weaponDropTextUI;

    //Animations
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

        if (!equipped)
        {
            gunScriptRef.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
       
        if (equipped)
        {
            gunScriptRef.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;

            slotFull = true;
        }

        //Set layer to default from the start
        gameObject.layer = LayerMask.NameToLayer("Weapon");

        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Weapon");

            foreach(Transform subChild in child)
            {
                subChild.gameObject.layer = LayerMask.NameToLayer("Weapon");
            }
        }
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();

            weaponDropTextUI.SetActive(true);
            ammoCountUI.SetActive(true);

            Debug.Log("AmmoCount enabled");

            anim.SetBool("isPicked", true);
        }

        //Drop if gun is equipped and "Q" is pressed
        if(equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();

            weaponDropTextUI.SetActive(false);
            ammoCountUI.SetActive(false);
            gunScriptRef.reloadTXT_UI.gameObject.SetActive(false);

            Debug.Log("AmmoCount disabled");

            anim.SetBool("isPicked", false);
        }
    }

    //Pick up function
    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);//gunContainer.localRotation;
        transform.localScale = Vector3.one;

        //Make rigidbody kinematic and box collider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        gunScriptRef.enabled = true;

        //Play pick up sound
        pickUpSound.Play();

        //Set layer of the root game obdject to "EquippedWeaponLayer"
        gameObject.layer = LayerMask.NameToLayer("EquippedWeaponLayer");
        //Set layers of the child game objects to "EquippedWeaponLayer"
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("EquippedWeaponLayer");
            Debug.Log("Layer has been changed");

            foreach (Transform subChild in child)
            {
                subChild.gameObject.layer = LayerMask.NameToLayer("EquippedWeaponLayer");
            }
        }
        //Debug.Log("Layer has been changed");

        //Debug.Log(gameObject.name);
    }

    //Drop function
    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent
        transform.SetParent(null);

        //Make rigidbody not kinematic and box collider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momuntun of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(fpsCamera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCamera.up * dropUpwardForce, ForceMode.Impulse);

        //Random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10f); 

        //Disable script
        gunScriptRef.enabled = false;

        //Play drop sound
        dropSound.Play();

        //Set layer back to default when drop the game object
        gameObject.layer = LayerMask.NameToLayer("Weapon");
        //Set layers of the child game objects back to "EquippedWeaponLayer"
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Weapon");

            foreach (Transform subChild in child)
            {
                subChild.gameObject.layer = LayerMask.NameToLayer("Weapon");
            }
        }
    }
}
