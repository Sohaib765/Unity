using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;

    private float pickUpDistance = 5f;
    private bool israyHittingTheButton;
    private RaycastHit rayCastHit;
    [SerializeField] private LayerMask layerMask;

    //Animation
    public Animator buttonAnim;
    public Animator doorAnim;

    //Sound
    public AudioSource gasSound;
    public AudioSource buttonClickSound;

    //Material
    public Material buttonMaterial;
    public Material greenMaterial;
    //GameObject
    public GameObject button;

    [SerializeField] private float closeDoorAfteSometimes = 4f;

    void Start()
    {
        //Changes the color of the button to red
        button.GetComponent<MeshRenderer>().material = buttonMaterial;
    }

    
    void Update()
    {
        israyHittingTheButton = Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out rayCastHit,
                                                pickUpDistance, layerMask);

        //Checks if the ray collides with the button
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rayCastHit.collider.CompareTag("Button"))
            {
                Debug.Log("Door opened");
                buttonAnim.SetTrigger("ButtonPressed");
                doorAnim.SetBool("IsTriggered", true);

                button.GetComponent<MeshRenderer>().material = greenMaterial;
                gasSound.Play();
                buttonClickSound.Play();

                StartCoroutine(CloseDoor());
            }
        }
    }

    //Closes the door after the given amount of time
    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(closeDoorAfteSometimes);
        Debug.Log("Door closed");
       
        doorAnim.SetBool("IsTriggered", false);

        button.GetComponent<MeshRenderer>().material = buttonMaterial;
    }
}
