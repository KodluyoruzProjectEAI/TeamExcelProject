using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MenuManager : ASingleton<MenuManager>
{
    public PlayerManager playerManager;
    public GameObject canvas;
    void Awake()
    {
        StartSingleton(this);
    }
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();

    }
    public void Play()
    {
        //Player Manager'dan start methodundaki statei IDLE'a aldým, tap to Play yaptýktan sonra runninge geçsin istedim, geçmiyor
        playerManager.currentState = PlayerManager.State.Running;
        canvas.SetActive(false);
        Debug.Log("ÇALIÞ LÜTFN");
    }
}
