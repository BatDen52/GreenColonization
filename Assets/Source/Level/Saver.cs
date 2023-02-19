using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EndGameChecker))]
public class Saver : MonoBehaviour
{
    private const int DefaultSceneIndex = 1;

    private EndGameChecker _endGameChecker;

    private void Awake()
    {
        _endGameChecker = GetComponent<EndGameChecker>();
    }

    private void OnEnable()
    {
        _endGameChecker.GameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        _endGameChecker.GameEnded -= OnGameEnded;
    }

    private void OnGameEnded()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (PlayerPrefs.GetInt("LastScene", DefaultSceneIndex) < nextSceneIndex)
        {
            nextSceneIndex = Mathf.Max(nextSceneIndex, SceneManager.sceneCountInBuildSettings);
            PlayerPrefs.SetInt("LastScene", nextSceneIndex);
            PlayerPrefs.Save();
        }
    }
}
