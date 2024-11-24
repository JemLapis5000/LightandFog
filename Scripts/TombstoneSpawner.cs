using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombstoneSpawner : MonoBehaviour
{
    public GameObject tombstonePrefab; // Assign the tombstone prefab here
    public Terrain terrain; // Reference to the terrain
    public int numColumns = 5; // Number of columns of tombstones
    public int numRows = 5; // Number of rows of tombstones
    public float spacing = 20f; // Distance between tombstones
    public float spotlightHeight = 6f; // Height of the spotlight above the tombstone

    void Start()
    {
        if (terrain == null)
        {
            terrain = Terrain.activeTerrain; // Automatically find the active terrain if not assigned
        }
        SpawnTombstones();
    }

    void SpawnTombstones()
    {
        // Get the position of the spawner (which should be at 0, 0, 0 or wherever the spawner is in the world)
        Vector3 spawnerPosition = transform.position;

        // Get the terrain size and position to ensure tombstones are within bounds
        Vector3 terrainPosition = terrain.GetPosition();
        Vector3 terrainSize = terrain.terrainData.size;

        // Calculate the starting point to center the grid of tombstones around the spawner
        float startX = spawnerPosition.x - (numColumns - 1) * spacing / 2f;
        float startZ = spawnerPosition.z - (numRows - 1) * spacing / 2f;

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                // Calculate X and Z for each tombstone, relative to the spawner position
                float x = startX + col * spacing;
                float z = startZ + row * spacing;

                // Ensure X and Z are within the bounds of the terrain
                if (x > terrainPosition.x + terrainSize.x - spacing || z > terrainPosition.z + terrainSize.z - spacing)
                {
                    Debug.LogWarning("Tombstone position is outside terrain bounds, skipping placement.");
                    continue; // Skip placing tombstone if it's outside the terrain bounds
                }

                // Get the height of the terrain at this position
                float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrainPosition.y;

                // Set the position for the tombstone with adjusted terrain height
                Vector3 position = new Vector3(x, y, z);

                // Instantiate the tombstone at the calculated position
                GameObject tombstone = Instantiate(tombstonePrefab, position, Quaternion.Euler(0, -180, 0));

                // Add a spotlight above the tombstone
                AddSpotlight(tombstone);
            }
        }
    }

    void AddSpotlight(GameObject tombstone)
    {
        // Create a new spotlight GameObject
        GameObject spotlight = new GameObject("Spotlight");

        // Add the Light component and configure it
        Light light = spotlight.AddComponent<Light>();
        light.type = LightType.Spot;
        light.color = Color.white;
        light.intensity = 10f; // Increased intensity
        light.spotAngle = 85f; // Slightly wider beam angle
        light.range = 5f; // Shorter distance
        light.shadows = LightShadows.Soft; // Enable shadows
        light.shadowStrength = 0.8f;

        // Set the spotlight position above the tombstone
        spotlight.transform.position = tombstone.transform.position + new Vector3(0, spotlightHeight, 0);
        spotlight.transform.SetParent(tombstone.transform); // Attach it as a child of the tombstone

        // Adjust spotlight orientation to point downwards
        spotlight.transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
