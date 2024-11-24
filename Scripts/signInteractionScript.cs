using UnityEngine;

public class SignInteraction : MonoBehaviour
{
    public ParticleSystem geyser; // Named as "geyser" to reflect your particle system

    void Start()
    {
        // Ensure the geyser particle system is not playing at the start
        if (geyser != null)
        {
            geyser.Stop(); // Stops the particle system if it's playing
        }
    }

    void Update()
    {
        // Check if left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the point where the mouse clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hit the sign's collider
            if (Physics.Raycast(ray, out hit))
            {
                // If the sign was clicked
                if (hit.collider.gameObject == gameObject)
                {
                    // Start the geyser particle system
                    if (geyser != null && !geyser.isPlaying)
                    {
                        geyser.Play();
                    }
                }
            }
        }
    }
}
