using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LighthouseLight : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed at which the light rotates

    void Update()
    {
        // Rotate the spotlight around its up (Y) axis.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
