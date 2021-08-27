using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionController: ICollisionController
{
    IEntityController _IentityController;
    IEntityManager _IentityManager;
    IPlayerSkills _IplayerSkills;
    public CollisionController(IEntityController entityController, IEntityManager entityManager)
    {
        _IentityController = entityController;
        _IentityManager = entityManager;
        _IplayerSkills = new PlayerSkills(_IentityController);
    }
    public void Control(Collider collider)
    {
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
        switch (collider.tag)
        {
            case "Collectable":

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
        }

    } 
}
