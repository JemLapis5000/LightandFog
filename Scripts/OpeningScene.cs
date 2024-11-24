using UnityEngine;
using UnityEngine.UI; // For Image component
using TMPro; // For TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections; // Required for IEnumerator

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // Reference to the Image component (for the fade effect)
    public TextMeshProUGUI fadeTextMeshPro; // Reference to the TextMeshProUGUI component (for the fade effect)
    public float displayDuration = 30f; // How long to display the scene before fading (in seconds)
    public float fadeDuration = 3f; // How long the fade should last (in seconds)
    public string nextSceneName = "InkyForest"; // The name of the next scene to load

    void Start()
    {
        // Start with fully visible image and text.
        fadeImage.canvasRenderer.SetAlpha(1.0f);
        fadeTextMeshPro.alpha = 1.0f;

        // Wait for the display duration, then start fading.
        Invoke("StartFadeOut", displayDuration);
    }

    // Function to start the fade-out process
    void StartFadeOut()
    {
        // Fade out the image and text over 'fadeDuration' seconds.
        fadeImage.CrossFadeAlpha(0.0f, fadeDuration, false); // Fades the image to transparent
        StartCoroutine(FadeTextMeshPro()); // Start fading TextMeshPro
    }

    // Coroutine to fade out the TextMeshPro element
    IEnumerator FadeTextMeshPro()
    {
        float currentTime = 0f;
        float startAlpha = fadeTextMeshPro.alpha;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            fadeTextMeshPro.alpha = Mathf.Lerp(startAlpha, 0f, currentTime / fadeDuration); // Gradually reduce the alpha
            yield return null; // Wait for the next frame
        }

        fadeTextMeshPro.alpha = 0f; // Ensure it's fully transparent at the end
        LoadNextScene();
    }

    // Load the next scene
    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
