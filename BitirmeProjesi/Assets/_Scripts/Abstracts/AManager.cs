using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AManager : MonoBehaviour
{   
    [SerializeField] GameObject prefab;
    IEntityController _entityController;
    IAnimationController _animationController;
    Animator animator;

    public State currentState;
    public enum State
    {
        Idle,
        Running,
        SuperRunning,
        Slide,
        GameOver,
        Win
    }
    void Awake()
    {
        animator = prefab.GetComponentInChildren<Animator>();
        _entityController = prefab.GetComponent<IEntityController>();
        _animationController = new AnimationController(animator);
    }
 
    protected virtual void StateVoid()
    {
        switch (currentState)
        {
            case State.Idle:
                _animationController.Idle();
                _entityController.IsStopMode = true;
                break;
            case State.Running:
                _animationController.Run();
                _entityController.IsStopMode = false;
                break;
            case State.SuperRunning:

                break;
            case State.Slide:
                _animationController.SlideRun();
                if (_animationController._animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    SetState("Win");
                }
                break;
            case State.GameOver:
                _entityController.IsStopMode = true;
                _animationController.Dead();

                break;
            case State.Win:
                _entityController.IsStopMode = true;
                _animationController.Dance();
                break;
        }
    }
    public void SetState(string set)
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
