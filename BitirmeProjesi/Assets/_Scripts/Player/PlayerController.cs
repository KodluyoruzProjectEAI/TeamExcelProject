using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData, IEntityController
{
    PlayerManager _playerManager;
    PlayerInput _playerInput;
    IHorizontalMover _IhorizontalMover;
    IVerticalMover _IverticalMover;
    IPlayerSkills _IplayerSkills;
    float inputHorValue;

    public CurrentState currentState;
    public enum CurrentState
    {
        Center,
        Left,
        Right
    }
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
        currentState = (CurrentState)_IhorizontalMover.GetState();
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
                MagicDoor md = collider.GetComponent<MagicDoor>();
                switch (md.currentState)
                {
                    case MagicDoor.State.Blue:
                        _IplayerSkills.AddSpeed(15f);
                        break;

                    case MagicDoor.State.Red:
                        _IplayerSkills.RemoveSpeed(5f);
                        break;

                    case MagicDoor.State.Yellow:
                        break;
                }
                break;
        }
    }
}
