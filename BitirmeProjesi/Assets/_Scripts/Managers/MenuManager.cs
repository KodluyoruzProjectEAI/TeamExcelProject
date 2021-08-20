using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MenuManager : ASingleton<MenuManager>
{
    public static event System.Action OnStartGame;
    public GameObject canvas;
    PlayerController _playerController;
    //IEntityController entityController;
    //PlayerData playerData;
    //bunlar menumanager scriptinde vertical speed ve boundx diye alan açýyor
    
    void Awake()
    {
        StartSingleton(this);
        _playerController = FindObjectOfType<PlayerController>();
    }
    public void Play()
    {
        OnStartGame?.Invoke();
        canvas.SetActive(false);
    }
    /*private void Update()
    {   //çalýþmýyor,bakýcam,oldukça yanlýþ bir þey var
        Debug.Log(_playerController.VerticalSpeed);
        if ( _playerController.VerticalSpeed <= 0f)
        {
           
            canvas.SetActive(true);
            Debug.Log("çalýþ");
        }
    }*/
}
