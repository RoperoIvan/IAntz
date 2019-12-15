using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    public float time_between_sound = 5;
    // Use this for initialization
    void Start()
    {
        randomSound = gameObject.GetComponent<AudioSource>();
        CallAudio();
    }


    void CallAudio()
    {
        Invoke("RandomSoundness", time_between_sound);
    }

    void RandomSoundness()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
        CallAudio();
    }
}
