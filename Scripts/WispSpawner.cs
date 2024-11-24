using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispSpawner : MonoBehaviour
{
    public GameObject wispPrefab; // Assign the wisp prefab here
    public Terrain terrain; // Reference to the terrain
    public int numGroups = 10; // Number of wisp groups to spawn
    public int minWispsInGroup = 1; // Minimum number of wisps per group
    public int maxWispsInGroup = 1; // Maximum number of wisps per group
    public float groupAreaRadius = 40f; // The radius within which each group’s wisps will be spread

    void Start()
    {
        // Check if the wispPrefab is assigned
        if (wispPrefab == null)
        {
            Debug.LogError("WispPrefab is not assigned. Please assign the wisp prefab in the Inspector.");
            return; // Exit the Start method to avoid further errors
        }

        // Automatically find the active terrain if not assigned
        if (terrain == null)
        {
            terrain = Terrain.activeTerrain;
            if (terrain == null)
            {
                Debug.LogError("Terrain is not assigned and no active terrain was found.");
                return; // Exit the Start method if no terrain is found
            }
        }

        SpawnWispGroups();
    }

    void SpawnWispGroups()
    {
        // Get the terrain size to make sure wisps spawn within bounds
        Vector3 terrainSize = terrain.terrainData.size;
        Vector3 terrainPosition = terrain.GetPosition();

        for (int i = 0; i < numGroups; i++)
        {
            // Randomly choose X and Z positions within the terrain boundaries
            float x = Random.Range(terrainPosition.x, terrainPosition.x + terrainSize.x);
            float z = Random.Range(terrainPosition.z, terrainPosition.z + terrainSize.z);

            // Sample the terrain height at this X and Z position
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrainPosition.y;

            // Create a new GameObject to act as the wisp group container
            GameObject wispGroup = new GameObject("WispGroup");
            wispGroup.transform.position = new Vector3(x, y, z); // Set the position of the group

            // Determine how many wisps to spawn in this group
            int groupSize = Random.Range(minWispsInGroup, maxWispsInGroup + 1);

            // Spawn individual wisps within this group
            for (int j = 0; j < groupSize; j++)
            {
                SpawnWisp(wispGroup.transform);
            }
        }
    }

    void SpawnWisp(Transform groupTransform)
    {
        // Create a new wisp from the prefab
        GameObject wisp = Instantiate(wispPrefab);

        // Randomly place the wisp within a radius around the group's position
        float offsetX = Random.Range(-groupAreaRadius / 2, groupAreaRadius / 2);
        float offsetZ = Random.Range(-groupAreaRadius / 2, groupAreaRadius / 2);
        float offsetY = Random.Range(2f, 6f); // Random height for the wisps (above ground)

        // Set the wisp's position relative to the group center
        Vector3 localPosition = new Vector3(offsetX, offsetY, offsetZ);
        wisp.transform.position = groupTransform.position + localPosition;

        // Check if the wisp has a Light component and customize the light if it exists
        Light wispLight = wisp.GetComponent<Light>();
        if (wispLight != null)
        {
            wispLight.color = new Color(Random.value, Random.value, Random.value); // Random color
            wispLight.intensity = Random.Range(0.5f, 1.5f); // Random light intensity
        }
        else
        {
            Debug.LogWarning("Wisp prefab does not have a Light component.");
        }

        // Parent the wisp to the group
        wisp.transform.SetParent(groupTransform);
    }
}
