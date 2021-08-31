using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AManager,IEntityManager
{
    public static event System.Action OnLoseGame;
    public static PlayerManager Instance;

    public float Point { get; set; }
    public float BonusPoint { get; set; }

    PlayerParticle _playerParticle;
    IEntityController _entityController;
    IProcess _process;
    void Awake()
    {
        _entityController = FindObjectOfType<PlayerController>();
        _playerParticle = _entityController.transform.GetComponentInChildren<PlayerParticle>();
        _process = new Process(_entityController, this);
        StartSingleton();
    }
    void OnEnable()
    {
        MenuManager.OnStartGame += SetRunningMOD;
        MenuManager.OnRestartGame += SetIdleMOD;
    }
    void Start()
    {
        SetIdleMOD();
    }
    void LateUpdate()
    {
        switch (currentState)
        {
            case State.Idle:
                _process.Idle();
                _playerParticle.idleParticle.Play();
                BonusPoint = 0;
                Point = 0;
                break;
            case State.Running:
                _process.Running();
                break;
            case State.InjuredRunning:
                _process.InjuredRunning();
                break;
            case State.Slide:
                _process.Slide();
                break;
            case State.GameOver:
                _process.GameOver();
                OnLoseGame?.Invoke();
                break;
            case State.Win:
                _process.Win();
                break;
        }
        if (currentState == State.Running && _entityController.VerticalSpeed >= _playerParticle.superRunBoundValue)
        {
            SoundManager.Instance.PlaySuperRunSound();
            _playerParticle.superRunParticle.Play();
        }
        else
        {
            _playerParticle.superRunParticle.Stop();
        }
    }
    void StartSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    

}
