using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowfigureSpawner : MonoBehaviour
{
    // Prefab for the shadowfigure
    public GameObject shadowfigurePrefab;

    // Room boundaries
    public Vector3 roomSize = new Vector3(100f, 1f, 100f);

    // Center of the room
    public Vector3 roomCenter = new Vector3(50f, 0f, 50f);

    // Spawning parameters
    public int numberOfFigures = 25;
    public Vector3 initialScale = new Vector3(20f, 20f, 20f);
    public Vector3 scaleVariation = new Vector3(5f, 5f, 5f); // Adjust this for random scale range
    public float spawnInterval = 1f; // Time between spawns

    // Floating parameters
    public float floatStartY = -15f;
    public float floatEndY = 115f;
    public float floatDuration = 10f; // Time to complete the float animation

    void Start()
    {
        StartCoroutine(SpawnShadowFigures());
    }

    IEnumerator SpawnShadowFigures()
    {
        for (int i = 0; i < numberOfFigures; i++)
        {
            SpawnShadowFigure();
            yield return new WaitForSeconds(spawnInterval); // Wait before spawning the next figure
        }
    }

    void SpawnShadowFigure()
    {
        // Randomize the position within the room's XZ plane relative to the room center
        Vector3 randomPosition = new Vector3(
            roomCenter.x + Random.Range(-roomSize.x / 2, roomSize.x / 2),
            floatStartY, // Starting at the bottom
            roomCenter.z + Random.Range(-roomSize.z / 2, roomSize.z / 2)
        );

        // Randomize the scale based on the initial scale and variation
        Vector3 randomScale = initialScale + new Vector3(
            Random.Range(-scaleVariation.x, scaleVariation.x),
            Random.Range(-scaleVariation.y, scaleVariation.y),
            Random.Range(-scaleVariation.z, scaleVariation.z)
        );

        // Randomize the rotation
        Quaternion randomRotation = Quaternion.Euler(
            0f,
            Random.Range(0f, 360f), // Random Y-axis rotation
            0f
        );

        // Instantiate the shadowfigure at the random position with randomized scale and rotation
        GameObject newShadowFigure = Instantiate(shadowfigurePrefab, randomPosition, randomRotation);

        // Apply random scale
        newShadowFigure.transform.localScale = randomScale;

        // Start the floating animation
        StartCoroutine(FloatShadowFigure(newShadowFigure.transform));
    }

    IEnumerator FloatShadowFigure(Transform figureTransform)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = figureTransform.position;
        Vector3 endPosition = new Vector3(startPosition.x, floatEndY, startPosition.z);

        while (elapsedTime < floatDuration)
        {
            float t = elapsedTime / floatDuration;
            // Lerp from start to end position over the duration
            figureTransform.position = Vector3.Lerp(startPosition, endPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Once the figure reaches the top, reset the position to the start and loop the animation
        figureTransform.position = startPosition;
        StartCoroutine(FloatShadowFigure(figureTransform));
    }
}
