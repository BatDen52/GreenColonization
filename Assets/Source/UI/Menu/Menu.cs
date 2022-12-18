using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private CameraMover _camera;
    [SerializeField] private Follower _follower;
    [SerializeField] private GameCanvas _gameCanvas;
    [SerializeField] private MenuCanvas _menuCanvas;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private MusicPlayer _music;

    private void OnEnable()
    {
        _camera.GottenTarget += OnGottenTarget;
    }

    private void OnDisable()
    {
        _camera.GottenTarget -= OnGottenTarget;
    }

    public void StartGame()
    {
        _menuCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
        _camera.SetTargetPosition(_follower.GoalPosition, _follower.Target);
        _music.PlayGameMusic();
    }

    private void OnGottenTarget()
    {
        _camera.enabled = false;
        _follower.enabled = true;
        _inputReader.enabled = true;
    }
}
