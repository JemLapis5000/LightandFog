using UnityEngine;

public class CustomWindEffect : MonoBehaviour
{
    public Vector3 windDirection = Vector3.forward;  // The direction of the wind (adjust to the axis you want)
    public float windStrength = 1.0f;  // How strong the wind is
    public float swayAmount = 10.0f;  // Maximum amount of swaying or bending
    public float swaySpeed = 1.0f;    // Speed at which the object sways
    
    private Quaternion initialRotation;  // Store the object's initial rotation

    void Start()
    {
        // Save the initial rotation to ensure we rotate around it
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Calculate the sway factor using a sine wave for smooth oscillation
        float swayFactor = Mathf.Sin(Time.time * swaySpeed) * swayAmount * windStrength;

        // Create a sway rotation based on the wind direction and sway factor
        Quaternion swayRotation = Quaternion.Euler(windDirection.normalized * swayFactor);

        // Apply the sway rotation to the object's initial rotation
        transform.rotation = initialRotation * swayRotation;
    }
}
