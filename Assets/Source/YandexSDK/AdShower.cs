using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EndGameChecker))]
[RequireComponent(typeof(YandexSdkTools))]
public class AdShower : MonoBehaviour
{
    private EndGameChecker _endGameChecker;
    private YandexSdkTools _yandexSdk;

    private void Awake()
    {
        _yandexSdk = GetComponent<YandexSdkTools>();
        _endGameChecker = GetComponent<EndGameChecker>();
    }

    private void Start()
    {
        _yandexSdk.ShowVideo();
    }

    private void OnEnable()
    {
        _endGameChecker.GameEnded += _yandexSdk.ShowVideo;
    }

    private void OnDisable()
    {
        _endGameChecker.GameEnded -= _yandexSdk.ShowVideo;
    }
}
