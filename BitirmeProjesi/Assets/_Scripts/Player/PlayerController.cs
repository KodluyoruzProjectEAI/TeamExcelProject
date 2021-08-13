using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData
{
    PlayerController _playerController;
    HorizontalMover _horizontalMover;
    PlayerInput _playerInput;
    
    float inputHorValue;
    
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerInput = GetComponent<PlayerInput>();
        _horizontalMover = new HorizontalMover(this);
    }
    void Update()
    {
        inputHorValue = _playerInput.GetMoveInput();
    }
    void FixedUpdate()
    {
        if (IsHorizontal)
        {
            _horizontalMover.Active(inputHorValue, HorizontalSpeed, BoundX);
        }
    }
}
