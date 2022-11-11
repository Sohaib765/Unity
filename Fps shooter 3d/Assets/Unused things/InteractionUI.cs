using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    /*public TextMeshProUGUI _pickUP_UI;

    [HideInInspector]
    public string _pickUpText = "Press [E] to pick up";

    [HideInInspector]
    public string _dropText = "Press [E] to drop";

    [HideInInspector]
    public string _weaponPickUpText = "Press [E] to equip weapon";

    [HideInInspector]
    public string _weaponDropText = "Press [Q] to drop weapon";

    private PlayerPickupDrop refScript;

    private void Awake()
    {
        refScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickupDrop>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(refScript.grabbaleObject == null)
            {
                _pickUP_UI.gameObject.active = true;
                _pickUP_UI.SetText(_pickUpText);


                Debug.Log("Player is in pick up range");
            }
            else
            {
                _pickUP_UI.gameObject.active = true;
                _pickUP_UI.SetText(_dropText);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(refScript.grabbaleObject != null)
            {
                _pickUP_UI.gameObject.active = true;
                Debug.Log("Player is out of pick up range");
            }
            else
            {
                _pickUP_UI.gameObject.active = false;
            }
        }
    }*/

}
