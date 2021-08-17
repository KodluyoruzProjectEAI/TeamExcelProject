using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MenuManager : ASingleton<MenuManager>
{
    public static event System.Action OnStartGame;
    public GameObject canvas;
    void Awake()
    {
        StartSingleton(this);
    }
    public void Play()
    {
        OnStartGame?.Invoke();
        canvas.SetActive(false);
    }
}
