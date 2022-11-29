using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEnable : MonoBehaviour
{
    //Raycast variables
    private bool objectInRange;
    public float enableRange;
    public LayerMask interactibleLayer;

    //Script reference
    private PlayerPickupDrop pickAndDropRef;
    public PIckAndDrop gunPickAndDropRef;

    //Text variables
    public TextMeshProUGUI pickUpUI;

    private string pickUpText = "Press [E] to pick up";
    private string dropText = "Press [E] to drop";
    private string weaponPickUpText = "Press [E] to equip the weapon";

    public Collider[] collider;

    private void Awake()
    {
        //Reference of the script
        pickAndDropRef = GetComponent<PlayerPickupDrop>();
    }

    private void Update()
    {
        //Function call
        InteractibleObject();
    }

    //Checks what object is colliding with the OverLapSpere. And enables and disables UI accordingly. 
    private void InteractibleObject()
    {
        collider = Physics.OverlapSphere(transform.position, enableRange, interactibleLayer);

        foreach (Collider coll in collider)
        {
            if (coll.gameObject.CompareTag("GB_Obj"))
            {
                //Debug.Log("Object is in range");

                pickUpUI.gameObject.active = true;

                pickUpUI.SetText(pickUpText);

                if (pickAndDropRef.isGrabbed)
                {
                    pickUpUI.SetText(dropText);
                }
            }

            if (coll.gameObject.CompareTag("Weapon"))
            {
                pickUpUI.SetText(weaponPickUpText);

                pickUpUI.gameObject.active = true;
            }
        }
        if (collider.Length == 0)
        {
            //Debug.Log("Object is out of the range");

            pickUpUI.gameObject.active = false;
        }
    }


    //Draw a sphere around the player to visualize the enable range
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enableRange);
    }

}
