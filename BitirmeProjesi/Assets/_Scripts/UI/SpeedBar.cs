using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBar : MonoBehaviour
{
    [SerializeField] SpriteRenderer frontRenderer;
    
    [SerializeField] ParticleSystem speedParticle;
    [SerializeField] PlayerManager _playerManager;
    
    [SerializeField] float speedLimit;
    IEntityController _entityController;
    float spriteValue;
    float firstValue;
    void Awake()
    {
        _entityController = GetComponentInParent<IEntityController>();
    }
    void Start()
    {
        firstValue = _entityController.VerticalSpeed;
        spriteValue = 7 / speedLimit;
        SetValue();
    }
    void Update()
    {
        if (_entityController.VerticalSpeed != firstValue)
        {
           firstValue = Mathf.Lerp(firstValue, _entityController.VerticalSpeed, Time.deltaTime * 10);
           SetValue();  
        }

        if (_entityController.VerticalSpeed >= 60 && _playerManager.currentState == AManager.State.Running)
        {
            speedParticle.Play();
        }
        else
        {
            speedParticle.Stop();
        }
    }
    void SetValue()
    {
       frontRenderer.size = new Vector2(firstValue * spriteValue, 0.7f);
    }
}

