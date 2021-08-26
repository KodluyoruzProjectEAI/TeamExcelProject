using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController:PlayerData,IEntityController
{
    EnemyManager _enemyManager;
    EnemyRandomMover _enemyRandomMover;
    IHorizontalMover _IhorizontalMover;
    IVerticalMover _IverticalMover;
    IPlayerSkills _IplayerSkills;
    int horizontalValue;

    public State state;
    public enum State
    {
        Left,
        Right,
        Center
    }
    void Awake()
    {   
        _IhorizontalMover = new HorizontalMover(this);
        _IverticalMover = new VerticalMover(this);
        _IplayerSkills = new PlayerSkills(this);
        _enemyManager = GetComponent<EnemyManager>();
        _enemyRandomMover = GetComponent<EnemyRandomMover>();
    }
    void Start()
    {
        _IhorizontalMover.SetStartEnum((int)(state));
    }
    void Update()
    {
        horizontalValue = _enemyRandomMover.RandomMove();
    }
    void FixedUpdate()
    {
        if (IsStopMode)
        {
            return;
        }
        StartCoroutine(_IhorizontalMover.Active(horizontalValue));
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
                _enemyManager.SetState("Slide");
                break;
        }
    }
}
