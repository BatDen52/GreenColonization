using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoader : MonoBehaviour
{
    private const int DefaultSceneIndex = 1;

    private void Awake()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene", DefaultSceneIndex));
    }
}
