using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HummingbirdEncouragement : MonoBehaviour
{
    public TextMeshProUGUI encouragementText;
    public Transform player;
    private Vector3 lastPosition;
    private float distanceMoved;
    private float nextDistanceThreshold = 200f; // Change phrase every 100 units moved
    private int currentPhraseIndex = 0;

    private string[] phrases = new string[]
    {
        "It's okay to not be okay—reach out for support.",
        "You don’t have to go through this alone.",
        "Help is just a conversation away.",
        "Caring for yourself is the first step.",
        "You’re not alone; many others have been where you are.",
        "Your mental health is just as important as your physical health.",
        "Seeking help is a sign of strength, not weakness.",
        "There is hope and help available—take the first step.",
        "You deserve support and understanding.",
        "Talking about it is the first step to healing.",
        "It’s okay to ask for help; you’re not failing.",
        "Reaching out for help shows courage and love for yourself.",
        "You are not alone in this journey; help is here.",
        "Every journey toward healing begins with reaching out.",
        "You are not a burden—your feelings matter.",
        "Seeking help is the best gift you can give yourself.",
        "Taking care of your mental health is an act of love.",
        "There is no shame in asking for help—it's a step toward recovery.",
        "Remember, it's okay to need help, and it's okay to ask for it.",

        "Healing begins with reaching out."
    };

    void Start()
    {
        if (player == null || encouragementText == null)
        {
            Debug.LogError("Please assign the player and encouragementText in the inspector.");
            enabled = false;
            return;
        }
        lastPosition = player.position;
        UpdateEncouragement();
    }

    void Update()
    {
        distanceMoved += Vector3.Distance(player.position, lastPosition);
        lastPosition = player.position;

        if (distanceMoved >= nextDistanceThreshold)
        {
            UpdateEncouragement();
            distanceMoved = 0f;
        }
    }

    void UpdateEncouragement()
    {
        encouragementText.text = phrases[currentPhraseIndex];
        currentPhraseIndex = (currentPhraseIndex + 1) % phrases.Length;
    }
}
