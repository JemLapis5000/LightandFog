using UnityEngine;

public class CloudSpawnerAndMover : MonoBehaviour
{
    // The cloud prefab to instantiate
    public GameObject cloudPrefab;

    // Spawn parameters
    public float spawnInterval = 2f; // Time interval between spawns
    public float cloudSpeed = 1f; // How fast the clouds rise
    public float maxYPosition = 50f; // Y position where the clouds are destroyed
    public Vector2 xZVariation = new Vector2(3f, 3f); // Variation in the x and z axes

    // Scale parameters for cloud size
    public bool usePrefabScale = true; // Use the prefab's original scale
    public Vector2 scaleRange = new Vector2(0.8f, 1.2f); // Range for random scale (min, max)

    private float spawnTimer = 0f;

    void Update()
    {
        // Increment the timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a cloud
        if (spawnTimer >= spawnInterval)
        {
            SpawnCloud();
            spawnTimer = 0f;
        }
    }

    void SpawnCloud()
    {
        // Spawn position with variation in x and z axes
        Vector3 spawnPosition = new Vector3(
            transform.position.x + Random.Range(-xZVariation.x, xZVariation.x),
            transform.position.y,
            transform.position.z + Random.Range(-xZVariation.y, xZVariation.y)
        );

        // Instantiate the cloud at the calculated position
        GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);

        // Attach the cloud to the spawner (so it rotates with the island)
        cloud.transform.parent = transform;

        // Adjust the cloud's scale
        if (usePrefabScale)
        {
            // If usePrefabScale is true, we keep the original prefab scale
            cloud.transform.localScale = cloudPrefab.transform.localScale;
        }
        else
        {
            // Otherwise, we randomize the scale within a certain range
            float randomScaleFactor = Random.Range(scaleRange.x, scaleRange.y);
            cloud.transform.localScale = cloudPrefab.transform.localScale * randomScaleFactor;
        }

        // Start moving the cloud upwards
        StartCoroutine(MoveCloud(cloud));
    }

    System.Collections.IEnumerator MoveCloud(GameObject cloud)
    {
        // Continuously move the cloud upwards until it reaches the maxYPosition
        while (cloud != null && cloud.transform.position.y < maxYPosition)
        {
            // Move the cloud upwards
            cloud.transform.Translate(Vector3.up * cloudSpeed * Time.deltaTime, Space.World);

            // Wait for the next frame
            yield return null;
        }

        // Destroy the cloud once it has reached or exceeded the max Y position
        if (cloud != null)
        {
            Destroy(cloud);
        }
    }
}
