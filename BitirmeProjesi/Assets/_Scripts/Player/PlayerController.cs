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
    public GameObject _canvas;

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
        Debug.Log(VerticalSpeed);
        if (VerticalSpeed <= 0f)
        {
            _canvas.SetActive(true);
            Debug.Log("çalýþ");
        }
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
            /*case "Obstacle":
                _IplayerSkills.RemoveSpeed(10f);
                break;*/
            case "FinishLine":
                _playerManager.SetState("Slide");
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Obstacle")
        {
            _IplayerSkills.RemoveSpeed(10f);
            
        }
    }
   
}
