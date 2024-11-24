using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab; // Reference to the tree prefab
    public Terrain terrain; // Reference to the Terrain
    public int numberOfTrees = 100; // Number of trees to spawn
    public float planeSize = 600f; // The size of the area where trees will be placed
    public Vector3 treeScale = new Vector3(100f, 100f, 100f); // Scale for the trees

    void Start()
    {
        SpawnTreesOnTerrain();
    }

    void SpawnTreesOnTerrain()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            // Generate random X and Z positions within the terrain bounds
            float x = Random.Range(0, planeSize); 
            float z = Random.Range(0, planeSize);

            // Get the y position (height) from the terrain at the given x and z coordinates
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.GetPosition().y;

            // Set the position of the tree
            Vector3 position = new Vector3(x, y, z);

            // Create the tree at the specified position with random rotation
            GameObject tree = Instantiate(treePrefab, position, Quaternion.Euler(0, Random.Range(0f, 360f), 0));

            // Scale the tree to the desired size
            tree.transform.localScale = treeScale;

            // Optionally parent the tree to keep the hierarchy clean
            tree.transform.parent = this.transform;
        }
    }
}
