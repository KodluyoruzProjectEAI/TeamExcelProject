using System.Collections;
using System.Collections.Generic;
using Player.Scripts;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
        [SerializeField] GameObject Player;

        AnimationController _animationController;
        PlayerController _playerController;
   
        static State currentState;

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
            _animationController = Player.GetComponent<AnimationController>();
            _playerController = Player.GetComponent<PlayerController>();
        }
        void Start()
        {
            StartSingleton(this);
            SetState("Running");
        }
        void Update()
        {
        switch (currentState)
            {
                case State.Idle:
                    _animationController.Idle();
                    _playerController.IsStopMode = true;
                break;
                case State.Running:
                    _animationController.Run();
                    _playerController.IsStopMode = false;
                break;
                case State.SuperRunning:
                    
                break;
                case State.Slide:
                    _animationController.SlideRun();
                break;
                case State.GameOver:
                    _animationController.Dead();
                    _playerController.IsStopMode = true;
                break;
                case State.Win:
                    _animationController.Dance();
                    _playerController.IsStopMode = true;
                break;
            }
        }
        //Duruma göre true/false gönderiyor
        public static bool GetCurrentState(string get)
        {
        switch (get)
            {
            case "Idle":
                return currentState == State.Idle ? true :false;

            case "Running":
                return currentState == State.Running ? true : false;

            case "SuperRunning":
                return currentState == State.SuperRunning ? true : false;

            case "Slide":
                return currentState == State.Slide? true : false;

            case "GameOver":
                return currentState == State.GameOver ? true : false;

            case "Win":
                return currentState == State.Win ? true : false;

            default:
                return false;
            }
        }
        public static void SetState(string set)
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
