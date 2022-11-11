using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour
{
    public Transform cameraPosition;
    
    void Update()
    {
        transform.position = cameraPosition.position;

        //gun.transform.position = camera.transform.position + offset;
    }
}
