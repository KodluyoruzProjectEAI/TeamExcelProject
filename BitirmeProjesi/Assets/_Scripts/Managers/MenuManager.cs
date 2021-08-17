using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class MenuManager : ASingleton<MenuManager>
{
    public AManager aManager;
    public GameObject canvas;
    //public UnityEvent OnClick;
    void Awake()
    {
        StartSingleton(this);
    }
    private void Start()
    {
        aManager = FindObjectOfType<AManager>();

    }
    public void deneme()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        aManager.currentState = AManager.State.Running;
        canvas.SetActive(false);
        Debug.Log("ÇALIÞ LÜTFN");
    }
}
