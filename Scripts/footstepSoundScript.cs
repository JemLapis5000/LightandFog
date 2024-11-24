using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public float footstepThreshold = 0.1f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (footstepAudioSource == null)
        {
            footstepAudioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if the player is moving
        if (characterController != null)
        {
            if (characterController.velocity.magnitude > footstepThreshold)
            {
                // Play the sound if not already playing
                if (!footstepAudioSource.isPlaying)
                {
                    footstepAudioSource.Play();
                }
            }
            else
            {
                // Stop the sound if the player is not moving
                if (footstepAudioSource.isPlaying)
                {
                    footstepAudioSource.Stop();
                }
            }
        }
        else
        {
            Debug.LogWarning("CharacterController not found on the player.");
        }
    }
}
