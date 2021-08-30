using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionController: ICollisionController
{
    IEntityController _IentityController;
    IEntityManager _IentityManager;
    IPlayerSkills _IplayerSkills;
    float goldBugTimer;
    public CollisionController(IEntityController entityController, IEntityManager entityManager)
    {
        _IentityController = entityController;
        _IentityManager = entityManager;
        _IplayerSkills = new PlayerSkills(_IentityController);
    }
    public void Control(Collider collider)
    {
        //COIL
        if (collider.GetComponentInParent<Coil>())
        {
            switch (collider.GetComponentInParent<Coil>().CurrentState)
            {
                case Coil.State.Red:
                    _IplayerSkills.RemoveSpeed(10);
                    break;
                case Coil.State.Blue:
                    _IplayerSkills.AddSpeed(15);
                    break;
            }
            return;
        }
        ///ALTIN
        if (collider.GetComponent<GemController>())
        {
            if (_IentityController.transform.GetComponent<PlayerController>())
            {
                if (Time.time > goldBugTimer + 0.2f)
                {
                    GemController gemController = collider.GetComponent<GemController>();
                    gemController.IsFollow = true;
                    PlayerManager.Instance.Point += 10;
                    goldBugTimer = Time.time;
                }

            }
        }
        //FINISHLINE
        if (PlayerManager.Instance.currentState == PlayerManager.State.Win)
        {
            if (_IentityController.transform.GetComponent<PlayerController>())
            {
                int point = collider.GetComponent<FinishLine>().value;
                PlayerManager.Instance.BonusPoint = point+1;
                Debug.Log("Bonus:" + PlayerManager.Instance.BonusPoint);
            }
           
        }
        //TAGS
        switch (collider.tag)
        {
            case "Skill":
                if (_IentityController.transform.GetComponent<PlayerController>())
                {
                    _IentityController.IsPower = true;
                }
                break;

            case "SpeedUp":
                _IplayerSkills.AddSpeed(10f);
                break;

            case "Obstacle":
                _IplayerSkills.RemoveSpeed(5f);
                break;

            case "FinishLine":
                _IentityManager.SetSlideMOD();
                break;

            case "Collectable":
                break;
        }

    } 
}
