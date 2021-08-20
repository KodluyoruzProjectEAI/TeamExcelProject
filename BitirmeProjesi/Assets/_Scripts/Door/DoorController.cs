using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject icoSphere;
    Renderer rendererIco,rendererThis;
    
    State currentState;
    public enum State
    {
        Red,
        Yellow,
        Blue
    }
    void Awake()
    {
        rendererThis = GetComponent<Renderer>();
        rendererIco = icoSphere.GetComponent<Renderer>();
    }
    void Update()
    {
        switch (currentState)
        {
            case State.Red:
                rendererThis.material.color = Color.red;
                rendererIco.material.color = Color.red;
                StartCoroutine(wait(State.Red));
                break;
            case State.Yellow:
                rendererThis.material.color = Color.yellow;
                rendererIco.material.color = Color.yellow;
                StartCoroutine(wait(State.Yellow));
                break;
            case State.Blue:
                rendererThis.material.color = Color.blue;
                rendererIco.material.color = Color.blue;
                StartCoroutine(wait(State.Blue));
                break;
        }
    }
    IEnumerator wait(State state)
    {
        yield return new WaitForSeconds(1);
        switch (state)
        {
            case State.Red:
                currentState = State.Yellow;
                break;
            case State.Yellow:
                currentState = State.Blue;
                break;
            case State.Blue:
                currentState = State.Red;
                break;
        }
    }
}
