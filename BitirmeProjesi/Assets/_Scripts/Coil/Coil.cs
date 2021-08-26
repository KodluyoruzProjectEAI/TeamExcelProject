using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour
{
    [SerializeField] TeslaCoilData[] data;
    [field: SerializeField] public State CurrentState { get; private set; }

    Light lightObj;
    Material[] materials;
    MeshRenderer rendererList;
    int index;
    public enum State
    {
        Red,
        Blue
    }
    void Awake()
    {
        lightObj = GetComponentInChildren<Light>();
        rendererList = GetComponentInChildren<MeshRenderer>();
        materials = new Material[rendererList.materials.Length];
    }
    void Start()
    {
        Setup();
    }
    void Setup()
    {
        switch (CurrentState)
        {
            case State.Blue:
                index = 0;
                break;
            case State.Red:
                index = 1;
                break;
        }
        materials[0] = data[index].GlassMaterial;
        materials[1] = data[index].BodyMaterial;
        materials[2] = data[index].ConMaterial;
        lightObj.color = data[index].LightMaterial.color;

        rendererList.materials = materials;
    }
}
