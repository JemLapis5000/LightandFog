using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanKick : MonoBehaviour
{
    public float kickForce = 10f;  // The force applied to the object
    public Vector3 direction = new Vector3(1, 1, 0); // The direction of the kick

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to this object!");
        }
    }

    void OnMouseDown()
    {
        // Apply a force to the Rigidbody when the object is clicked
        if (rb != null)
        {
            Vector3 appliedForce = direction.normalized * kickForce;
            rb.AddForce(appliedForce, ForceMode.Impulse);
        }
    }
}
