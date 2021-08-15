using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData,IEntityController
{
    PlayerInput _playerInput;
    IEntityController _playerController;
    IHorizontalMover _IhorizontalMover;
    IVerticalMover _IverticalMover;
    IPlayerSkills _IplayerSkills;
    float inputHorValue;
    void Awake()
    {   
        _playerController = GetComponent<PlayerController>();
        _playerInput = GetComponent<PlayerInput>();
        _IhorizontalMover = new HorizontalMover(this);
        _IverticalMover = new VerticalMover(this);
        _IplayerSkills = new PlayerSkills(this);
    }
    void Update()
    {
        inputHorValue = _playerInput.GetMoveInput();
    }
    void FixedUpdate()
    {
        if (IsStopMode)
        {
            return;
        }
        StartCoroutine(_IhorizontalMover.Active(inputHorValue));
        _IverticalMover.Active(VerticalSpeed);
    }
    void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "SpeedUp":
                _IplayerSkills.AddSpeed(10f);
                break;
            case "Obstacle":
                _IplayerSkills.RemoveSpeed(10f);
                break;
            case "FinishLine":
                GameManager.SetState("Slide");
                break;
        }
    }

}
