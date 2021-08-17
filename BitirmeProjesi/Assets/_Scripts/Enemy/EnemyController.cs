using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController:PlayerData,IEntityController
{
    [SerializeField] EnemyManager _enemyManager;
    IHorizontalMover _IhorizontalMover;
    IVerticalMover _IverticalMover;
    IPlayerSkills _IplayerSkills;
    
    void Awake()
    {
        _IhorizontalMover = new HorizontalMover(this);
        _IverticalMover = new VerticalMover(this);
        _IplayerSkills = new PlayerSkills(this);
    }
    void FixedUpdate()
    {
        if (IsStopMode)
        {
            return;
        }
        StartCoroutine(_IhorizontalMover.Active(0));
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
                _enemyManager.SetState("Slide");
                break;
        }
    }
}
