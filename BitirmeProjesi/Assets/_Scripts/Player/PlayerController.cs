using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData,IEntityController
{
    PlayerManager _playerManager;
    PlayerInput _playerInput;
    IHorizontalMover _IhorizontalMover;
    IVerticalMover _IverticalMover;
    IPlayerSkills _IplayerSkills;
    float inputHorValue;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _IhorizontalMover = new HorizontalMover(this);
        _IverticalMover = new VerticalMover(this);
        _IplayerSkills = new PlayerSkills(this);
        _playerManager = FindObjectOfType<PlayerManager>();
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
                _IplayerSkills.RemoveSpeed(5f);
                break;

            case "FinishLine":
                _playerManager.SetState("Slide");
                break;

            case "Door":
                DoorController dc = collider.GetComponent<DoorController>();
                switch (dc.currentState)
                {
                    case DoorController.State.Blue:
                        _IplayerSkills.AddSpeed(15f);
                        break;

                    case DoorController.State.Red:
                        _IplayerSkills.RemoveSpeed(5f);
                        break;

                    case DoorController.State.Yellow:
                        break;
                }
                break;
        }
    }
}
