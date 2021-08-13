using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
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
            StartSingleton(this);
            SetState("Idle");
        }
        void Update()
        {
            switch (currentState)
            {
                case State.Idle:
                    break;

                case State.Running:
                    break;

                case State.SuperRunning:
                    break;

                case State.Slide:
                    break;

                case State.GameOver:
                    break;

                case State.Win:
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
