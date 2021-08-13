using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData
{
    PlayerController _playerController;
    PlayerInput _playerInput;
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
        if (IsHorizontal)
        {
            _IhorizontalMover.Active(inputHorValue, HorizontalSpeed, BoundX);
        }
    }
}
