using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperText : MonoBehaviour
{
    public GameObject UIForText;
    public GameObject storyText;

    [SerializeField] private bool testBool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            storyText.gameObject.active = false;
        }

        if (testBool && Input.GetKeyDown(KeyCode.R))
        {
            storyText.active = true;
            UIForText.gameObject.active = false;

            Debug.Log("Text is enabled");
            testBool = false;
        }
        else
        {
            Debug.Log("Text is diabled");
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You can read this text");

            UIForText.gameObject.active = true;

            testBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You can no longer read the text");

            UIForText.gameObject.active = false;
            storyText.gameObject.active = false;

            testBool = false;
        }
    }


}
