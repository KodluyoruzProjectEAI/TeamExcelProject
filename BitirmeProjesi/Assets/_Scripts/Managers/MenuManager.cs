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
        //Player Manager'dan start methodundaki statei IDLE'a ald�m, tap to Play yapt�ktan sonra runninge ge�sin istedim, ge�miyor
        playerManager.currentState = PlayerManager.State.Running;
        canvas.SetActive(false);
        Debug.Log("�ALI� L�TFN");
    }
}
