using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // The TextMeshPro object
    public Image panel; // The UI Panel
    public float displayDuration = 20f; // Duration for which text and panel are visible
    public float fadeDuration = 2f; // Duration of the fade-out effect

    private Color originalTextColor;
    private Color originalPanelColor;
    private float elapsedTime = 0f;

    void Start()
    {
        // Store the original colors
        originalTextColor = textMeshPro.color;
        originalPanelColor = panel.color;

        // Start with full opacity
        textMeshPro.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, 1);
        panel.color = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, 1);
    }

    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // After displayDuration, start fading out the text and panel
        if (elapsedTime > displayDuration)
        {
            float fadeAmount = Mathf.Clamp01((elapsedTime - displayDuration) / fadeDuration);

            // Fade out text and panel simultaneously
            textMeshPro.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, 1 - fadeAmount);
            panel.color = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, 1 - fadeAmount);

            // Once faded, disable the canvas to remove it from the view
            if (fadeAmount >= 1f)
            {
                gameObject.SetActive(false); // Hide the entire canvas or object holding this script
            }
        }
    }
}
