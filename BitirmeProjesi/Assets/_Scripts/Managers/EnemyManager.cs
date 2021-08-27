using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : AManager,IEntityManager
{
    [SerializeField] ParticleSystem splashParticle;
    IEntityController _entityController;
    IProcess _process;
    void Awake()
    {
        _entityController = GetComponent<IEntityController>();
        _process = new Process(_entityController,this);
    }
    void OnEnable()
    {
        MenuManager.OnStartGame += SetRunningMOD;
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
                break;
            case State.Running:
                _process.Running();
                break;
            case State.SuperRunning:
                _process.SuperRunning();
                break;
            case State.Slide:
                _process.Slide();
                break;
            case State.GameOver:
                _process.GameOver();
                break;
            case State.Win:
                _process.Win();
                splashParticle.Play();
                break;
        }
    }

}
