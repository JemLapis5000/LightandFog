using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummingbirdZMovement : MonoBehaviour
{
    public Transform pointA;  // First point in the "Z" pattern
    public Transform pointB;  // Middle point in the "Z" pattern
    public Transform pointC;  // Last point in the "Z" pattern
    public float speed = 2f;  // Movement speed between points
    public float smoothTime = 0.3f; // Time to reach each target smoothly
    public float[] pauseTimes; // Pause times for each point

    private Transform[] points;
    private int currentPointIndex = 0;
    private Vector3 velocity = Vector3.zero; // Velocity used by SmoothDamp

    void Start()
    {
        // Ensure points are set up
        if (pointA == null || pointB == null || pointC == null)
        {
            Debug.LogError("Please assign PointA, PointB, and PointC in the Inspector.");
            enabled = false;  // Disable script if points are not set
            return;
        }

        // Ensure pauseTimes array has correct size
        if (pauseTimes == null || pauseTimes.Length != 3)
        {
            Debug.LogError("Please assign exactly 3 pause times in the pauseTimes array.");
            enabled = false;  // Disable script if pauseTimes are not set correctly
            return;
        }

        // Set up the points array to follow a "Z" pattern
        points = new Transform[] { pointA, pointB, pointC };
        StartCoroutine(MoveInZPattern());
    }

    IEnumerator MoveInZPattern()
    {
        while (true) // Loop indefinitely to continue the "Z" pattern
        {
            Transform targetPoint = points[currentPointIndex];

            // Smoothly move towards the target point
            while (Vector3.Distance(transform.position, targetPoint.position) > 0.1f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPoint.position, ref velocity, smoothTime, speed);
                yield return null;
            }

            // Pause at the target point using the specific pause time for this point
            yield return new WaitForSeconds(pauseTimes[currentPointIndex]);

            // Move to the next point in the "Z" pattern
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }
}
