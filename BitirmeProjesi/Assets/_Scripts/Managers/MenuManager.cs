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
    bool activatedMenu;
    float playerTotalPoint;
    void Awake()
    {
        StartSingleton(this);
        _gameManager = FindObjectOfType<GameManager>();
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        Debug.Log("TotalPoint:"+playerTotalPoint);
        if (activatedMenu) { return; }
        switch (_playerManager.currentState)
        {
            case PlayerManager.State.Win:
                StartCoroutine(ActivatedWinGameCanvas());
                activatedMenu = true;
                break;

            case PlayerManager.State.GameOver:
                StartCoroutine(ActivatedGameOverCanvas());
                activatedMenu = true;
                break;
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
    IEnumerator ActivatedWinGameCanvas() 
    {
        yield return new WaitForSeconds(2f);
        CalculatePoint();
        WinGameCanvas.SetActive(true);
    }
    IEnumerator ActivatedGameOverCanvas()
    {
        yield return new WaitForSeconds(2f);
        LoseGameCanvas.SetActive(true);
    }
    void CalculatePoint()
    {
        Debug.Log("Point:" + _playerManager.Point);
        Debug.Log("BonusPoint:" + _playerManager.BonusPoint);

        playerTotalPoint = _playerManager.Point * _playerManager.BonusPoint;
    }
    public void Play()
    {
        OnStartGame?.Invoke();
    }
    public void RestartLevel()
    {
        _gameManager.CreateLevel(false);
        activatedMenu = false;
    }
    public void NextLevel()
    {
        _gameManager.CreateLevel(true);
        activatedMenu = false;
    }

}
