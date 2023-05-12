using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioPlayer : MonoBehaviour
{
    private AudioSource _source;

    protected void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    protected void OnDisable()
    {
        _source?.Stop();
    }

    public void StopMusic()
    {
        _source.Stop();
    }

    protected void PlayMusic(AudioClip clip)
    {
        _source.Stop();
        _source.clip = clip;
        _source.Play();
    }
}

