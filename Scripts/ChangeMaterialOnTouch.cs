using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialsOnClick : MonoBehaviour
{
    public Material[] blackMaterials; // Assign the black materials array in the inspector
    public Material[] colorMaterials; // Assign the corresponding color materials array in the inspector
    private Renderer objectRenderer;
    private bool isBlack = true; // Track current state of materials

    void Start()
    {
        // Get the Renderer component of the GameObject
        objectRenderer = GetComponent<Renderer>();
        
        // Ensure the arrays match the number of materials on the renderer
        if (objectRenderer != null && blackMaterials.Length == objectRenderer.materials.Length)
        {
            Material[] materials = objectRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                // Set each initial material to the corresponding black material in the array
                materials[i] = blackMaterials[i];
            }
            objectRenderer.materials = materials;
        }
        else
        {
            Debug.LogError("Mismatch in blackMaterials array length and renderer materials length.");
        }
    }

    void OnMouseDown()
    {
        // Toggle each material between black and color based on the current state
        if (objectRenderer != null && blackMaterials.Length == colorMaterials.Length)
        {
            Material[] materials = objectRenderer.materials;

            // Toggle each material based on the current state
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = isBlack ? colorMaterials[i] : blackMaterials[i];
            }

            // Update the materials array with the new materials
            objectRenderer.materials = materials;

            // Toggle the boolean state
            isBlack = !isBlack;
        }
        else
        {
            Debug.LogError("Mismatch in blackMaterials and colorMaterials array lengths.");
        }
    }
}
