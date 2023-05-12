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
        int lastSceneIndex = PlayerPrefs.GetInt("LastScene", DefaultSceneIndex);

        if (lastSceneIndex < nextSceneIndex || lastSceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            nextSceneIndex = Mathf.Min(nextSceneIndex, SceneManager.sceneCountInBuildSettings-1);
            PlayerPrefs.SetInt("LastScene", nextSceneIndex);
            PlayerPrefs.Save();
        }
    }
}
