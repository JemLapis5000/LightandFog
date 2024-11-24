using UnityEngine;

public class SwayRotation : MonoBehaviour
{
    public float swaySpeed = 1f;  // How fast the swaying occurs
    public float swayAmount = 5f;  // How much rotation (degrees)
    private Quaternion startRotation;

    void Start()
    {
        // Save the starting rotation of the object
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Calculate new Z rotation using a sine wave for smooth side-to-side motion
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        // Apply the sway to the object's rotation (X-axis for side-to-side)
        transform.rotation = startRotation * Quaternion.Euler(0f, 0f, sway);
    }
}
