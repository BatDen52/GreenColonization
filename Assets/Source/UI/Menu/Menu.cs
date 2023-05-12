using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EndGameChecker))]
public class Menu : MonoBehaviour
{
    [SerializeField] private CameraMover _camera;
    [SerializeField] private Follower _follower;
    [SerializeField] private GameCanvas _gameCanvas;
    [SerializeField] private MenuCanvas _menuCanvas;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private MusicPlayer _music;

    [SerializeField] private UnityEvent _gameStarting;

    private EndGameChecker _endGameChecker;
    private Vector3 _cameraEndPosition;

    private void Awake()
    {
        Time.timeScale = 1;
        _endGameChecker = GetComponent<EndGameChecker>();
        _cameraEndPosition = _camera.transform.position - _inputReader.transform.position;
        
        _gameCanvas.gameObject.SetActive(false);
        _menuCanvas.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _camera.GottenTarget += OnGottenTarget;
        _endGameChecker.GameEnded += OnEndGame;
    }

    private void OnDisable()
    {
        _camera.GottenTarget -= OnGottenTarget;
        _endGameChecker.GameEnded -= OnEndGame;
    }

    public void StartGame()
    {
        _menuCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
        _camera.enabled = true;
        _camera.SetTargetPosition(_follower.GoalPosition, _follower.Target);
        _music.StopMusic();
        _music.PlayGameMusic();
        _gameStarting?.Invoke();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _gameCanvas.gameObject.SetActive(false);
        _menuCanvas.gameObject.SetActive(true);
        _menuCanvas.ShowPausePanel();
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        _gameCanvas.gameObject.SetActive(true);
        _menuCanvas.gameObject.SetActive(false);
    }

    private void OnGottenTarget()
    {
        _camera.GottenTarget -= OnGottenTarget;
        _camera.enabled = false;
        _follower.enabled = true;
        _inputReader.enabled = true;
    }

    private void OnEndGame()
    {
        _follower.enabled = false;
        _inputReader.enabled = false;
        _inputReader.Stop();
        _camera.enabled = true;
        _camera.SetTargetPosition(_inputReader.transform.position + _cameraEndPosition, _follower.Target);
        _gameCanvas.gameObject.SetActive(false);
        _menuCanvas.gameObject.SetActive(true);
        _menuCanvas.ShowEndPanel();
    }
}
