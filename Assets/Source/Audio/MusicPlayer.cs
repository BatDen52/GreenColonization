using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : AudioPlayer
{
    [SerializeField] private AudioClip _menuClip;
    [SerializeField] private AudioClip _gameClip;

    private void OnEnable()
    {
        PlayMenuMusic();
    }

    private void OnDisable()
    {
        base.OnDisable();
        StopMusic();
    }

    public void PlayGameMusic() => PlayMusic(_gameClip);

    public void PlayMenuMusic() => PlayMusic(_menuClip);
}
