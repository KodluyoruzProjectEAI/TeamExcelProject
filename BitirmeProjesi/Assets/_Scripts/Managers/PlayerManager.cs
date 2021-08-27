using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AManager,IEntityManager
{

    public static event System.Action OnLoseGame;

    [SerializeField] ParticleSystem splashParticle;
    public static PlayerManager Instance;
    
    IEntityController _entityController;
    IProcess _process;
    void Awake()
    {
        _entityController = FindObjectOfType<PlayerController>();
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
                splashParticle.Stop();
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
                splashParticle.Play();
                break;
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
