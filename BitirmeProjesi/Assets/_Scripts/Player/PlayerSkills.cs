using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : IPlayerSkills
{
    IEntityController _entityController;
    public PlayerSkills(IEntityController entityController)
    {
        _entityController = entityController;
    }
    public void AddSpeed(float value)
    {
       _entityController.VerticalSpeed += value;
    }
    public void RemoveSpeed(float value)
    {
        _entityController.VerticalSpeed -= value;
    }
}
