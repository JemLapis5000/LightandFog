using UnityEngine;

public class ContinuousLoopAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isAnimating = false;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        
        // Ensure the animation is not playing initially
        animator.speed = 0f;
    }

    void Update()
    {
        // Check if the object is clicked with the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                // If the object is clicked, start the animation
                if (!isAnimating)
                {
                    isAnimating = true;
                    animator.speed = 1f; // Start playing the animation

                    // Ensure the animation loops continuously
                    animator.Play("YourAnimationStateName", -1, 0f); // Replace with your animation state name
                }
            }
        }
    }
}
