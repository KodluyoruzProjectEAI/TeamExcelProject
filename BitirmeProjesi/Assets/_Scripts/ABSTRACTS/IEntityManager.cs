using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityManager 
{
    void SetIdleMOD();
    void SetRunningMOD();
    void SetSuperRunningMOD();
    void SetSlideMOD();
    void SetGameOverMOD();
    void SetWinMOD();
}
