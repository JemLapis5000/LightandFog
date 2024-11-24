using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishMovementLoop : MonoBehaviour
{
    [Header("Movement Settings")]
    public GameObject fishGroup;   // Attach the fish group here
    public float speed = 1f;       // Speed of movement

    [Header("Positions")]
    public Vector3 startPosition = new Vector3(485, 3, 445);
    public Vector3 endPosition = new Vector3(1035, 3, 445);

    private void Start()
    {
        if (fishGroup == null)
        {
            Debug.LogError("No fish group assigned to the script!");
            return;
        }

        // Set fish group to the starting position at the beginning
        fishGroup.transform.position = startPosition;

        // Start the movement loop
        StartCoroutine(MoveFishLoop());
    }

    private IEnumerator MoveFishLoop()
    {
        while (true) // Infinite loop to keep the movement going
        {
            // Move fish from start to end
            yield return StartCoroutine(MoveToPosition(startPosition, endPosition));
            
           
        }
    }

    private IEnumerator MoveToPosition(Vector3 start, Vector3 end)
    {
        float journeyLength = Vector3.Distance(start, end);
        float startTime = Time.time;
        float fractionOfJourney = 0;

        while (fractionOfJourney < 1)
        {
            float distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            fishGroup.transform.position = Vector3.Lerp(start, end, fractionOfJourney);
            yield return null; // Wait for the next frame
        }
    }
}

