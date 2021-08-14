using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityController 
{
    Rigidbody rb { get; }
    Transform transform { get; }
    float HorizontalSpeed { get; }
    float VerticalSpeed { get; }
    float BoundX { get; }
}
