using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MenuManager : ASingleton<MenuManager>
{
    public static event System.Action OnStartGame;
    public static event System.Action OnRestartGame;
    [SerializeField] GameObject WinGameCanvas;
    [SerializeField] GameObject LoseGameCanvas;
    [SerializeField] GameObject SkillCanvas;
    PlayerManager _playerManager;
    PlayerController _playerController;
    GameManager _gameManager;
    void Awake()
    {
        StartSingleton(this);
        _gameManager = FindObjectOfType<GameManager>();
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (_playerManager.currentState == PlayerManager.State.Win)
        {
            WinGameCanvas.SetActive(true);
        }
        if(_playerManager.currentState == PlayerManager.State.GameOver)
        {
            LoseGameCanvas.SetActive(true);
        }
        if (_playerController.IsPower)
        {
            SkillCanvas.SetActive(true);
        }
        else
        {
            SkillCanvas.SetActive(false);
        }
    }
    public void Play()
    {
        OnStartGame?.Invoke();
    }
    public void RestartLevel()
    {
        _gameManager.CreateLevel(false);
    }
    public void NextLevel()
    {
        _gameManager.CreateLevel(true);
    }

}
