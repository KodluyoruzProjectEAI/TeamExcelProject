using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public float HorizontalSpeed { get; set; }

    [field: SerializeField]
    public float VerticalSpeed { get; set; }

    [field: SerializeField]
    public float BoundX { get; set; }
    public bool IsHorizontal { get; set; }
    public bool IsStopMode { get; set; }

    public Rigidbody rb => GetComponent<Rigidbody>();



}
