using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFade : MonoBehaviour
{
    [SerializeField] private Color color;

    [SerializeField] private float speed = 10f;

    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        //Move towards zero
        color.a = Mathf.Lerp(color.a, 0, Time.deltaTime * speed);

        //Update colors
        lr.startColor = color;
        lr.endColor = color; 
    }
}
