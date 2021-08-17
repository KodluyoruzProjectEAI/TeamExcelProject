using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AManager : MonoBehaviour
{
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
    public abstract void StartGame();
    public abstract void Idle();
    public abstract void Running();
    public abstract void SuperRunning();
    public abstract void Slide();
    public abstract void GameOver();
    public abstract void Win();
    public abstract void SetState(string set);

   
}
