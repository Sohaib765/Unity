using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 roamPosition;

    void Start()
    {
        startPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        //pathFindingMovement.MoveTo(roamPosition);
    }

    //Get a roaming position for the enemy to move towards
    private Vector3 GetRoamingPosition()
    {
        return startPosition + GetRandomDir() * Random.Range(5f, 10f);
    }

    //Calculate random position on x and y axis
    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void FindTraget()
    {
        float tragetRange = 50f;
        
    }
}
