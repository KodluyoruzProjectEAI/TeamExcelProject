using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : IHorizontalMover
{
    IEntityController _entityController;
    float moveBoundary;
    public HorizontalMover(IEntityController entityController)
    {
        _entityController = entityController;
        moveBoundary = entityController.BoundX;
    }
    public void Active(float inputHorValue,float horizontalSpeed)
    {
        Debug.Log("input:" + inputHorValue + ",horSpeed:" + horizontalSpeed + ",Bound:" + moveBoundary);
        if (inputHorValue == 0)
        {
            return;
        }
        _entityController.transform.Translate(Vector3.right * inputHorValue * horizontalSpeed * Time.deltaTime );
        float BoundX = Mathf.Clamp(_entityController.transform.position.x, -moveBoundary, moveBoundary);
        _entityController.transform.position = new Vector3(BoundX, _entityController.transform.position.y, _entityController.transform.position.z);
    }
}

