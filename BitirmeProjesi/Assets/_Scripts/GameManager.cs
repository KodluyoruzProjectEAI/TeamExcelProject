using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event System.Action OnIdle;
        public static event System.Action OnRunning;
        // public static event System.Action OnSuperRunning;
        // public static event System.Action OnJump;
        public static event System.Action OnSlide;
        public static event System.Action OnGameover;
        public static event System.Action OnWin;

        public static State currentState { get; private set; }
        public enum State
        {
            Idle,
            Running,
            //SuperRunning,
            //Jump,
            Slide,
            Gameover,
            Win
        }
        void Awake()
        {
            StartSingleton(this);
            SetState("Idle");
        }
        void Update()
        {
            Debug.Log(currentState);
            switch (currentState)
            {
                case State.Idle:
                    OnIdle?.Invoke();
                    break;
                case State.Running:
                    OnRunning?.Invoke();
                    break;
                // case State.SuperRunning:
                //     OnSuperRunning?.Invoke();
                //     break;
                // case State.Jump:
                //     OnJump?.Invoke();
                //  break;
                case State.Slide:
                    OnSlide?.Invoke();
                    break;
                case State.Gameover:
                    OnGameover?.Invoke();
                    break;
                case State.Win:
                    OnWin?.Invoke();
                    break;
            }
        }
        public static State GetState(string get)
        {
            switch (get)
            {
                case "Idle":
                    return State.Idle;
                
                case "Running":
                    return State.Running;

                // case "SuperRunning":
                //     return State.SuperRunning;
                //
                // case "Jump":
                //     return State.Jump;
                
                case "Slide":
                    return State.Slide;
                
                case "Gameover":
                    return State.Gameover;

                case "Win":
                    return State.Win;

                default:
                    return State.Running;
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

                // case "SuperRunning":
                //     currentState = State.SuperRunning;
                //     break;
                //
                // case "Jump":
                //     currentState = State.Jump;
                //     break;
                
                case "Slide":
                    currentState = State.Slide;
                    break;

                case "Gameover":
                    currentState = State.Gameover;
                    break;

                case "Win":
                    currentState = State.Win;
                    break;
            }
        }
}
