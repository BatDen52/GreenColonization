using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YandexSdkTools : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    public void ShowInterstitial()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif

        if (YandexGamesSdk.IsInitialized)
            InterstitialAd.Show();
    }

    public void ShowVideo()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif

        if (YandexGamesSdk.IsInitialized)
            VideoAd.Show();
    }

    public void OnShowVideoButtonClick()
    {
        ShowVideo();
    }
}
