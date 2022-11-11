using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    
    void Start()
    {
        playerController = GameObject.Find("FirstPersonController").GetComponent<PlayerController>();
       
        playerController.isGameActive = true;

    }

    
    void Update()
    {
        
    }
}
