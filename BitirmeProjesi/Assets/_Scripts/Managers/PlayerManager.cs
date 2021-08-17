using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AManager
{
    public static PlayerManager Instance;

    [SerializeField] ParticleSystem splash;
    GameObject prefab;
    IEntityController _entityController;
    IAnimationController _animationController;
    Animator animator;
   
    void Awake()
    {
        prefab = FindObjectOfType<PlayerController>().gameObject;
        animator = prefab.GetComponentInChildren<Animator>();
        _entityController = prefab.GetComponent<IEntityController>();
        _animationController = new AnimationController(animator);
    }
    void Start()
    {
        SetState("Idle");
    }
    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Running:
                Running();
                break;
            case State.SuperRunning:
                SuperRunning();
                break;
            case State.Slide:
                Slide();
                break;
            case State.GameOver:
                GameOver();
                break;
            case State.Win:
                Win();
                break;
        }
    }
    public override void Idle()
    {
        _animationController.Idle();
        _entityController.IsStopMode = true;
    }

    public override void Running()
    {
        _animationController.Run();
        _entityController.IsStopMode = false;
    }

    public override void SuperRunning()
    {
        //
    }

    public override void Slide()
    {
        _animationController.SlideRun();
        splash.Play();
        if (_animationController._animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            SetState("Win");
        }
    }

    public override void GameOver()
    {
        _entityController.IsStopMode = true;
        _animationController.Dead();
    }

    public override void Win()
    {
        _entityController.IsStopMode = true;
        _animationController.Dance();
    }
    public override void SetState(string set)
    {
        switch (set)
        {
            case "Idle":
                currentState = State.Idle;
                break;

            case "Running":
                currentState = State.Running;
                break;

            case "SuperRunning":
                currentState = State.SuperRunning;
                break;

            case "Slide":
                currentState = State.Slide;
                break;

            case "GameOver":
                currentState = State.GameOver;
                break;

            case "Win":
                currentState = State.Win;
                break;
        }
    }
}
