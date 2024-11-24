using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of the rotation

    void Update()
    {
        // Rotate the object on the Z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
