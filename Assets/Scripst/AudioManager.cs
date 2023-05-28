using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip BackgroundMusic;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        musicSource.clip = BackgroundMusic;
        musicSource.Play();
    }
}
