using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AManager
{
    void Start()
    {
        SetState("Running");
    }
    void Update()
    {
        StateVoid();
    }
    protected override void StateVoid()
    {
        base.StateVoid();
    }
}
