using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour, IHorizontalMover
{
    IEntityController _entityController;
    CurrentState currentState;
    enum CurrentState
    {
        Center,
        Left,
        Right
    }
    float leftPosX, rightPosX, currentPosX;
    float delayTime;
    public HorizontalMover(IEntityController entityController)
    {
        _entityController = entityController;
        leftPosX = -entityController.BoundX;
        rightPosX = entityController.BoundX;
    }
    public IEnumerator Active(float inputHorValue)
    {
        float y = _entityController.transform.position.y;
        float z = _entityController.transform.position.z;
        if (Time.time > delayTime + 0.4)
        {
            switch (inputHorValue)
            {
                //SOLA
                case -1:
                    switch (currentState)
                    {
                        case CurrentState.Center:
                            currentState = CurrentState.Left;
                            currentPosX = leftPosX;
                            break;
                        case CurrentState.Right:
                            currentState = CurrentState.Center;
                            currentPosX = 0;
                            break;
                    }
                    delayTime = Time.time;
                    break;
                //SAÐA
                case 1:
                    switch (currentState)
                    {
                        case CurrentState.Center:
                            currentState = CurrentState.Right;
                            currentPosX = rightPosX;
                            break;
                        case CurrentState.Left:
                            currentState = CurrentState.Center;
                            currentPosX = 0;
                            break;

                    }
                    delayTime = Time.time;
                    break;
            }
        }
        _entityController.transform.position = Vector3.Lerp(_entityController.transform.position, new Vector3(currentPosX, y, z), Time.deltaTime * 10);
        yield return null;

    }
}

