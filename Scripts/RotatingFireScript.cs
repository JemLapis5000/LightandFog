using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYAxis : MonoBehaviour
{
    public float rotationSpeed = 90f; // Speed of rotation (degrees per second)

    void Update()
    {
        // Calculate the rotation amount based on time and speed
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the object around the Y axis
        transform.Rotate(0, rotationAmount, 0);

        // Optionally, you could clamp it between 0 to 360 by manually setting the rotation if needed.
        // But since it's continuous, this might not be necessary for simple looping rotation.
    }
}
