using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    PlayerController _playerController;
    public HorizontalMover(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Active(float inputHorValue,float horizontalSpeed,float moveBoundary)
    {
        if (inputHorValue == 0)
        {
            return;
        }
        _playerController.transform.Translate(Vector3.right * inputHorValue * horizontalSpeed * Time.deltaTime );
        float BoundX = Mathf.Clamp(_playerController.transform.position.x, -moveBoundary, moveBoundary);
        _playerController.transform.position = new Vector3(BoundX, _playerController.transform.position.y, _playerController.transform.position.z);
    }
}
