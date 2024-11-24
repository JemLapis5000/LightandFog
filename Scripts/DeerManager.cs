using System.Collections;
using UnityEngine;

public class DeerManager : MonoBehaviour
{
    public GameObject[] deerObjects;  // Assign the deer GameObjects in the Inspector
    public float appearanceDelay = 5f;  // Delay between each deer's appearance
    public float animationDuration = 5f; // Duration for the animation before disappearing

    void Start()
    {
        // Ensure all deer start inactive
        foreach (GameObject deer in deerObjects)
        {
            deer.SetActive(false);
        }

        // Start the cycle of showing deer
        StartCoroutine(ShowDeerCycle());
    }

    IEnumerator ShowDeerCycle()
    {
        while (true)
        {
            for (int i = 0; i < deerObjects.Length; i++)
            {
                deerObjects[i].SetActive(true); // Activate the deer
                yield return new WaitForSeconds(animationDuration); // Wait for animation to complete
                deerObjects[i].SetActive(false); // Deactivate the deer
                yield return new WaitForSeconds(appearanceDelay); // Delay before the next deer
            }

            // Loop restarts after all deer complete their animation
        }
    }
}
