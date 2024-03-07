using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //private float rotateLever;
    //private void Start()
    //{
    //    rotateLever = Mathf.Abs(gameObject.transform.localRotation.eulerAngles.z);
    //}
    private static readonly float maxRotateRange = 35f;
    private float initialRotation;

    [HideInInspector] public bool isLever = false;

    private Vector3 initialPosition;

    private void Start()
    {
        initialRotation = transform.localRotation.eulerAngles.z;
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        float currentRotation = transform.localRotation.eulerAngles.z - initialRotation;

        if (currentRotation >= maxRotateRange && currentRotation < 180f)
        {
            isLever = true;
            currentRotation = maxRotateRange;
        }
        else if(currentRotation > 180f && currentRotation < 360f - maxRotateRange)
        {
            isLever = false;
            currentRotation = 360f - maxRotateRange ;
        }

        transform.localRotation = Quaternion.Euler(0, 0, initialRotation + currentRotation);

        transform.localPosition = initialPosition;
    }
}
