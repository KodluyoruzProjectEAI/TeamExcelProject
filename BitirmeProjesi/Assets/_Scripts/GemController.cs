using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public bool IsFollow;
    bool selectedPoint;
    float distance;
    PlayerController _playerController;
    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        float x = _playerController.transform.position.x;
        float y = _playerController.transform.position.y+0.5f;
        float z = _playerController.transform.position.z;

        if (IsFollow)
        {
            if (!selectedPoint)
            {
                PlayerManager.Instance.Point += 10;
                distance = PlayerManager.Instance.Point / 70;
                selectedPoint = true;
            }
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Vector3 target = new Vector3(x, y, z - distance);
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 5);
        }
        if (PlayerManager.Instance.currentState == PlayerManager.State.Win)
        {
            Destroy(this.gameObject);
        }
    }
   

}
