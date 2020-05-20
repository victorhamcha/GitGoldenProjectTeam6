using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChildArbo : MonoBehaviour
{
    [HideInInspector] public List<Transform> _positionChild;
    public float[] _zoomChild;
    [HideInInspector] public int _actualPos;
    void Start()
    {
        foreach (Transform child in transform)
        {
            _positionChild.Add(child);
        }
    }
}
