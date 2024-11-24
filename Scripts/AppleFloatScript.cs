using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFloat : MonoBehaviour
{
    public float floatHeight = 2f;     // Height the apple will float upwards
    public float floatDuration = 1f;   // Time taken to rise and fall
    public float rotationSpeed = 360f; // Speed of rotation (degrees per second)

    private Vector3 originalPosition;  // To store the initial position
    private bool isAnimating = false;  // Prevents multiple clicks during animation

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (!isAnimating)
        {
            StartCoroutine(FloatAndRotate());
        }
    }

    IEnumerator FloatAndRotate()
    {
        isAnimating = true;
        Vector3 targetPosition = originalPosition + Vector3.up * floatHeight;

        // Floating up
        yield return AnimateMovement(originalPosition, targetPosition, floatDuration / 2);
        
        // Rotating while stationary at the top
        yield return RotateOverTime(floatDuration);

        // Floating back down
        yield return AnimateMovement(targetPosition, originalPosition, floatDuration / 2);

        isAnimating = false;
    }

    IEnumerator AnimateMovement(Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = end;
    }

    IEnumerator RotateOverTime(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}

