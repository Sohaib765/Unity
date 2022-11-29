using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperText : MonoBehaviour
{
    public GameObject UIForText;
    public GameObject storyText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            storyText.gameObject.active = false;
        }

        if (UIForText.gameObject.active == true && Input.GetKeyDown(KeyCode.R))
        {
            storyText.gameObject.active = true;

            UIForText.gameObject.active = false;

            Debug.Log("Text is enabled");
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You can no longer read the text");

            UIForText.gameObject.active = false;
        }
    }


}
