using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : ASingleton<MenuManager>
{
    void Awake()
    {
        StartSingleton(this);
    }

   
}
