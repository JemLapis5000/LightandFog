using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSources;
    private int maxActiveSources = 5;

    void Update()
    {
        int activeSources = 0;
        foreach (AudioSource source in audioSources)
        {
            if (source.isPlaying)
            {
                activeSources++;
                if (activeSources > maxActiveSources)
                {
                    source.Stop();
                }
            }
        }
    }
}
