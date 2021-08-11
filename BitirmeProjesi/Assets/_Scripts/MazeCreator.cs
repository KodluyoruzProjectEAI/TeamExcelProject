using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCreator : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] string parentName;
    [SerializeField] int xLength;
    [SerializeField] int yLength;
    Vector3 pointPos;
    GameObject parentObject;
    void Start()
    {
        parentObject = new GameObject();
        parentObject.name = parentName;
        parentObject.transform.position = Vector3.zero;
        CreateLeft();
    }
    void CreateLeft()
    {
        for (int x = 1; x <= yLength; x++)
        {
            Instantiate(spawnObject, pointPos, spawnObject.transform.rotation, parentObject.transform);
            pointPos += Vector3.right * spawnObject.transform.localScale.x;
        }
    }
    void CreateBottom()
    {
        pointPos += Vector3.forward;
        for (int y = 1; y <= xLength; y++)
        {
            Instantiate(spawnObject, pointPos, spawnObject.transform.rotation, parentObject.transform);
            pointPos += Vector3.forward * spawnObject.transform.localScale.x;
        }
    }
}
