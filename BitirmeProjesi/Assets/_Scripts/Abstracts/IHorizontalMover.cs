using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHorizontalMover 
{
    void Active(float inputHorValue, float horizontalSpeed, float moveBoundary);
}
