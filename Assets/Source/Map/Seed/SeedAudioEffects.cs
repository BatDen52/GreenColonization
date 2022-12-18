using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Seed))]
public class SeedAudioEffects : AudioPlayer
{
    [SerializeField] private AudioClip _collectClip;
    [SerializeField] private AudioClip _sowClip;
    private Seed _seed;

    private void Awake()
    {
        base.Awake();
        _seed = GetComponent<Seed>();
    }

    private void OnEnable()
    {
        _seed.Collected += PlayCollectSound;
        _seed.Planting += PlaySowSound;
    }

    private void OnDisable()
    {
        _seed.Collected -= PlayCollectSound;
        _seed.Planting -= PlaySowSound;
    }

    public void PlayCollectSound() => PlayMusic(_collectClip);

    public void PlaySowSound() => PlayMusic(_sowClip);
}
