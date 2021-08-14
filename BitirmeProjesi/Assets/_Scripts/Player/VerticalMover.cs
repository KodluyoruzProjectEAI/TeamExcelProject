using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : IVerticalMover
{
    IEntityController _entityController;
    Rigidbody rb;
    float verticalSpeed;
    public VerticalMover(IEntityController entityController)
    {
        _entityController = entityController;
        verticalSpeed = entityController.VerticalSpeed;
        rb = entityController.rb;
    }
    public void Active()
    {
        Debug.Log(verticalSpeed);
        rb.AddForce(Vector3.forward * verticalSpeed * Time.deltaTime);
    }
}
