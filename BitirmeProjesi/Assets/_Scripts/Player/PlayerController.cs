using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData,IEntityController
{
    PlayerInput _playerInput;
    IEntityController _playerController;
    IHorizontalMover _IhorizontalMover;
    
    float inputHorValue;
    
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerInput = GetComponent<PlayerInput>();
        _IhorizontalMover = new HorizontalMover(this);
    }
    void Update()
    {
        inputHorValue = _playerInput.GetMoveInput();
    }
    void FixedUpdate()
    {
        Debug.Log(inputHorValue);
        _IhorizontalMover.Active(inputHorValue);
    }
}
