using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : ASingleton<MenuManager>
{
    void Awake()
    {
        StartSingleton(this);
    }
}
