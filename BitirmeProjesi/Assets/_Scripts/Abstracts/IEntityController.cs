using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityController 
{   
    Rigidbody rb { get; }
    Transform transform { get; }
    float BoundX { get; }
    public float VerticalSpeed{ get; set; }
    public bool IsStopMode { get; set; }

}
