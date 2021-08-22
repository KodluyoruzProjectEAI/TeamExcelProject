using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MenuManager : ASingleton<MenuManager>
{
    public static event System.Action OnStartGame;
    public static event System.Action OnFinishGame;
    [SerializeField] GameObject TapToPlayCanvas;
    [SerializeField] GameObject RestartGameCanvas;
    PlayerManager _playerManager;
    void Awake()
    {
        StartSingleton(this);
        _playerManager = FindObjectOfType<PlayerManager>();
    }
    void Update()
    {
        if (_playerManager.currentState == PlayerManager.State.Win || _playerManager.currentState == PlayerManager.State.GameOver)
        {
            RestartGameCanvas.SetActive(true);
        }
    }
    public void Play()
    {
        OnStartGame?.Invoke();
        TapToPlayCanvas.SetActive(false);
    }
    public void RestartGame()
    {
        RestartGameCanvas.SetActive(false);
        //Restart game...
    }

}
